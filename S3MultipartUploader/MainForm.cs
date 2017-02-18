using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

using Amazon.Util;
using Amazon.Runtime;

using static S3MultipartUploader.Properties.Resources;

namespace S3MultipartUploader {

    public partial class MainForm : Form {

        // HIDDEN FIELDS

        public MainForm() {
            InitializeComponent();

            bindProfiles();
        }

        // EVENT HANDLERS
        private void BtnOptions_Click(object sender, EventArgs e) {
            AdvancedOptionsForm f = new AdvancedOptionsForm();
            f.ShowDialog();
        }
        private void BtnChooseDir_Click(object sender, EventArgs e) {
            // Let the user select a Directory of object parts
            // If they cancel then just log a message
            DialogResult result = FolderBrowserParts.ShowDialog();
            if (result == DialogResult.Cancel)
                logMessage(SelectDirectoryCancel);

            // Otherwise, store the parts in the Directory
            else if (result == DialogResult.OK) {
                resetParts();
                string path = FolderBrowserParts.SelectedPath;
                logMessage(string.Format(SelectDirectorySuccess, path));
                getPartsInDirectory(new DirectoryInfo(path));
            }
        }
        private void BtnAddProfile_Click_1(object sender, EventArgs e) {
            AddProfileForm f = new AddProfileForm();
            f.ProfileAdded += AddProfileForm_ProfileAdded;
            f.ShowDialog();
        }
        private void AddProfileForm_ProfileAdded(object sender, ProfileEventArgs e) {
            Cursor.Current = Cursors.WaitCursor;

            // Persist the new AWS credentials profile!
            string name = e.ProfileName;
            AWSCredentialsProfile.Persist(name, e.AccessKeyId, e.SecretAccessKey);
            AWSCredentials creds = ProfileManager.GetAWSCredentials(name);

            Cursor.Current = Cursors.Default;

            // Log this information
            string msg = string.Format(ProfileAdded, name);
            logMessage(msg, showMsgBox: true);

            // Reset the data source for the profiles combobox
            bindProfiles();
        }

        // HELPERS
        private void bindProfiles() {
            IEnumerable<ProfileSettingsBase> profiles = ProfileManager.ListProfiles();
            ComboProfile.DataSource = profiles;
            ComboProfile.DisplayMember = nameof(ProfileSettingsBase.Name);
            ComboProfile.ValueMember = nameof(ProfileSettingsBase.UniqueId);
        }
        
        private void logMessage(string message, uint numTabs = 0, bool showMsgBox = false) {
            logMessages(numTabs, message);

            if (showMsgBox)
                MessageBox.Show(message);
        }
        private void logMessages(params string[] messages) {
            logMessages(0, messages);
        }
        private void logMessages(bool showMsgBox, params string[] messages) {
            logMessages(0, messages);
        }
        private void logMessages(uint numTabs, params string[] messages) {
            string tabs = new string(' ', 4 * (int)numTabs);
            foreach (string msg in messages)
                ListLog.Items.Add(tabs + msg);
        }
        private void resetParts() {
            ListParts.Items.Clear();
            ListParts.Enabled = false;
        }
        private void resetParts(IEnumerable<FileInfo> parts) {
            ListParts.Items.AddRange(parts.ToArray());
            ListParts.Enabled = true;
        }
        private void getPartsInDirectory(DirectoryInfo dir) {
            // Get the number of object parts and total files in this Directory
            IEnumerable<FileInfo> files = dir.EnumerateFiles().Where(f => 
                                                                    !f.Attributes.HasFlag(FileAttributes.System) &&
                                                                    !f.Attributes.HasFlag(FileAttributes.Hidden));
            IEnumerable<FileInfo> parts = files.Where(f => { double result; return double.TryParse(f.Extension, out result); });
            int numFiles = files.Count();
            int numParts = parts.Count();

            // Log messages and part names accordingly
            string[] messages;
            if (numFiles == 0)
                messages = new string[] { NoFilesFound };

            else if (numFiles == 1 && numParts == 0)
                messages = new string[2] { OnlyOneFileFound, OnlyPartsAllowed };

            else if (numFiles == 1 && numParts == 1) {
                messages = new string[1] { OnePartFound };
                resetParts(parts);
            }

            else if (numParts == 0)
                messages = new string[2] { string.Format(NoPartsFound, numFiles), OnlyPartsAllowed };

            else if (numParts == 1)
                messages = new string[2] { string.Format(OnlyOnePartFound, numFiles), OnlyPartsAllowed };

            else if (numParts < numFiles)
                messages = new string[2] { string.Format(OnlyNPartsFound, numFiles, numParts), OnlyPartsAllowed };
            
            else {
                messages = new string[1] { string.Format(NPartsFound, numParts) };
                resetParts(parts);
            }

            logMessages(1, messages);
        }
    }

}
