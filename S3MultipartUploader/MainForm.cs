using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

using Amazon;
using Amazon.Util;
using Amazon.Runtime;

using Amazon.S3;
using Amazon.S3.Model;

using static S3MultipartUploader.Properties.Resources;

namespace S3MultipartUploader {

    public partial class MainForm : Form {

        // HIDDEN FIELDS
        private CancellationTokenSource _ctsListBuckets = new CancellationTokenSource();
        private CancellationTokenSource _ctsUpload = new CancellationTokenSource();
        private InitiateMultipartUploadRequest _uploadRequest = new InitiateMultipartUploadRequest();
        private object _logLock = new object();
        private bool _uploading = false;

        public MainForm() {
            InitializeComponent();

            // Bind data
            var profileNode = new TreeNode();
            var regionNode = new TreeNode();
            bindProfilesAsync(profileNode);
            bindRegionsAsync(regionNode);
            addLog(profileNode);
            addLog(regionNode);

            // Set initial validity of the Form
            cvStartUpload.MarkValidity(ComboProfiles, false);
            cvStartUpload.MarkValidity(ComboRegions, false);
            cvStartUpload.MarkValidity(ComboBuckets, false);
            cvStartUpload.MarkValidity(TxtKey, false);
            cvStartUpload.MarkValidity(ListParts, false);
        }

        #region Event Handlers
        
