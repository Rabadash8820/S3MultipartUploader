using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

using static S3MultipartUploader.Properties.Resources;

using Amazon.S3;
using Amazon.S3.Model;

namespace S3MultipartUploader {

    public partial class AdvancedOptionsForm : Form {

        private bool _origAsync = true;
        private InitiateMultipartUploadRequest _origRequest = new InitiateMultipartUploadRequest();

        public event EventHandler<OptionsEventArgs> OptionsSaved;

        public AdvancedOptionsForm(bool uploadAsync, InitiateMultipartUploadRequest request) {
            InitializeComponent();

            _origAsync = uploadAsync;
            _origRequest = request;

            DgvColGrantee.ToolTipText = GranteeColumnToolTip;   // Can't put multiline tool tips on DGV columns in the designer apparently >:(

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
            DataGridViewRow[] rows = request.Grants
                                            .GroupBy(g => g.Grantee, g => g.Permission)
                                            .Select(g => rowFromGrants(g.Key, g.AsEnumerable()))
                                            .ToArray();
            DgvGrants.Rows.AddRange(rows);

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
        private void resetGrantCtrls(bool useCannedACLs) {
            LblAcl.Enabled = useCannedACLs;
            ComboAcl.Enabled = useCannedACLs;

            DgvGrants.Enabled = !useCannedACLs;
        }
        private bool otherOptsFromCtrls() {
            bool uploadAsync = ChkAsynchronous.Checked;
            return uploadAsync;
        }

        private DataGridViewRow rowFromGrants(S3Grantee grantee, IEnumerable<S3Permission> permissions) {
            // Create the S3Grantee from the Canonical User ID, Email Address, or Group (whichever was provided)
            int grTypeIndex = 0;
            string grName = null;
            GranteeType type = grantee.Type;
            if (type == GranteeType.CanonicalUser) {
                grTypeIndex = 0;
                grName = grantee.CanonicalUser;
            }
            else if (type == GranteeType.Email) {
                grTypeIndex = 1;
                grName = grantee.EmailAddress;
            }
            else if (type == GranteeType.Group) {
                grTypeIndex = 2;
                grName = grantee.URI;
            }

            // Add a grant with READ permissions, if required
            bool canRead = permissions.Contains(S3Permission.READ);
            bool canReadAcl = permissions.Contains(S3Permission.READ_ACP);
            bool canWriteAcl = permissions.Contains(S3Permission.WRITE_ACP);

            // Add a grant with WRITE_ACP permissions, if required
            var row = DgvGrants.RowTemplate.Clone() as DataGridViewRow;
            string grType = DgvColGranteeType.Items[grTypeIndex].ToString();
            row.CreateCells(DgvGrants, grType, grName, canRead, canReadAcl, canWriteAcl);

            return row;
        }
        private IEnumerable<S3Grant> grantsFromRow(DataGridViewRow row) {
            // Create the S3Grantee from the Canonical User ID, Email Address, or Group (whichever was provided)
            S3Grantee grantee = null;
            string typeStr = row.Cells[DgvColGranteeType.Index].Value.ToString();
            string granteeStr = row.Cells[DgvColGrantee.Index].Value.ToString();
            if (typeStr == "Canonical User ID")
                grantee = new S3Grantee() { CanonicalUser = granteeStr };
            else if (typeStr == "Email Address")
                grantee = new S3Grantee() { EmailAddress = granteeStr };
            else if (typeStr == "Group")
                grantee = new S3Grantee() { URI = granteeStr };

            IList<S3Grant> grants = new List<S3Grant>(3);

            // Add a grant with READ permissions, if required
            object canRead = row.Cells[DgvColCanRead.Index].Value;
            if (canRead != null && (bool)canRead) {
                grants.Add(new S3Grant() {
                    Grantee = grantee,
                    Permission = S3Permission.READ,
                });
            }

            // Add a grant with READ_ACP permissions, if required
            object canReadAcl = row.Cells[DgvColCanReadAcl.Index].Value;
            if (canReadAcl != null && (bool)canReadAcl) {
                grants.Add(new S3Grant() {
                    Grantee = grantee,
                    Permission = S3Permission.READ_ACP,
                });
            }

            // Add a grant with WRITE_ACP permissions, if required
            object canWriteAcl = row.Cells[DgvColCanWriteAcl.Index].Value;
            if (canWriteAcl != null && (bool)canWriteAcl) {
                grants.Add(new S3Grant() {
                    Grantee = grantee,
                    Permission = S3Permission.WRITE_ACP,
                });
            }

            return grants;
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
            request.WebsiteRedirectLocation = TxtWebsite.Text;
            request.RequestPayer = (ChkRequestPayer.Checked ? RequestPayer.Requester : null);

            // Set metadata from control values
            IEnumerable<DataGridViewRow> metaRows = DgvMetadata.Rows.Cast<DataGridViewRow>().Where(r => !r.IsNewRow);
            foreach (DataGridViewRow row in metaRows) {
                string key = row.Cells[DgvColMetadataKey.Index].Value.ToString();
                string val = row.Cells[DgvColMetadataValue.Index].Value.ToString();
                request.Metadata.Add(key, val);
            }

            // Set headers from control values
            request.Headers.ContentType = TxtType.Text;
            request.Headers.ContentDisposition = TxtDisposition.Text;
            request.Headers.ContentEncoding = TxtEncoding.Text;
            request.Headers.Expires = DatePickerExpires.Value.ToUniversalTime();

            // Initialize access control
            bool useCannedAcl = ChkUseCannedACLs.Checked;
            request.CannedACL = (useCannedAcl ? S3CannedACL.FindValue(ComboAcl.Text) : null);
            if (useCannedAcl)
                request.Grants = null;
            else {
                IEnumerable<S3Grant> grants = DgvGrants.Rows.Cast<DataGridViewRow>()
                                                       .Where(r => !r.IsNewRow)
                                                       .SelectMany(r => grantsFromRow(r));
                request.Grants.AddRange(grants);
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

    }

}
