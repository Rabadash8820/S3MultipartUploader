using System;
using System.Windows.Forms;
using System.ComponentModel;

using static S3MultipartUploader.Properties.Resources;

using Amazon.Util;
using Amazon.Runtime;

namespace S3MultipartUploader {

    public partial class SaveProfileForm : Form {

        private AWSCredentialsProfile _origProfile;
        private ImmutableCredentials _origCreds;

        public event EventHandler<ProfileEventArgs> ProfileAdded;
        public event EventHandler<ProfileEventArgs> ProfileEdited;

        public SaveProfileForm(AWSCredentialsProfile profile = null) {
            InitializeComponent();

            // Initialize the Form depending on whether we adding a new Profile or editing an existing one
            if (profile == null) {
                cvSave.MarkValidity(TxtProfileName, false);
                cvSave.MarkValidity(TxtAccessKeyID, false);
                cvSave.MarkValidity(TxtSecretAccessKey, false);
            }
            else
                initFields(profile);
        }

        #region Event Handlers

        private void TxtProfileName_Validating(object sender, CancelEventArgs e) {
            validateName();
        }
        private void TxtAccessKeyID_Validating(object sender, CancelEventArgs e) {
            validateAccessKeyId();
        }
        private void TxtSecretAccessKey_Validating(object sender, CancelEventArgs e) {
            validateSecretKey();
        }
        private void TxtProfileName_TextChanged(object sender, EventArgs e) {
            validateName();
        }
        private void TxtAccessKeyID_TextChanged(object sender, EventArgs e) {
            validateAccessKeyId();
        }
        private void TxtSecretAccessKey_TextChanged(object sender, EventArgs e) {
            validateSecretKey();
        }
        private void VsmSave_ValidityChanged(object sender, EventArgs e) {
            BtnSave.Enabled = cvSave.AllControlsValid;
        }
        private void BtnSave_Click(object sender, EventArgs e) {
            // Get values from the UI
            string name = TxtProfileName.Text;
            string accessKeyId = TxtAccessKeyID.Text;
            string secretKey = TxtSecretAccessKey.Text;

            // Save the new profile, or changes to the existing profile, as necessary
            if (_origProfile == null)
                saveNew(name, accessKeyId, secretKey);
            else
                saveChanges(name, accessKeyId, secretKey);
        }

        #endregion

        private void toggleFields(bool enabled) {
            LblName.Enabled = false;
            TxtProfileName.Enabled = false;
            PnlMain.Enabled = enabled;
        }
        private async void initFields(AWSCredentialsProfile profile) {
            toggleFields(false);

            // Get this profile's credentials asynchronously
            _origProfile = profile;
            using (new WaitCursor()) {
                _origCreds = await profile.Credentials.GetCredentialsAsync();
            }

            // Initialize controls with these credentials
            this.Text = string.Format(EditProfileTitle, _origProfile.Name);
            TxtProfileName.Text = _origProfile.Name;
            TxtAccessKeyID.Text = _origCreds.AccessKey;
            TxtSecretAccessKey.Text = _origCreds.SecretKey;

            toggleFields(true);
        }

        #region Validation Helpers
        
        private void validateName() {
            // Log messages and update the Form's valid state depending on whether the provided S3 key is valid
            string error = "";
            bool valid = ValidateProfile.Name(TxtProfileName.Text, out error);
            ErrorMain.SetError(TxtProfileName, error);
            cvSave.MarkValidity(TxtProfileName, valid);
        }
        private void validateAccessKeyId() {
            // Log messages and update the Form's valid state depending on whether the provided S3 key is valid
            string error = "";
            bool valid = ValidateProfile.AccessKey(TxtAccessKeyID.Text, out error);
            ErrorMain.SetError(TxtAccessKeyID, error);
            cvSave.MarkValidity(TxtAccessKeyID, valid);
        }
        private void validateSecretKey() {
            // Log messages and update the Form's valid state depending on whether the provided S3 key is valid
            string error = "";
            bool valid = ValidateProfile.SecretKey(TxtSecretAccessKey.Text, out error);
            ErrorMain.SetError(TxtSecretAccessKey, error);
            cvSave.MarkValidity(TxtSecretAccessKey, valid);
        }
        private void saveNew(string name, string accessKeyId, string secretKey) {
            // Warn the user if they are about to overwrite an existing profile
            try {
                ProfileSettingsBase existing = ProfileManager.GetProfile(name);
                string msg = string.Format(DuplicateProfileText, name);
                DialogResult result = MessageBox.Show(msg, DuplicateProfileCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.No) {
                    this.DialogResult = DialogResult.None;
                    return;
                }
            }
            catch (AmazonClientException) { }

            // Raise an Added event with the new values
            ProfileEventArgs args = new ProfileEventArgs(name, accessKeyId, secretKey);
            ProfileAdded?.Invoke(this, args);
        }
        private void saveChanges(string name, string accessKeyId, string secretKey) {
            // Raise an Edited event with the new values
            ProfileEventArgs args = new ProfileEventArgs(name, accessKeyId, secretKey);
            ProfileEdited?.Invoke(this, args);
        }

        #endregion

    }

}