        private void MainForm_Shown(object sender, EventArgs e) {
            TreeLog.ExpandAll();    // This method seems to have no affect during contructor or Activated event
        }
        private void BtnOptions_Click(object sender, EventArgs e) {
            AdvancedOptionsForm f = new AdvancedOptionsForm();
            f.ShowDialog();
        }
        private async void BtnChooseDir_Click(object sender, EventArgs e) {
            // Let the user select a Directory of object parts
            // If they cancel then just log a message
            DialogResult result = FolderBrowserParts.ShowDialog();
            if (result == DialogResult.Cancel)
                addLog(SelectDirectoryCancelled);
            else if (result == DialogResult.OK) {
                var logNode = new TreeNode();
                await bindObjectPartsAsync(logNode);
                addLog(logNode);
                logNode.Expand();
            }
        }
        private void BtnAddProfile_Click(object sender, EventArgs e) {
            SaveProfileForm f = new SaveProfileForm();
            f.ProfileAdded += SaveProfileForm_ProfileAdded;
            f.ShowDialog();
        }
        private void BtnEditProfile_Click(object sender, EventArgs e) {
            var profile = ComboProfiles.SelectedItem as AWSCredentialsProfile;
            SaveProfileForm f = new SaveProfileForm(profile);
            f.ProfileEdited += SaveProfileForm_ProfileEdited;
            f.ShowDialog();
        }
        private async void BtnDeleteProfile_Click(object sender, EventArgs e) {
            // Delete the selected AWS credentials profile
            AWSCredentialsProfile profile;
            using (new WaitCursor()) {
                profile = ComboProfiles.SelectedItem as AWSCredentialsProfile;
                ProfileManager.UnregisterProfile(profile.Name);
            }

            // Log this information
            string msg = string.Format(ProfileDeleted, profile.Name);
            addLog(msg);

            // Reset the data source for the profiles combobox
            var logNode = new TreeNode();
            ProfileSettingsBase[] profiles = await bindProfilesAsync(logNode);
            addLog(logNode);
            if (profiles.Length == 0)
                resetBuckets();
        }
        private async void SaveProfileForm_ProfileAdded(object sender, ProfileEventArgs e) {
            // Persist the new AWS credentials profile!
            using (new WaitCursor()) {
                ProfileManager.RegisterProfile(e.ProfileName, e.AccessKeyId, e.SecretAccessKey);
            }

            // Log this information
            string msg = string.Format(ProfileAdded, e.ProfileName);
            addLog(msg);

            // Reset the data source for the profiles combobox
            // Select the profile that was just added
            ProfileSettingsBase[] profiles = await bindProfilesAsync();
            ComboProfiles.SelectedIndex = profiles.Length - 1;
        }
        private async void SaveProfileForm_ProfileEdited(object sender, ProfileEventArgs e) {
            // If no changes were made then just log a message and return
            string msg;
            string name = e.ProfileName;
            var profile = ComboProfiles.SelectedItem as AWSCredentialsProfile;
            var creds = await profile.Credentials.GetCredentialsAsync();
            if (e.AccessKeyId == creds.AccessKey && e.SecretAccessKey == creds.SecretKey) {
                msg = string.Format(ProfileUnchanged, name);
                addLog(msg);
                return;
            }

            // Persist changes to this AWS credentials profile
            using (new WaitCursor()) {
                AWSCredentialsProfile.Persist(name, e.AccessKeyId, e.SecretAccessKey);
            }
            msg = string.Format(ProfileEdited, name);
            addLog(msg);

            // Reset the data source for the profiles combobox
            // Keep selected the profile that was just edited
            ProfileSettingsBase[] profiles = await bindProfilesAsync();
            profile = profiles.Single(p => p.Name == name) as AWSCredentialsProfile;
            ComboProfiles.SelectedIndex = Array.IndexOf(profiles, profile);
        }
        private async void ComboProfile_SelectedIndexChanged(object sender, EventArgs e) {
            // If there is no more selection then just return
            var profile = ComboProfiles.SelectedItem as AWSCredentialsProfile;
            if (profile == null)
                return;

            // Log the new selection
            string msg = string.Format(ProfileSelected, profile.Name);
            var logNode = new TreeNode(msg);
            addLog(logNode);

            // If both a credentials profile and a region have been selected then list buckets
            var region = ComboRegions.SelectedItem as RegionEndpoint;
            if (region != null)
                await bindBucketsAsync(profile, region, logNode);
            logNode.Expand();
        }
        private async void ComboRegions_SelectedIndexChanged(object sender, EventArgs e) {
            // If there is no more selection then just return
            var region = ComboRegions.SelectedItem as RegionEndpoint;
            if (region == null)
                return;

            // Log the new selection
            string msg = string.Format(RegionSelected, region.DisplayName);
            var logNode = new TreeNode(msg);
            addLog(logNode);

            // If no buckets have been listed yet, and both a credentials profile and a region have been selected,
            // then list buckets
            if (!cvStartUpload.ControlValid(ComboBuckets)) {
                var profile = ComboProfiles.SelectedItem as AWSCredentialsProfile;
                if (profile != null)
                    await bindBucketsAsync(profile, region, logNode);
                logNode.Expand();
            }
        }
        private void ComboBucket_SelectedIndexChanged(object sender, EventArgs e) {
            // If there is no more selection then just return
            var bucket = ComboBuckets.SelectedItem as S3Bucket;
            if (bucket == null)
                return;

            // Log the new selection
            string msg = string.Format(BucketSelected, bucket.BucketName);
            addLog(msg);
        }
        private void TxtKey_TextChanged(object sender, EventArgs e) {
            validateKey();
        }
        private void TxtKey_Validating(object sender, System.ComponentModel.CancelEventArgs e) {
            validateKey();
        }
        private void VsmStartUpload_ValidityChanged(object sender, EventArgs e) {
            BtnStart.Enabled = cvStartUpload.AllControlsValid;
        }
        private async void BtnStart_Click(object sender, EventArgs e) {
            // Adjust controls
            if (!_uploading)
                resetUploadCtrls(true);
            return;

            // Create the multipart upload request
            var profile = ComboProfiles.SelectedItem as AWSCredentialsProfile;
            _ctsUpload = new CancellationTokenSource();
            ImmutableCredentials creds = await profile.Credentials.GetCredentialsAsync();
            if (_ctsUpload.IsCancellationRequested)
                return;
            var region = ComboRegions.SelectedItem as RegionEndpoint;
            var bucket = ComboBuckets.SelectedItem as S3Bucket;
            string key = TxtKey.Text;
            _uploadRequest.BucketName = bucket.BucketName;
            _uploadRequest.Key = key;

            // Initate multipart upload
            var credsTask = profile.Credentials.GetCredentialsAsync();
            var s3 = new AmazonS3Client(creds.AccessKey, creds.SecretKey, region);
            InitiateMultipartUploadResponse response = await s3.InitiateMultipartUploadAsync(_uploadRequest, _ctsUpload.Token);
        }
        private void BtnStop_Click(object sender, EventArgs e) {
            resetUploadCtrls(false);

            _ctsUpload.Cancel();
        }

        #endregion

