using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

using Amazon.S3;
using Amazon.S3.Model;

namespace S3MultipartUploader {

    public partial class AdvancedOptionsForm : Form {

        private bool _origAsync = true;
        private InitiateMultipartUploadRequest _origRequest = new InitiateMultipartUploadRequest();

        public event EventHandler<OptionsEventArgs> OptionsSaved;

        public AdvancedOptionsForm() {
            InitializeComponent();

            initializeDatePicker(_origRequest.Headers.Expires.GetValueOrDefault());
            initOtherCtrls(_origAsync);
            initRequestCtrls(_origRequest);
        }
        public AdvancedOptionsForm(bool uploadAsync, InitiateMultipartUploadRequest request) {
            InitializeComponent();

            _origAsync = uploadAsync;
            _origRequest = request;
            
            initializeDatePicker(_origRequest.Headers.Expires.GetValueOrDefault());
            initOtherCtrls(_origAsync);
            initRequestCtrls(_origRequest);
        }
        private void RadioNone_CheckedChanged(object sender, EventArgs e) {
            resetSseCtrls(RadioSseKms.Checked, RadioSseNewKey.Checked);
        }
        private void RadioKMS_CheckedChanged(object sender, EventArgs e) {
            resetSseCtrls(RadioSseKms.Checked, RadioSseNewKey.Checked);
        }
        private void RadioNewKey_CheckedChanged(object sender, EventArgs e) {
            resetSseCtrls(RadioSseKms.Checked, RadioSseNewKey.Checked);
        }
        private void ChkCannedACLs_CheckedChanged(object sender, EventArgs e) {
            resetGrantCtrls(ChkUseCannedACLs.Checked);
        }
        private void DgvGrants_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e) {
            // Make Email address the default grantee type for new rows
            DataGridViewCell granteeTypeCell = e.Row.Cells[DgvColGranteeType.Index];
            granteeTypeCell.Value = DgvColGranteeType.Items[1];
        }
        private void BtnSave_Click(object sender, EventArgs e) {
            _origAsync = otherOptsFromCtrls();
            _origRequest = requestFromCtrls();

            OptionsEventArgs args = new OptionsEventArgs(_origAsync, _origRequest);
            OptionsSaved?.Invoke(this, args);
        }
        
