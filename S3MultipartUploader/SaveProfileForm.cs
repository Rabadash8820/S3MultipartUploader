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

        private bool _nameVisited = false;
        private bool _accessKeyVisited = false;
        private bool _secretKeyVisited = false;

        public event EventHandler<ProfileEventArgs> ProfileAdded;
        public event EventHandler<ProfileEventArgs> ProfileEdited;

        public SaveProfileForm() {
            InitializeComponent();
        }
        public SaveProfileForm(AWSCredentialsProfile profile) {
            InitializeComponent();

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
        private void BtnAdd_Click(object sender, EventArgs e) {
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
                _origCreds= await profile.Credentials.GetCredentialsAsync();
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
            _nameVisited = true;

            // If the provided Name is valid then try to enable the Add button
            // Show or clear the error message accordingly
            string error;
            ValidateProfile.Name(TxtProfileName.Text, out error);
            ErrorMain.SetError(TxtProfileName, error);
            BtnSave.Enabled = canAdd();
        }
        private void validateAccessKeyId() {
            _accessKeyVisited = true;

            // If the provided Access Key ID is valid then try to enable the Add button
            // Show or clear the error message accordingly
            string error;
            ValidateProfile.AccessKey(TxtAccessKeyID.Text, out error);
            ErrorMain.SetError(TxtAccessKeyID, error);
            BtnSave.Enabled = canAdd();
        }
        private void validateSecretKey() {
            _secretKeyVisited = true;

            // If the provided Secret Access Key is valid then try to enable the Add button
            // Show or clear the error message accordingly
            string error;
            ValidateProfile.SecretKey(TxtSecretAccessKey.Text, out error);
            ErrorMain.SetError(TxtSecretAccessKey, error);
            BtnSave.Enabled = canAdd();
        }
        private bool canAdd() {
            // If there are any outstanding errors on the Form, then we cannot save this Profile yet
            bool allGood = (
                _nameVisited      && ErrorMain.GetError(TxtProfileName)     == "" && 
                _accessKeyVisited && ErrorMain.GetError(TxtAccessKeyID)     == "" &&
                _secretKeyVisited && ErrorMain.GetError(TxtSecretAccessKey) == "");

            // If we are editing a Profile and there have not been any changes, then we cannot save this Profile yet
            bool valsNew = (_origProfile == null ||
                TxtProfileName.Text     != _origProfile.Name ||
                TxtAccessKeyID.Text     != _origCreds.AccessKey ||
                TxtSecretAccessKey.Text != _origCreds.SecretKey);

            return allGood && valsNew;
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
