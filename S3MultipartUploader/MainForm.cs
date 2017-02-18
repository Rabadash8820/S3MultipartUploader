using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
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
        private CancellationTokenSource _cts = new CancellationTokenSource();
        private uint _numTabs = 0;

        public MainForm() {
            InitializeComponent();

            // Bind data
            bindRegions();
            deltaTabs(-1);
            bindProfiles();
            deltaTabs(-1);
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
                resetPartCtrls();
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
            // Persist the new AWS credentials profile!
            toggleWaitState(true);
            persistProfile(e.ProfileName, e.AccessKeyId, e.SecretAccessKey);
            toggleWaitState(false);

            // Log this information
            string msg = string.Format(ProfileAdded, e.ProfileName);
            logMessage(msg, showMsgBox: true);

            // Reset the data source for the profiles combobox
            bindProfiles();
        }
        private void ComboProfile_SelectedIndexChanged(object sender, EventArgs e) {
            // Log the new selection
            var profile = ComboProfile.SelectedItem as AWSCredentialsProfile;
            string msg = string.Format(ProfileSelected, profile.Name);
            logMessage(msg);
            deltaTabs(1);

            // Try to bind the buckets available to this profile to the buckets combobox
            var region = ComboRegions.SelectedItem as RegionEndpoint;
            tryBindBuckets(profile, region);
            deltaTabs(-1);
        }
        private void ComboRegions_SelectedIndexChanged(object sender, EventArgs e) {
            // Log the new selection
            var region = ComboRegions.SelectedItem as RegionEndpoint;
            string msg = string.Format(RegionSelected, region.DisplayName);
            logMessage(msg);
        }
        private void ComboBucket_SelectedIndexChanged(object sender, EventArgs e) {
            // Log the new selection
            var bucket = ComboBucket.SelectedItem as S3Bucket;
            string msg = string.Format(BucketSelected, bucket.BucketName);
            logMessage(msg);
        }

        // HELPERS
        private void bindRegions() {
            // Set up for listing S3 regions
            string msg = string.Format(ListingS3Regions);
            logMessage(msg);

            // List regions
            IEnumerable<RegionEndpoint> regions = RegionEndpoint.EnumerableAllRegions;

            // Adjust controls based on listed regions
            deltaTabs(1);
            msg = string.Format(S3RegionsListed, regions.Count());
            logMessage(msg);
            ComboRegions.DataSource = regions;
            ComboRegions.DisplayMember = nameof(RegionEndpoint.DisplayName);
            deltaTabs(-1);
        }
        private void bindProfiles() {
            // Set up for listing profiles
            string msg = string.Format(ListingProfiles);
            logMessage(msg);

            // List profiles
            IEnumerable<ProfileSettingsBase> profiles = ProfileManager.ListProfiles();

            // Adjust controls based on listed profiles
            deltaTabs(1);
            msg = string.Format(ProfilesListed, profiles.Count());
            logMessage(msg);
            deltaTabs(-1);
            ComboProfile.DataSource = profiles;
            ComboProfile.DisplayMember = nameof(ProfileSettingsBase.Name);
            ComboProfile.ValueMember = nameof(ProfileSettingsBase.UniqueId);
        }
        private async void tryBindBuckets(AWSCredentialsProfile profile, RegionEndpoint region) {
            // If no credentials profile or region has been selected then just return
            if (profile == null || region == null)
                return;

            // Set up for listing buckets
            var s3 = new AmazonS3Client(profile.Credentials, region);
            string msg = string.Format(ListingBuckets, profile.Name);
            logMessage(msg);
            toggleBucketCtrls(false);

            // Asynchronously list buckets available to this profile
            List<S3Bucket> buckets = (await s3.ListBucketsAsync(_cts.Token)).Buckets;

            // Adjust controls based on listed buckets
            deltaTabs(1);
            msg = string.Format(BucketsListed, buckets.Count);
            logMessage(msg);
            ComboBucket.DataSource = buckets.ToArray();
            ComboBucket.DisplayMember = nameof(S3Bucket.BucketName);
            deltaTabs(-1);
            toggleBucketCtrls(true);
            toggleWaitState(false);
        }
        private static void persistProfile(string name, string accessKeyId, string secretKey) {
            AWSCredentialsProfile.Persist(name, accessKeyId, secretKey);
            AWSCredentials creds = ProfileManager.GetAWSCredentials(name);
        }
        private void toggleBucketCtrls(bool enabled) {
            LblBucket.Enabled = enabled;
            ComboBucket.Enabled = enabled;
        }
        private void toggleWaitState(bool waiting) {
            Application.UseWaitCursor = waiting;
        }
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
            string tabs = new string(' ', 4 * (int)_numTabs);
            foreach (string msg in messages)
                ListLog.Items.Add(tabs + msg);
            autoScrollLogs();
        }
        private void autoScrollLogs() {
            ListLog.SelectedIndex = ListLog.Items.Count - 1;
            ListLog.SelectedIndex = -1;
        }
        private void deltaTabs(int delta) {
            long newTabs = _numTabs + delta;
            _numTabs = (uint)Math.Max(0L, newTabs);
        }
        private void resetPartCtrls() {
            ListParts.Items.Clear();
            TblLayoutParts.Enabled = false;
        }
        private void resetPartCtrls(IEnumerable<FileInfo> parts) {
            ListParts.Items.AddRange(parts.ToArray());
            TblLayoutParts.Enabled = true;
        }
        private void getPartsInDirectory(DirectoryInfo dir) {
            // Get the number of object parts and total files in this Directory
            IEnumerable<FileInfo> files = dir.EnumerateFiles().Where(f => 
                                                                    !f.Attributes.HasFlag(FileAttributes.System) &&
                                                                    !f.Attributes.HasFlag(FileAttributes.Hidden));
            IEnumerable<FileInfo> parts = files.Where(f => { double result; return double.TryParse(f.Extension, out result); });
            int numFiles = files.Count();
            int numParts = parts.Count();

            // Create a log messages according to how many parts were found
            string[] messages;
            if (numFiles == 0)
                messages = new string[] { NoFilesFound };

            else if (numFiles == 1 && numParts == 0)
                messages = new string[2] { OnlyOneFileFound, OnlyPartsAllowed };

            else if (numFiles == 1 && numParts == 1) {
                messages = new string[1] { OnePartFound };
                resetPartCtrls(parts);
            }

            else if (numParts == 0)
                messages = new string[2] { string.Format(NoPartsFound, numFiles), OnlyPartsAllowed };

            else if (numParts == 1)
                messages = new string[2] { string.Format(OnlyOnePartFound, numFiles), OnlyPartsAllowed };

            else if (numParts < numFiles)
                messages = new string[2] { string.Format(OnlyNPartsFound, numFiles, numParts), OnlyPartsAllowed };
            
            else {
                messages = new string[1] { string.Format(NPartsFound, numParts) };
                resetPartCtrls(parts);
            }

            // Log messages and part names accordingly
            deltaTabs(1);
            logMessages(messages);
            deltaTabs(-1);
        }
    }

}