        // HELPERS
        private async Task<ProfileSettingsBase[]> bindProfilesAsync(TreeNode logNode = null) {
            // Set up for listing profiles
            if (logNode != null) {
                string msg = string.Format(ListingProfiles);
                logNode.Text = msg;
            }
            resetProfiles();

            // List profiles
            ProfileSettingsBase[] profiles;
            profiles = ProfileManager.ListProfiles().ToArray();
            using (new WaitCursor()) {
                profiles = await Task.Run(() => ProfileManager.ListProfiles().ToArray());
            }

            // Adjust controls based on listed profiles
            if (logNode != null) {
                string msg = string.Format(ProfilesListed, profiles.Length);
                logNode.Nodes.Add(msg);
            }
            resetProfiles(profiles);

            return profiles;
        }
        private async Task<RegionEndpoint[]> bindRegionsAsync(TreeNode logNode = null) {
            // Set up for listing S3 regions
            if (logNode != null)
                logNode.Text = ListingS3Regions;
            resetRegions();

            // List regions
            RegionEndpoint[] regions;
            using (new WaitCursor()) {
                regions = await Task.Run(() => RegionEndpoint.EnumerableAllRegions.ToArray());
            }

            // Adjust controls based on listed regions
            if (logNode != null) {
                string msg = string.Format(S3RegionsListed, regions.Length);
                logNode.Nodes.Add(msg);
            }
            resetRegions(regions);

            // Select the Region given in the config file by default
            RegionEndpoint region = regions.Single(r => r.SystemName == AWSConfigs.AWSRegion);
            ComboRegions.SelectedItem = region;

            return regions;
        }
        private async Task<List<S3Bucket>> bindBucketsAsync(AWSCredentialsProfile profile, RegionEndpoint region, TreeNode logNode = null) {
            // Set up for listing buckets
            if (logNode != null) {
                string msg = string.Format(ListingBuckets, profile.Name);
                logNode.Nodes.Add(msg);
            }
            resetBuckets();
            _ctsListBuckets.Cancel();
            _ctsListBuckets = new CancellationTokenSource();

            // Asynchronously list buckets available to this profile
            var s3 = new AmazonS3Client(profile.Credentials, region);
            List<S3Bucket> buckets = new List<S3Bucket>();
            using (new WaitCursor()) {
                try {
                    buckets = (await s3.ListBucketsAsync(_ctsListBuckets.Token)).Buckets;
                }
                catch (OperationCanceledException) {
                    logNode?.Remove();
                    return buckets;
                }

                // If an exception occurs then log its details...
                catch (AmazonServiceException ex) {
                    if (logNode != null) {
                        var errNode = new TreeNode(ListingBucketsFailed);
                        var stackNode = new TreeNode(ExceptionStackTrace);
                        TreeNode[] stackTraceNodes = ex.StackTrace.Split('\n').Select(m => new TreeNode(m)).ToArray();
                        stackNode.Nodes.AddRange(stackTraceNodes);
                        errNode.Nodes.AddRange(
                            new string[3] {
                            string.Format(ExceptionMessage, ex.Message),
                            string.Format(ExceptionSource, ex.Source),
                            string.Format(ExceptionTargetSite, ex.TargetSite),
                            }
                            .Select(m => new TreeNode(m)).ToArray()
                        );
                        errNode.Nodes.Add(stackNode);
                        logNode.Nodes.Add(errNode);
                    }
                    return buckets;
                }
            }

            // Adjust controls based on listed buckets
            if (logNode != null) {
                string msg = string.Format(BucketsListed, buckets.Count);
                logNode.Nodes.Add(msg);
            }
            resetBuckets(buckets);

            return buckets;
        }
        private async Task<FileInfo[]> bindObjectPartsAsync(TreeNode logNode) {
            // Set up for listing object parts
            string path = FolderBrowserParts.SelectedPath;
            logNode.Text = string.Format(SelectDirectorySuccess, path);
            resetParts();

            // List object parts
            FileInfo[] parts;
            string[] messages = new string[0];
            using (new WaitCursor()) {
                parts = await Task.Run(() => getPartsInDirectory(new DirectoryInfo(path), out messages));
            }

            // Adjust controls based on listed object parts
            TreeNode[] msgNodes = messages.Select(m => new TreeNode(m)).ToArray();
            logNode.Nodes.AddRange(msgNodes);
            resetParts(parts);

            return parts;
        }
        private FileInfo[] getPartsInDirectory(DirectoryInfo dir, out string[] messages) {
            // Get the number of object parts and total files in this Directory
            IEnumerable<FileInfo> files = dir.EnumerateFiles()
                                             .Where(f =>
                                                    !f.Attributes.HasFlag(FileAttributes.System) &&
                                                    !f.Attributes.HasFlag(FileAttributes.Hidden));
            IEnumerable<FileInfo> parts = files.Where(f => {
                                                    double result;
                                                    return double.TryParse(f.Extension, out result); });
            int numFiles = files.Count();
            int numParts = parts.Count();
            List<string> msgs = new List<string>(2);

            // Create a log messages according to how many parts were found
            bool error = true;
            if (numFiles == 0)
                msgs.Add(NoFilesFound);

            else if (numFiles == 1 && numParts == 0) {
                msgs.Add(OnlyOneFileFound);
                msgs.Add(OnlyPartsAllowed);
            }

            else if (numFiles == 1 && numParts == 1) {
                error = false;
                msgs.Add(OnePartFound);
            }

            else if (numParts == 0) {
                msgs.Add(string.Format(NoPartsFound, numFiles));
                msgs.Add(OnlyPartsAllowed);
            }

            else if (numParts == 1) {
                msgs.Add(string.Format(OnlyOnePartFound, numFiles));
                msgs.Add(OnlyPartsAllowed);
            }

            else if (numParts < numFiles) {
                msgs.Add(string.Format(OnlyNPartsFound, numFiles, numParts));
                msgs.Add(OnlyPartsAllowed);
            }

            else {
                error = false;
                msgs.Add(string.Format(NPartsFound, numParts));
            }

            // Return the object parts and log/error messages
            messages = msgs.ToArray();
            return (error ? new FileInfo[0] : parts.ToArray());
        }
        