        private void initOtherCtrls(bool uploadAsync) {
            ChkAsynchronous.Checked = uploadAsync;
        }
        private void initRequestCtrls(InitiateMultipartUploadRequest request) {
            // Initialize storage class
            if (request.StorageClass == S3StorageClass.ReducedRedundancy)
                RadioReducedRedund.Checked = true;
            else if (request.StorageClass == S3StorageClass.StandardInfrequentAccess)
                RadioStandardIA.Checked = true;
            else
                RadioStandard.Checked = true;

            // Initialize other fields
            ComboAcl.SelectedItem = request.CannedACL?.Value;
            TxtWebsite.Text = request.WebsiteRedirectLocation;
            ChkRequestPayer.Checked = (request.RequestPayer == null ? false : true);

            // Initialize metadata
            MetadataCollection metadata = request.Metadata;
            foreach (string key in metadata.Keys)
                DgvMetadata.Rows.Add(key, metadata[key]);

            // Initialize headers
            TxtType.Text = request.Headers.ContentType;
            TxtDisposition.Text = request.Headers.ContentDisposition;
            TxtEncoding.Text = request.Headers.ContentEncoding;

            // Initialize access control
            foreach (S3Grant grant in request.Grants) {
                //string grantee = string.Empty;
                //if (grant.Grantee.Type == GranteeType.CanonicalUser)
                //    grantee = grant.Grantee.CanonicalUser;
                //else if (grant.Grantee.Type == GranteeType.Email)
                //    grantee = grant.Grantee.EmailAddress;
                //else if (grant.Grantee.Type == GranteeType.Group)
                //    grantee = grant.Grantee.URI;

                DgvGrants.Rows.Add(grant.Permission.Value, grant.Grantee.DisplayName);
            }

            // Initialize SSE method
            bool kms = (request.ServerSideEncryptionMethod == ServerSideEncryptionMethod.AWSKMS);
            bool newKey = (request.ServerSideEncryptionMethod == ServerSideEncryptionMethod.AES256);
            if (kms)
                RadioSseKms.Checked = true;
            else if (newKey)
                RadioSseNewKey.Checked = true;
            else
                RadioSseNone.Checked = true;

            // Initialize other SSE controls
            TxtSseKeyId.Text = (kms ? request.ServerSideEncryptionKeyManagementServiceKeyId : null);
            TxtSseCustomerKey.Text = (newKey ? request.ServerSideEncryptionCustomerProvidedKey : null);
            TxtSseCustomerKey.Text = request.ServerSideEncryptionCustomerProvidedKey;
            TxtSseCustomerKeyMd5.Text = request.ServerSideEncryptionCustomerProvidedKeyMD5;
        }
        private void initializeDatePicker(DateTime value) {
            DatePickerExpires.MinDate = DateTime.Now;

            // Initialize the DateTimePicker's value, making sure the value isn't out of range
            if (value < DatePickerExpires.MinDate)
                DatePickerExpires.Value = DatePickerExpires.MinDate;
            else if (value > DatePickerExpires.MaxDate)
                DatePickerExpires.Value = DatePickerExpires.MaxDate;
            else
                DatePickerExpires.Value = value;
        }
        private void resetSseCtrls(bool kms, bool newKey) {
            LblSseKeyId.Enabled = kms;
            TxtSseKeyId.Enabled = kms;

            LblSseCustomerKey.Enabled = newKey;
            TxtSseCustomerKey.Enabled = newKey;

            LblSseCustomerKeyMd5.Enabled = newKey;
            TxtSseCustomerKeyMd5.Enabled = newKey;
        }
        private bool otherOptsFromCtrls() {
            bool uploadAsync = ChkAsynchronous.Checked;
            return uploadAsync;
        }
        private InitiateMultipartUploadRequest requestFromCtrls() {
            InitiateMultipartUploadRequest request = new InitiateMultipartUploadRequest();

            // Set storage class from control values
            if (RadioReducedRedund.Checked)
                request.StorageClass = S3StorageClass.ReducedRedundancy;
            else if (RadioStandardIA.Checked)
                request.StorageClass = S3StorageClass.StandardInfrequentAccess;
            else
                request.StorageClass = S3StorageClass.Standard;

            // Set other fields from control values
            request.CannedACL = S3CannedACL.FindValue(ComboAcl.Text);
            request.WebsiteRedirectLocation = TxtWebsite.Text;
            request.RequestPayer = (ChkRequestPayer.Checked ? RequestPayer.Requester : null);

            // Set metadata from control values
            IEnumerable<DataGridViewRow> metaRows = DgvMetadata.Rows.Cast<DataGridViewRow>().Where(r => !r.IsNewRow);
            foreach (DataGridViewRow row in metaRows) {
                string key = row.Cells[0].Value.ToString();
                string val = row.Cells[1].Value.ToString();
                request.Metadata.Add(key, val);
            }

            // Set headers from control values
            request.Headers.ContentType = TxtType.Text;
            request.Headers.ContentDisposition = TxtDisposition.Text;
            request.Headers.ContentEncoding = TxtEncoding.Text;
            request.Headers.Expires = DatePickerExpires.Value.ToUniversalTime();

            // Initialize access control
            IEnumerable<DataGridViewRow> grantRows = DgvGrants.Rows.Cast<DataGridViewRow>().Where(r => !r.IsNewRow);
            foreach (DataGridViewRow row in grantRows) {
                S3Grantee grantee = null;
                string typeStr = row.Cells[DgvColGranteeType.Index].Value.ToString();
                string granteeStr = row.Cells[DgvColGrantee.Index].Value.ToString();
                if (typeStr == "Canonical User")
                    grantee = new S3Grantee() { CanonicalUser = granteeStr };
                else if (typeStr == "Email")
                    grantee = new S3Grantee() { EmailAddress = granteeStr };
                else if (typeStr == "Group")
                    grantee = new S3Grantee() { URI = granteeStr };


                S3Permission permission = null;
                var canRead = (bool)row.Cells[DgvColCanRead.Index].Value;
                var canReadAcl = (bool)row.Cells[DgvColCanReadAcl.Index].Value;
                var canWriteAcl = (bool)row.Cells[DgvColCanWriteAcl.Index].Value;
                if (canRead)
                    permission = S3Permission.READ;
                if (canReadAcl)
                    permission = S3Permission.READ_ACP;
                if (canWriteAcl)
                    permission = S3Permission.WRITE_ACP;
                S3Grant grant = new S3Grant() {
                    Grantee = grantee,
                    Permission = permission,
                };
                request.Grants.Add(grant);
            }

            // Initialize server side encryption method
            bool kms = RadioSseKms.Checked;
            bool newKey = RadioSseNewKey.Checked;
            if (kms)
                request.ServerSideEncryptionMethod = ServerSideEncryptionMethod.AWSKMS;
            else if (newKey)
                request.ServerSideEncryptionMethod = ServerSideEncryptionMethod.AES256;
            else
                request.ServerSideEncryptionMethod = ServerSideEncryptionMethod.None;

            // Set server side encryption from control values
            request.ServerSideEncryptionKeyManagementServiceKeyId = (kms ? TxtSseKeyId.Text : null);
            request.ServerSideEncryptionCustomerMethod = (newKey ? ServerSideEncryptionCustomerMethod.AES256 : ServerSideEncryptionCustomerMethod.None);
            request.ServerSideEncryptionCustomerProvidedKey = (newKey ? TxtSseCustomerKey.Text : null);
            request.ServerSideEncryptionCustomerProvidedKeyMD5 = (newKey ? TxtSseCustomerKeyMd5.Text : null);

            return request;
        }
        private void resetGrantCtrls(bool useCannedACLs) {
            LblAcl.Enabled = useCannedACLs;
            ComboAcl.Enabled = useCannedACLs;

            DgvGrants.Enabled = !useCannedACLs;
        }

    }

}
