using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.Concurrent;

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
        private object _logLock = new object();
        private ConcurrentQueue<string> _logQueue = new ConcurrentQueue<string>();
        private bool _uploading = false;
        private bool _paused = false;

        public MainForm() {
            InitializeComponent();

            // Bind data
            bindProfilesAsync();
            bindRegionsAsync();

            // Set initial validity of the Form
            cvStartUpload.MarkValidity(ComboProfiles, false);
            cvStartUpload.MarkValidity(ComboRegions, false);
            cvStartUpload.MarkValidity(ComboBuckets, false);
            cvStartUpload.MarkValidity(TxtKey, false);
            cvStartUpload.MarkValidity(ListParts, false);
        }

        #region Event Handlers

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
            else if (result == DialogResult.OK)
                bindObjectPartsAsync();
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
            logMessage(msg);

            // Reset the data source for the profiles combobox
            ProfileSettingsBase[] profiles = await bindProfilesAsync();
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
            logMessage(msg);

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
                logMessage(msg);
                return;
            }

            // Persist changes to this AWS credentials profile
            using (new WaitCursor()) {
                AWSCredentialsProfile.Persist(name, e.AccessKeyId, e.SecretAccessKey);
            }
            msg = string.Format(ProfileEdited, name);
            logMessage(msg);

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
            logMessage(msg);

            // If both a credentials profile and a region have been selected then list buckets
            var region = ComboRegions.SelectedItem as RegionEndpoint;
            if (region != null)
                await bindBucketsAsync(profile, region);
        }
        private async void ComboRegions_SelectedIndexChanged(object sender, EventArgs e) {
            // If there is no more selection then just return
            var region = ComboRegions.SelectedItem as RegionEndpoint;
            if (region == null)
                return;

            // Log the new selection
            string msg = string.Format(RegionSelected, region.DisplayName);
            logMessage(msg);

            // If no buckets have been listed yet, and both a credentials profile and a region have been selected,
            // then list buckets
            if (!cvStartUpload.ControlValid(ComboBuckets)) {
                var profile = ComboProfiles.SelectedItem as AWSCredentialsProfile;
                if (profile != null)
                    await bindBucketsAsync(profile, region);
            }
        }
        private void ComboBucket_SelectedIndexChanged(object sender, EventArgs e) {
            // If there is no more selection then just return
            var bucket = ComboBuckets.SelectedItem as S3Bucket;
            if (bucket == null)
                return;

            // Log the new selection
            string msg = string.Format(BucketSelected, bucket.BucketName);
            logMessage(msg);
        }
        private void TxtKey_TextChanged(object sender, EventArgs e) {
            validateKey();
        }
        private void TxtKey_Validating(object sender, System.ComponentModel.CancelEventArgs e) {
            validateKey();
        }
        private void BtnStartPause_Click(object sender, EventArgs e) {
            if (!_uploading)
                resetUploadCtrls(true);

            _paused = !_paused;
            resetUploadPlayPauseCtrls(_paused);
        }
        private void BtnStop_Click(object sender, EventArgs e) {
            resetUploadCtrls(false);
        }
        private void VsmStartUpload_ValidityChanged(object sender, EventArgs e) {
            BtnStartPause.Enabled = cvStartUpload.AllControlsValid;
        }

        #endregion

        // HELPERS
        private async Task<ProfileSettingsBase[]> bindProfilesAsync() {
            // Set up for listing profiles
            string msg = string.Format(ListingProfiles);
            logMessage(msg);
            resetProfiles();

            // List profiles
            ProfileSettingsBase[] profiles;
            profiles = ProfileManager.ListProfiles().ToArray();
            using (new WaitCursor()) {
                profiles = await Task.Run(() => ProfileManager.ListProfiles().ToArray());
            }

            // Adjust controls based on listed profiles
            msg = string.Format(ProfilesListed, profiles.Length);
            logMessage(msg);
            resetProfiles(profiles);

            return profiles;
        }
        private async Task<RegionEndpoint[]> bindRegionsAsync() {
            // Set up for listing S3 regions
            logMessage(ListingS3Regions);
            resetRegions();

            // List regions
            RegionEndpoint[] regions;
            using (new WaitCursor()) {
                regions = await Task.Run(() => RegionEndpoint.EnumerableAllRegions.ToArray());
            }

            // Adjust controls based on listed regions
            string msg = string.Format(S3RegionsListed, regions.Length);
            logMessage(msg);
            resetRegions(regions);

            return regions;
        }
        private async Task<List<S3Bucket>> bindBucketsAsync(AWSCredentialsProfile profile, RegionEndpoint region) {
            // Set up for listing buckets
            string msg = string.Format(ListingBuckets, profile.Name);
            logMessage(msg);
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
                catch (OperationCanceledException) { return buckets; }
                catch (AmazonServiceException ex) {
                    logMessages(ListingBucketsFailed, ex.Message, ex.Source, ex.TargetSite.ToString());
                    logMessages(ex.StackTrace.Split('\n'));
                    return buckets;
                }
            }

            // Adjust controls based on listed buckets
            msg = string.Format(BucketsListed, buckets.Count);
            logMessage(msg);
            resetBuckets(buckets);

            return buckets;
        }
        private async void bindObjectPartsAsync() {
            // Set up for listing object parts
            string path = FolderBrowserParts.SelectedPath;
            logMessage(string.Format(SelectDirectorySuccess, path));
            resetParts();

            // List object parts
            FileInfo[] parts;
            string[] messages = new string[0];
            using (new WaitCursor()) {
                parts = await Task.Run(() => getPartsInDirectory(new DirectoryInfo(path), out messages));
            }

            // Adjust controls based on listed object parts
            logMessages(messages);
            resetParts(parts);
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
            SplitMain.Panel1.Enabled = !uploading;
            ProgressMain.Enabled = uploading;
            BtnStop.Enabled = uploading;
            BtnStartPause.Image = start_resume_upload;
            ToolTipMain.SetToolTip(BtnStartPause, StartUploading);
        }
        private void resetUploadPlayPauseCtrls(bool resuming) {
            BtnStartPause.Image = (resuming ? pause_upload : start_resume_upload);
            ToolTipMain.SetToolTip(BtnStartPause, (resuming ? PauseUploading : ResumeUploading));
        }

        private void validateKey() {
            // Log messages and update the Form's valid state depending on whether the provided S3 key is valid
            string error;
            bool valid = ValidateS3.Key(TxtKey.Text, out error);
            ErrorMain.SetError(TxtKey, error);
            cvStartUpload.MarkValidity(TxtKey, valid);
        }

        #region Log Helpers

        private void logMessage(string message, uint linesBefore = 0, bool showMsgBox = false) {
            logBlanks(linesBefore);
            logMessages(message);

            if (showMsgBox)
                MessageBox.Show(message);
        }
        private void logBlank() {
            logMessages("");
        }
        private void logBlanks(uint numLines) {
            for (int line = 0; line < numLines; ++line)
                logMessages("");
        }
        private void logMessages(params string[] messages) {
            // Enqueue these messages
            foreach (string msg in messages)
                _logQueue.Enqueue(msg);

            // Log all messages currently in the queue
            bool msgLogged = false;
            do {
                string msg;
                msgLogged = _logQueue.TryDequeue(out msg);
                if (msgLogged) {
                    lock (_logLock) {
                        ListLog.Items.Add(msg);
                        autoScrollLogs();
                    }
                }
            } while (msgLogged);
        }
        private void autoScrollLogs() {
            ListLog.SelectedIndex = ListLog.Items.Count - 1;
            ListLog.SelectedIndex = -1;
        }

        #endregion
        
    }

}
