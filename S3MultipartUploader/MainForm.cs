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
        private bool _profileVisited = false;
        private bool _regionVisited = false;
        private bool _bucketVisited = false;
        private bool _keyVistied = false;
        private object _logLock = new object();
        private ConcurrentQueue<string> _logQueue = new ConcurrentQueue<string>();

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

        private void BtnAddProfile_Click_1(object sender, EventArgs e) {
            AddProfileForm f = new AddProfileForm();
            f.ProfileAdded += AddProfileForm_ProfileAdded;
            f.ShowDialog();
        }
        private void AddProfileForm_ProfileAdded(object sender, ProfileEventArgs e) {
            // Persist the new AWS credentials profile!
            toggleWaitState(true);
            persistProfile(e.ProfileName, e.AccessKeyId, e.SecretAccessKey);
            toggleWaitState(false);

            // Log this information
            string msg = string.Format(ProfileAdded, e.ProfileName);
            logMessage(msg, showMsgBox: true);

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

            // If no credentials profile or region has been selected then just return
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

        #endregion

        // HELPERS
        private async void bindRegionsAsync() {
            // Set up for listing S3 regions
            string msg = string.Format(ListingS3Regions);
            logMessage(msg);

            // List regions
            IEnumerable<RegionEndpoint> regions = await Task.Run(() => RegionEndpoint.EnumerableAllRegions);

            // Adjust controls based on listed regions
            msg = string.Format(S3RegionsListed, regions.Count());
            logMessage(msg);
            ComboRegions.DisplayMember = nameof(RegionEndpoint.DisplayName);
            ComboRegions.DataSource = regions;
        }
        private async void bindProfilesAsync() {
            // Set up for listing profiles
            string msg = string.Format(ListingProfiles);
            logMessage(msg);

            // List profiles
            IEnumerable<ProfileSettingsBase> profiles = await Task.Run(() => ProfileManager.ListProfiles());

            // Adjust controls based on listed profiles
            msg = string.Format(ProfilesListed, profiles.Count());
            logMessage(msg);
            ComboProfiles.DisplayMember = nameof(ProfileSettingsBase.Name);
            ComboProfiles.ValueMember = nameof(ProfileSettingsBase.UniqueId);
            ComboProfiles.DataSource = profiles;
        }
        private async void bindBucketsAsync(AWSCredentialsProfile profile, RegionEndpoint region) {
            // Set up for listing buckets
            string msg = string.Format(ListingBuckets, profile.Name);
            logMessage(msg);
            toggleBucketCtrls(false);

            // Asynchronously list buckets available to this profile
            var s3 = new AmazonS3Client(profile.Credentials, region);
            List<S3Bucket> buckets = (await s3.ListBucketsAsync(_cts.Token)).Buckets;

            // Adjust controls based on listed buckets
            msg = string.Format(BucketsListed, buckets.Count);
            logMessage(msg);
            ComboBuckets.DisplayMember = nameof(S3Bucket.BucketName);
            ComboBuckets.DataSource = buckets.ToArray();
            toggleBucketCtrls(true);
            toggleWaitState(false);
        }
        private async void bindObjectPartsAsync() {
            // Set up for listing object parts
            string path = FolderBrowserParts.SelectedPath;
            logMessage(string.Format(SelectDirectorySuccess, path));
            togglePartCtrls(false);

            // List object parts
            string[] messages = new string[0];
            FileInfo[] parts = await Task.Run(() => getPartsInDirectory(new DirectoryInfo(path), out messages));

            // Adjust controls based on listed object parts
            logMessages(messages);
            if (parts.Length > 0) {
                togglePartCtrls(true);
                resetPartCtrls(parts);
            }
        }
        private static void persistProfile(string name, string accessKeyId, string secretKey) {
            AWSCredentialsProfile.Persist(name, accessKeyId, secretKey);
            AWSCredentials creds = ProfileManager.GetAWSCredentials(name);
        }
        private void toggleBucketCtrls(bool enabled) {
            LblBucket.Enabled = enabled;
            ComboBuckets.Enabled = enabled;
        }
        private void togglePartCtrls(bool enabled) {
            TblLayoutParts.Enabled = false;
        }
        private void toggleWaitState(bool waiting) {
            Application.UseWaitCursor = waiting;
        }
        private void resetPartCtrls(IEnumerable<FileInfo> parts) {
            ListParts.Items.AddRange(parts.ToArray());
            TblLayoutParts.Enabled = true;
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

            // Create a log messages according to how many parts were found
            if (numFiles == 0)
                messages = new string[] { NoFilesFound };

            else if (numFiles == 1 && numParts == 0)
                messages = new string[2] { OnlyOneFileFound, OnlyPartsAllowed };

            else if (numFiles == 1 && numParts == 1)
                messages = new string[1] { OnePartFound };

            else if (numParts == 0)
                messages = new string[2] { string.Format(NoPartsFound, numFiles), OnlyPartsAllowed };

            else if (numParts == 1)
                messages = new string[2] { string.Format(OnlyOnePartFound, numFiles), OnlyPartsAllowed };

            else if (numParts < numFiles)
                messages = new string[2] { string.Format(OnlyNPartsFound, numFiles, numParts), OnlyPartsAllowed };
            
            else
                messages = new string[1] { string.Format(NPartsFound, numParts) };

            // Return the object parts as an array
            return parts.ToArray();
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
            BtnStartStop.Enabled = canStart();
        }
        private void validateRegion() {
            _regionVisited = true;

            // If a Region has been chosen then try to enable the Start/Stop button
            // Show or clear the error message accordingly
            string error = (ComboRegions.SelectedIndex == -1) ? MissingRegion : "";
            ErrorMain.SetError(ComboRegions, error);
            BtnStartStop.Enabled = canStart();
        }
        private void validateBucket() {
            _bucketVisited = true;

            // If an S3 Bucket has been chosen then try to enable the Start/Stop button
            // Show or clear the error message accordingly
            string error = (ComboBuckets.SelectedIndex == -1) ? MissingS3Bucket : "";
            ErrorMain.SetError(ComboBuckets, error);
            BtnStartStop.Enabled = canStart();
        }
        private void validateKey() {
            _keyVistied = true;

            // If the provided Name is valid then try to enable the Add button
            // Show or clear the error message accordingly
            string error;
            bool valid = ValidateS3.Key(TxtKey.Text, out error);
            ErrorMain.SetError(TxtKey, error);
            BtnStartStop.Enabled = canStart();
        }
        private bool canStart() {
            // If there are any outstanding errors on the Form, then we cannot start uploading
            bool noErrors = (
                _profileVisited && ErrorMain.GetError(ComboProfiles) == "" &&
                _regionVisited  && ErrorMain.GetError(ComboRegions) == "" &&
                _bucketVisited  && ErrorMain.GetError(ComboBuckets) == "" &&
                _keyVistied     && ErrorMain.GetError(TxtKey) == "");

            // If no parts have been added then we certainly cannot start uploading!
            bool partsAdded = (ListParts.Items.Count > 0);

            return noErrors && partsAdded;
        }

        #endregion

    }

}
