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
        private CancellationTokenSource _cts = new CancellationTokenSource();
        private object _logLock = new object();
        private ConcurrentQueue<string> _logQueue = new ConcurrentQueue<string>();
        private bool _uploading = false;
        private bool _paused = false;

        private bool _profileVisited = false;
        private bool _regionVisited = false;
        private bool _bucketVisited = false;
        private bool _keyVistied = false;
        private bool _partsVisited = false;

        public MainForm() {
            InitializeComponent();

            // Bind data
            bindRegionsAsync();
            bindProfilesAsync();
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
        private void SaveProfileForm_ProfileAdded(object sender, ProfileEventArgs e) {
            // Persist the new AWS credentials profile!
            using (new WaitCursor()) {
                ProfileManager.RegisterProfile(e.ProfileName, e.AccessKeyId, e.SecretAccessKey);
            }

            // Log this information
            string msg = string.Format(ProfileAdded, e.ProfileName);
            logMessage(msg);

            // Reset the data source for the profiles combobox
            // and select the profile that was just added
            bindProfilesAsync(true);
        }
        private void SaveProfileForm_ProfileEdited(object sender, ProfileEventArgs e) {
            // Persist changes to this AWS credentials profile
            using (new WaitCursor()) {
                AWSCredentialsProfile.Persist(e.ProfileName, e.AccessKeyId, e.SecretAccessKey);
            }

            // Log this information
            string msg = string.Format(ProfileEdited, e.ProfileName);
            logMessage(msg);

            // Reset the data source for the profiles combobox
            bindProfilesAsync();
        }
        private void BtnDeleteProfile_Click(object sender, EventArgs e) {
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
            bindProfilesAsync();
        }
        private void ComboProfile_SelectedIndexChanged(object sender, EventArgs e) {
            // Log the new selection
            var profile = ComboProfiles.SelectedItem as AWSCredentialsProfile;
            string msg = string.Format(ProfileSelected, profile.Name);
            logMessage(msg);

            // Validate this selection to see if we can start uploading
            validateProfile();

            // If both a credentials profile and a region have been selected then list buckets
            var region = ComboRegions.SelectedItem as RegionEndpoint;
            if (region != null) {
                bindBucketsAsync(profile, region);
            }
        }
        private void ComboRegions_SelectedIndexChanged(object sender, EventArgs e) {
            // Log the new selection
            var region = ComboRegions.SelectedItem as RegionEndpoint;
            string msg = string.Format(RegionSelected, region.DisplayName);
            logMessage(msg);

            // Validate this selection to see if we can start uploading
            validateRegion();
        }
        private void ComboBucket_SelectedIndexChanged(object sender, EventArgs e) {
            // Log the new selection
            var bucket = ComboBuckets.SelectedItem as S3Bucket;
            string msg = string.Format(BucketSelected, bucket.BucketName);
            logMessage(msg);

            // Validate this selection to see if we can start uploading
            validateBucket();
        }
        private void ComboProfile_Validating(object sender, System.ComponentModel.CancelEventArgs e) {
            validateProfile();
        }
        private void ComboRegions_Validating(object sender, System.ComponentModel.CancelEventArgs e) {
            validateRegion();
        }
        private void ComboBucket_Validating(object sender, System.ComponentModel.CancelEventArgs e) {
            validateBucket();
        }
        private void TxtKey_TextChanged(object sender, EventArgs e) {
            validateKey();
        }
        private void TxtKey_Validating(object sender, System.ComponentModel.CancelEventArgs e) {
            validateKey();
        }
        private void BtnStartPause_Click(object sender, EventArgs e) {
            if (!_uploading)
                toggleUploadCtrls(true);

            _paused = !_paused;
            toggleUploadPlayPauseCtrls(_paused);
        }
        private void BtnStop_Click(object sender, EventArgs e) {
            toggleUploadCtrls(false);
        }

        #endregion

        // HELPERS
        private async void bindRegionsAsync() {
            // Set up for listing S3 regions
            string msg = string.Format(ListingS3Regions);
            logMessage(msg);

            // List regions
            IEnumerable<RegionEndpoint> regions;
            using (new WaitCursor()) {
                regions = await Task.Run(() => RegionEndpoint.EnumerableAllRegions);
            }

            // Adjust controls based on listed regions
            msg = string.Format(S3RegionsListed, regions.Count());
            logMessage(msg);
            ComboRegions.DataSource = regions;
        }
        private async void bindProfilesAsync(bool selectLast = false) {
            // Set up for listing profiles
            string msg = string.Format(ListingProfiles);
            logMessage(msg);

            // List profiles
            IEnumerable<ProfileSettingsBase> profiles;
            using (new WaitCursor()) {
                profiles = await Task.Run(() => ProfileManager.ListProfiles());
            }

            // Adjust controls based on listed profiles
            int numProfiles = profiles.Count();
            msg = string.Format(ProfilesListed, numProfiles);
            logMessage(msg);
            ComboProfiles.DataSource = profiles;
            if (selectLast)
                ComboProfiles.SelectedIndex = ComboProfiles.Items.Count - 1;
            toggleProfileCtrls(numProfiles > 0);
        }
        private async void bindBucketsAsync(AWSCredentialsProfile profile, RegionEndpoint region) {
            // Set up for listing buckets
            string msg = string.Format(ListingBuckets, profile.Name);
            logMessage(msg);
            toggleBucketCtrls(false);

            // Asynchronously list buckets available to this profile
            var s3 = new AmazonS3Client(profile.Credentials, region);
            List<S3Bucket> buckets;
            using (new WaitCursor()) {
                buckets = (await s3.ListBucketsAsync(_cts.Token)).Buckets;
            }

            // Adjust controls based on listed buckets
            msg = string.Format(BucketsListed, buckets.Count);
            logMessage(msg);
            ComboBuckets.DataSource = buckets.ToArray();
            toggleBucketCtrls(true);
        }
        private async void bindObjectPartsAsync() {
            // Set up for listing object parts
            string path = FolderBrowserParts.SelectedPath;
            logMessage(string.Format(SelectDirectorySuccess, path));
            resetParts();
            togglePartCtrls(false);

            // List object parts
            string[] logMsgs = new string[0], errMsgs = new string[0];
            FileInfo[] parts;
            using (new WaitCursor()) {
                parts = await Task.Run(() => getPartsInDirectory(new DirectoryInfo(path), out logMsgs, out errMsgs));
            }

            // Adjust controls based on listed object parts
            logMessages(logMsgs);
            logMessages(errMsgs);
            bool noErrs = (errMsgs.Length == 0);
            togglePartCtrls(noErrs);
            if (noErrs)
                resetParts(parts);
            validateParts();
        }
        private FileInfo[] getPartsInDirectory(DirectoryInfo dir, out string[] logMsgs, out string[] errorMsgs) {
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
            List<string> logs = new List<string>(1);
            List<string> errs = new List<string>(2);

            // Create a log messages according to how many parts were found
            if (numFiles == 0)
                errs.Add(NoFilesFound);

            else if (numFiles == 1 && numParts == 0) {
                errs.Add(OnlyOneFileFound);
                errs.Add(OnlyPartsAllowed);
            }

            else if (numFiles == 1 && numParts == 1)
                logs.Add(OnePartFound);

            else if (numParts == 0) {
                errs.Add(string.Format(NoPartsFound, numFiles));
                errs.Add(OnlyPartsAllowed);
            }

            else if (numParts == 1) {
                errs.Add(string.Format(OnlyOnePartFound, numFiles));
                errs.Add(OnlyPartsAllowed);
            }

            else if (numParts < numFiles) {
                errs.Add(string.Format(OnlyNPartsFound, numFiles, numParts));
                errs.Add(OnlyPartsAllowed);
            }

            else
                logs.Add(string.Format(NPartsFound, numParts));

            // Return the object parts and log/error messages
            logMsgs = logs.ToArray();
            errorMsgs = errs.ToArray();
            return parts.ToArray();
        }

        private void toggleProfileCtrls(bool enabled) {
            BtnEditProfile.Enabled = enabled;
            BtnDeleteProfile.Enabled = enabled;
        }
        private void toggleBucketCtrls(bool enabled) {
            LblBucket.Enabled = enabled;
            ComboBuckets.Enabled = enabled;
        }
        private void togglePartCtrls(bool enabled) {
            TblLayoutParts.Enabled = enabled;
        }
        private void toggleUploadCtrls(bool uploading) {
            PnlTop.Enabled = !uploading;
            SplitMain.Panel1.Enabled = !uploading;
            ProgressMain.Enabled = uploading;
            BtnStop.Enabled = uploading;
            BtnStartPause.Image = start_resume_upload;
            ToolTipMain.SetToolTip(BtnStartPause, StartUploading);
        }
        private void toggleUploadPlayPauseCtrls(bool resuming) {
            BtnStartPause.Image = (resuming ? pause_upload : start_resume_upload);
            ToolTipMain.SetToolTip(BtnStartPause, (resuming ? PauseUploading : ResumeUploading));
        }
        private void resetParts(IEnumerable<FileInfo> parts = null) {
            ListParts.Items.Clear();
            if (parts != null)
                ListParts.Items.AddRange(parts?.ToArray());
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

        #region Validation Helpers

        private void validateProfile() {
            _profileVisited = true;

            // If a Profile has been chosen then try to enable the Start/Stop button
            // Show or clear the error message accordingly
            string error = (ComboProfiles.SelectedIndex == -1) ? MissingProfile : "";
            ErrorMain.SetError(ComboProfiles, error);
            BtnStartPause.Enabled = canStart();
        }
        private void validateRegion() {
            _regionVisited = true;

            // If a Region has been chosen then try to enable the Start/Stop button
            // Show or clear the error message accordingly
            string error = (ComboRegions.SelectedIndex == -1) ? MissingRegion : "";
            ErrorMain.SetError(ComboRegions, error);
            BtnStartPause.Enabled = canStart();
        }
        private void validateBucket() {
            _bucketVisited = true;

            // If an S3 Bucket has been chosen then try to enable the Start/Stop button
            // Show or clear the error message accordingly
            string error = (ComboBuckets.SelectedIndex == -1) ? MissingS3Bucket : "";
            ErrorMain.SetError(ComboBuckets, error);
            BtnStartPause.Enabled = canStart();
        }
        private void validateKey() {
            _keyVistied = true;

            // If the provided Name is valid then try to enable the Add button
            // Show or clear the error message accordingly
            string error;
            ValidateS3.Key(TxtKey.Text, out error);
            ErrorMain.SetError(TxtKey, error);
            BtnStartPause.Enabled = canStart();
        }
        private void validateParts() {
            _partsVisited = true;
            BtnStartPause.Enabled = canStart();
        }
        private bool canStart() {
            // If there are no outstanding errors on the Form and some parts have been added,
            // then enable the start uploading button!
            bool allGood = (
                _profileVisited && ErrorMain.GetError(ComboProfiles) == "" &&
                _regionVisited && ErrorMain.GetError(ComboRegions) == "" &&
                _bucketVisited && ErrorMain.GetError(ComboBuckets) == "" &&
                _keyVistied && ErrorMain.GetError(TxtKey) == "" &&
                _partsVisited && ListParts.Items.Count > 0);

            return allGood;
        }

        #endregion

    }

}
