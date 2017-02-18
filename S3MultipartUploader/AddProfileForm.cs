using System;
using System.Windows.Forms;

using S3MultipartUploader.Properties;

using System.ComponentModel;
using System.Text.RegularExpressions;

namespace S3MultipartUploader {

    public partial class AddProfileForm : Form {

        private bool _nameVisited = false;
        private bool _accessKeyVisited = false;
        private bool _secretKeyVisited = false;

        public event EventHandler<ProfileEventArgs> ProfileAdded;

        public AddProfileForm() {
            InitializeComponent();
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

            // Raise an event with these values
            ProfileEventArgs args = new ProfileEventArgs(name, accessKeyId, secretKey);
            ProfileAdded?.Invoke(this, args);
        }

        #endregion

        #region Helpers
        
        private void validateName() {
            _nameVisited = true;

            // If the provided Name is valid then try to enable the Add button
            // Show or clear the error message accordingly
            string error;
            bool valid = validName(TxtProfileName.Text, out error);
            ErrorMain.SetError(TxtProfileName, error);
            BtnAdd.Enabled = canAdd();
        }
        private void validateAccessKeyId() {
            _accessKeyVisited = true;

            // If the provided Access Key ID is valid then try to enable the Add button
            // Show or clear the error message accordingly
            string error;
            bool valid = validAccessKey(TxtAccessKeyID.Text, out error);
            ErrorMain.SetError(TxtAccessKeyID, error);
            BtnAdd.Enabled = canAdd();
        }
        private void validateSecretKey() {
            _secretKeyVisited = true;

            // If the provided Secret Access Key is valid then try to enable the Add button
            // Show or clear the error message accordingly
            string error;
            bool valid = validSecretKey(TxtSecretAccessKey.Text, out error);
            ErrorMain.SetError(TxtSecretAccessKey, error);
            BtnAdd.Enabled = canAdd();
        }
        private bool validName(string name, out string error) {
            bool valid = true;
            error = "";

            if (name == "") {
                error = Resources.MissingProfileName;
                valid = false;
            }
            else if (!Regex.IsMatch(name, Resources.ProfileNameRegex)) {
                error = Resources.InvalidProfileName;
                valid = false;
            }

            return valid;
        }
        private bool validAccessKey(string accessKey, out string error) {
            bool valid = true;
            error = "";

            if (accessKey == "") {
                error = Resources.MissingAccessKeyID;
                valid = false;
            }
            else if (!Regex.IsMatch(accessKey, Resources.ProfileAccessKeyIDRegex)) {
                error = Resources.InvalidProfileAccessKeyID;
                valid = false;
            }

            return valid;
        }
        private bool validSecretKey(string secretKey, out string error) {
            bool valid = true;
            error = "";

            if (secretKey == "") {
                error = Resources.MissingSecretAccessKey;
                valid = false;
            }
            else if (!Regex.IsMatch(secretKey, Resources.ProfileSecretKeyRegex)) {
                error = Resources.InvalidProfileSecretKey;
                valid = false;
            }

            return valid;
        }
        private bool canAdd() {
            // If there are any outstanding errors on the Form, then we cannot add this Profile yet
            bool noErrors = (
                _nameVisited      && ErrorMain.GetError(TxtProfileName)     == "" &&
                _accessKeyVisited && ErrorMain.GetError(TxtAccessKeyID)     == "" &&
                _secretKeyVisited && ErrorMain.GetError(TxtSecretAccessKey) == "");
            return noErrors;
        }

        #endregion
    }

    public class ProfileEventArgs : EventArgs {
        public ProfileEventArgs(string name, string accessKeyId, string secretKey) {
            ProfileName = name;
            AccessKeyId = accessKeyId;
            SecretAccessKey = secretKey;
        }
        public string ProfileName { get; }
        public string AccessKeyId { get; }
        public string SecretAccessKey { get; }
    }

}
