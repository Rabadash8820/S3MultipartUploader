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

        private void RadioKMS_CheckedChanged(object sender, EventArgs e) {
            resetKmsCtrls(RadioKMS.Checked);
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
            foreach (S3Grant grant in request.Grants)
                DgvGrants.Rows.Add(grant.Permission.Value, grant.Grantee.DisplayName);

            // Initialize server side encryption method
            if (request.ServerSideEncryptionMethod == ServerSideEncryptionMethod.AES256)
                RadioAES256.Checked = true;
            else if (request.ServerSideEncryptionMethod == ServerSideEncryptionMethod.AWSKMS)
                RadioKMS.Checked = true;
            else
                RadioNone.Checked = true;

            // Initialize server side encryption
            TxtSseKey.Text = request.ServerSideEncryptionCustomerProvidedKey;
            TxtSseAlgorithm.Text = request.ServerSideEncryptionCustomerMethod?.Value;
            TxtSseKeyMd5.Text = request.ServerSideEncryptionCustomerProvidedKeyMD5;
            TxtSseKeyId.Text = request.ServerSideEncryptionKeyManagementServiceKeyId;
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
        private void resetKmsCtrls(bool enabled) {
            LblSseKey.Enabled = enabled;
            LblSseAlgorithm.Enabled = enabled;
            LblSseKeyMd5.Enabled = enabled;
            LblSseKeyId.Enabled = enabled;

            TxtSseKey.Enabled = enabled;
            TxtSseAlgorithm.Enabled = enabled;
            TxtSseKeyMd5.Enabled = enabled;
            TxtSseKeyId.Enabled = enabled;
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
                string permission = row.Cells[0].Value.ToString();
                string grantee = row.Cells[1].Value.ToString();
                S3Grant grant = new S3Grant() {
                    Permission = S3Permission.FindValue(permission),
                    Grantee = new S3Grantee() { DisplayName = grantee },
                };
                request.Grants.Add(grant);
            }

            // Initialize server side encryption method
            if (RadioAES256.Checked)
                request.ServerSideEncryptionMethod = ServerSideEncryptionMethod.AES256;
            else if (RadioKMS.Checked)
                request.ServerSideEncryptionMethod = ServerSideEncryptionMethod.AWSKMS;
            else
                request.ServerSideEncryptionMethod = ServerSideEncryptionMethod.None;

            // Set server side encryption from control values
            request.ServerSideEncryptionCustomerProvidedKey = TxtSseKey.Text;
            request.ServerSideEncryptionCustomerMethod = TxtSseAlgorithm.Text;
            request.ServerSideEncryptionCustomerProvidedKeyMD5 = TxtSseKeyMd5.Text;
            request.ServerSideEncryptionKeyManagementServiceKeyId = TxtSseKeyId.Text;

            return request;
        }

    }

}