        private void resetProfiles(ProfileSettingsBase[] profiles = null) {
            bool valid = profiles?.Length > 0;

            ComboProfiles.DisplayMember = nameof(ProfileSettingsBase.Name);
            ComboProfiles.DataSource = profiles;

            LblProfile.Enabled = valid;
            ComboProfiles.Enabled = valid;
            BtnEditProfile.Enabled = valid;
            BtnDeleteProfile.Enabled = valid;

            string error = (valid ? "" : MissingProfile);
            ErrorMain.SetError(ComboProfiles, error);

            cvStartUpload.MarkValidity(ComboProfiles, valid);
        }
        private void resetRegions(RegionEndpoint[] regions = null) {
            bool valid = regions?.Length > 0;

            ComboRegions.DisplayMember = nameof(RegionEndpoint.DisplayName);
            ComboRegions.SelectedIndex = -1;
            ComboRegions.DataSource = regions;

            LblRegion.Enabled = valid;
            ComboRegions.Enabled = valid;

            string error = (valid ? "" : MissingRegion);
            ErrorMain.SetError(ComboRegions, error);

            cvStartUpload.MarkValidity(ComboRegions, valid);
        }
        private void resetBuckets(List<S3Bucket> buckets = null) {
            bool valid = buckets?.Count > 0;

            ComboBuckets.DisplayMember = nameof(S3Bucket.BucketName);
            ComboBuckets.DataSource = buckets;

            LblBucket.Enabled = valid;
            ComboBuckets.Enabled = valid;

            string error = (valid ? "" : MissingS3Bucket);
            ErrorMain.SetError(ComboBuckets, error);

            cvStartUpload.MarkValidity(ComboBuckets, valid);
        }
        private void resetParts(FileInfo[] parts = null) {
            bool valid = parts?.Length > 0;
            ListParts.Items.Clear();
            if (valid)
                ListParts.Items.AddRange(parts);

            TblLayoutParts.Enabled = valid;
            cvStartUpload.MarkValidity(ListParts, valid);
        }
        private void resetUploadCtrls(bool uploading) {
            PnlTop.Enabled = !uploading;
            ProgressMain.Enabled = uploading;
            BtnStop.Enabled = uploading;
            BtnStart.Enabled = !uploading;
            addLog(uploading ? UploadStarted : UploadCancelled);
        }

        private void validateKey() {
            // Log messages and update the Form's valid state depending on whether the provided S3 key is valid
            string error;
            bool valid = ValidateS3.Key(TxtKey.Text, out error);
            ErrorMain.SetError(TxtKey, error);
            cvStartUpload.MarkValidity(TxtKey, valid);
        }

        #region Log Helpers

        private void addLog(string message, bool showMsgBox = false) {
            addLogs(message);

            if (showMsgBox)
                MessageBox.Show(message);
        }
        private void addLog(TreeNode node) {
            addLogs(node);
        }
        private void addLog(string message, TreeNode parent) {
            addLogs(parent, message);
        }
        private void addLogs(params string[] messages) {
            TreeNode[] nodes = messages.Select(m => new TreeNode(m)).ToArray();
            lock (_logLock)
                TreeLog.Nodes.AddRange(nodes);

            autoScrollLogs();
        }
        private void addLogs(TreeNode parent, params string[] messages) {
            // Parent these message-nodes to the given parent
            TreeNode[] nodes = messages.Select(m => new TreeNode(m)).ToArray();
            parent.Nodes.AddRange(nodes);

            // Add the parent to the TreeView, if necessary
            lock (_logLock) {
                if (parent.TreeView == null)
                    TreeLog.Nodes.Add(parent);
            }

            autoScrollLogs();
        }
        private void autoScrollLogs() {
            lock (_logLock) {
                TreeLog.SelectedNode = TreeLog.Nodes[TreeLog.Nodes.Count - 1];
                TreeLog.SelectedNode = null;
            }
        }

        #endregion

    }

}
