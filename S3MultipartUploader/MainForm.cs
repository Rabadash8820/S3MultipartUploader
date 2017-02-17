using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

using Amazon.S3;
using Amazon.Runtime;

using static S3MultipartUploader.Properties.Resources;

namespace S3MultipartUploader {

    public partial class MainForm : Form {

        // HIDDEN FIELDS

        public MainForm() {
            InitializeComponent();
            //AWSCredentials cred = new 
            
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
                logMessages(SelectDirectoryCancel);

            // Otherwise, store the parts in the Directory
            else if (result == DialogResult.OK) {
                resetParts();
                string path = FolderBrowserParts.SelectedPath;
                logMessages(string.Format(SelectDirectorySuccess, path));
                getPartsInDirectory(new DirectoryInfo(path));
            }
        }
        private void BtnAddProfile_Click(object sender, EventArgs e) {
            AddProfileForm f = new AddProfileForm();
            f.ShowDialog();
        }

        // HELPERS
        private void logMessages(params string[] messages) {
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
