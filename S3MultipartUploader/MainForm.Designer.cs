namespace S3MultipartUploader {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.LblProfile = new System.Windows.Forms.Label();
            this.LblBucket = new System.Windows.Forms.Label();
            this.LblKey = new System.Windows.Forms.Label();
            this.TblLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.SplitMain = new System.Windows.Forms.SplitContainer();
            this.TblLayoutParts = new System.Windows.Forms.TableLayoutPanel();
            this.LblPars = new System.Windows.Forms.Label();
            this.ListParts = new System.Windows.Forms.ListBox();
            this.TblLayoutLogs = new System.Windows.Forms.TableLayoutPanel();
            this.LblLogs = new System.Windows.Forms.Label();
            this.ListLog = new System.Windows.Forms.ListBox();
            this.PnlTop = new System.Windows.Forms.Panel();
            this.BtnEditProfile = new System.Windows.Forms.Button();
            this.BtnDeleteProfile = new System.Windows.Forms.Button();
            this.LblRegion = new System.Windows.Forms.Label();
            this.ComboRegions = new System.Windows.Forms.ComboBox();
            this.BtnAddProfile = new System.Windows.Forms.Button();
            this.BtnOptions = new System.Windows.Forms.Button();
            this.LblChooseDir = new System.Windows.Forms.Label();
            this.ComboProfiles = new System.Windows.Forms.ComboBox();
            this.ComboBuckets = new System.Windows.Forms.ComboBox();
            this.BtnChooseDir = new System.Windows.Forms.Button();
            this.TxtKey = new System.Windows.Forms.TextBox();
            this.PnlBottom = new System.Windows.Forms.Panel();
            this.BtnStop = new System.Windows.Forms.Button();
            this.ProgressMain = new System.Windows.Forms.ProgressBar();
            this.BtnStartPause = new System.Windows.Forms.Button();
            this.CntxtMenuParts = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuItemRestartUpload = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemPauseUpload = new System.Windows.Forms.ToolStripMenuItem();
            this.FolderBrowserParts = new System.Windows.Forms.FolderBrowserDialog();
            this.ErrorMain = new System.Windows.Forms.ErrorProvider(this.components);
            this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
            this.LblAdvanced = new System.Windows.Forms.Label();
            this.cvStartUpload = new S3MultipartUploader.ControlValidator();
            this.TblLayoutMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitMain)).BeginInit();
            this.SplitMain.Panel1.SuspendLayout();
            this.SplitMain.Panel2.SuspendLayout();
            this.SplitMain.SuspendLayout();
            this.TblLayoutParts.SuspendLayout();
            this.TblLayoutLogs.SuspendLayout();
            this.PnlTop.SuspendLayout();
            this.PnlBottom.SuspendLayout();
            this.CntxtMenuParts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorMain)).BeginInit();
            this.SuspendLayout();
            // 
            // LblProfile
            // 
            this.LblProfile.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblProfile.Enabled = false;
            this.LblProfile.Image = ((System.Drawing.Image)(resources.GetObject("LblProfile.Image")));
            this.LblProfile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblProfile.Location = new System.Drawing.Point(68, 6);
            this.LblProfile.Name = "LblProfile";
            this.LblProfile.Size = new System.Drawing.Size(78, 31);
            this.LblProfile.TabIndex = 0;
            this.LblProfile.Text = "Profile:";
            this.LblProfile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ToolTipMain.SetToolTip(this.LblProfile, "Choose one of the AWS credentials profile stored on this machine.");
            // 
            // LblBucket
            // 
            this.LblBucket.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblBucket.Enabled = false;
            this.LblBucket.Image = global::S3MultipartUploader.Properties.Resources.bucket;
            this.LblBucket.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblBucket.Location = new System.Drawing.Point(66, 87);
            this.LblBucket.Name = "LblBucket";
            this.LblBucket.Size = new System.Drawing.Size(80, 33);
            this.LblBucket.TabIndex = 1;
            this.LblBucket.Text = "Bucket:";
            this.LblBucket.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ToolTipMain.SetToolTip(this.LblBucket, "Choose one of the buckets available to the chosen AWS profile.");
            // 
            // LblKey
            // 
            this.LblKey.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblKey.Image = global::S3MultipartUploader.Properties.Resources.s3_key;
            this.LblKey.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblKey.Location = new System.Drawing.Point(71, 128);
            this.LblKey.Name = "LblKey";
            this.LblKey.Size = new System.Drawing.Size(75, 32);
            this.LblKey.TabIndex = 2;
            this.LblKey.Text = "Key:";
            this.LblKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ToolTipMain.SetToolTip(this.LblKey, resources.GetString("LblKey.ToolTip"));
            // 
            // TblLayoutMain
            // 
            this.TblLayoutMain.ColumnCount = 1;
            this.TblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TblLayoutMain.Controls.Add(this.SplitMain, 0, 1);
            this.TblLayoutMain.Controls.Add(this.PnlTop, 0, 0);
            this.TblLayoutMain.Controls.Add(this.PnlBottom, 0, 2);
            this.TblLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TblLayoutMain.Location = new System.Drawing.Point(0, 0);
            this.TblLayoutMain.Name = "TblLayoutMain";
            this.TblLayoutMain.RowCount = 3;
            this.TblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 205F));
            this.TblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.TblLayoutMain.Size = new System.Drawing.Size(585, 603);
            this.TblLayoutMain.TabIndex = 4;
            // 
            // SplitMain
            // 
            this.SplitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitMain.Location = new System.Drawing.Point(3, 205);
            this.SplitMain.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.SplitMain.Name = "SplitMain";
            this.SplitMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitMain.Panel1
            // 
            this.SplitMain.Panel1.Controls.Add(this.TblLayoutParts);
            // 
            // SplitMain.Panel2
            // 
            this.SplitMain.Panel2.Controls.Add(this.TblLayoutLogs);
            this.SplitMain.Size = new System.Drawing.Size(579, 343);
            this.SplitMain.SplitterDistance = 152;
            this.SplitMain.TabIndex = 13;
            // 
            // TblLayoutParts
            // 
            this.TblLayoutParts.ColumnCount = 1;
            this.TblLayoutParts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TblLayoutParts.Controls.Add(this.LblPars, 0, 0);
            this.TblLayoutParts.Controls.Add(this.ListParts, 0, 1);
            this.TblLayoutParts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TblLayoutParts.Enabled = false;
            this.TblLayoutParts.Location = new System.Drawing.Point(0, 0);
            this.TblLayoutParts.Name = "TblLayoutParts";
            this.TblLayoutParts.RowCount = 2;
            this.TblLayoutParts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.TblLayoutParts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TblLayoutParts.Size = new System.Drawing.Size(579, 152);
            this.TblLayoutParts.TabIndex = 1;
            // 
            // LblPars
            // 
            this.LblPars.AutoSize = true;
            this.LblPars.Location = new System.Drawing.Point(3, 0);
            this.LblPars.Name = "LblPars";
            this.LblPars.Size = new System.Drawing.Size(68, 13);
            this.LblPars.TabIndex = 0;
            this.LblPars.Text = "Object Parts:";
            this.ToolTipMain.SetToolTip(this.LblPars, "A list of all the object parts in the selected directory.");
            // 
            // ListParts
            // 
            this.ListParts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListParts.FormattingEnabled = true;
            this.ListParts.Location = new System.Drawing.Point(3, 18);
            this.ListParts.Name = "ListParts";
            this.ListParts.Size = new System.Drawing.Size(573, 131);
            this.ListParts.TabIndex = 1;
            this.ToolTipMain.SetToolTip(this.ListParts, "A list of all the object parts in the selected directory.");
            // 
            // TblLayoutLogs
            // 
            this.TblLayoutLogs.ColumnCount = 1;
            this.TblLayoutLogs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TblLayoutLogs.Controls.Add(this.LblLogs, 0, 0);
            this.TblLayoutLogs.Controls.Add(this.ListLog, 0, 1);
            this.TblLayoutLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TblLayoutLogs.Location = new System.Drawing.Point(0, 0);
            this.TblLayoutLogs.Name = "TblLayoutLogs";
            this.TblLayoutLogs.RowCount = 2;
            this.TblLayoutLogs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.TblLayoutLogs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TblLayoutLogs.Size = new System.Drawing.Size(579, 187);
            this.TblLayoutLogs.TabIndex = 1;
            // 
            // LblLogs
            // 
            this.LblLogs.AutoSize = true;
            this.LblLogs.Location = new System.Drawing.Point(3, 0);
            this.LblLogs.Name = "LblLogs";
            this.LblLogs.Size = new System.Drawing.Size(58, 13);
            this.LblLogs.TabIndex = 0;
            this.LblLogs.Text = "Messages:";
            this.ToolTipMain.SetToolTip(this.LblLogs, "Log messages.");
            // 
            // ListLog
            // 
            this.ListLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListLog.FormattingEnabled = true;
            this.ListLog.HorizontalScrollbar = true;
            this.ListLog.Items.AddRange(new object[] {
            "Welcome to the S3 Multipart Uploader!",
            ""});
            this.ListLog.Location = new System.Drawing.Point(3, 18);
            this.ListLog.Name = "ListLog";
            this.ListLog.ScrollAlwaysVisible = true;
            this.ListLog.Size = new System.Drawing.Size(573, 166);
            this.ListLog.TabIndex = 0;
            this.ToolTipMain.SetToolTip(this.ListLog, "Log messages.");
            // 
            // PnlTop
            // 
            this.PnlTop.Controls.Add(this.LblAdvanced);
            this.PnlTop.Controls.Add(this.BtnEditProfile);
            this.PnlTop.Controls.Add(this.BtnDeleteProfile);
            this.PnlTop.Controls.Add(this.LblRegion);
            this.PnlTop.Controls.Add(this.ComboRegions);
            this.PnlTop.Controls.Add(this.BtnAddProfile);
            this.PnlTop.Controls.Add(this.BtnOptions);
            this.PnlTop.Controls.Add(this.LblChooseDir);
            this.PnlTop.Controls.Add(this.ComboProfiles);
            this.PnlTop.Controls.Add(this.LblProfile);
            this.PnlTop.Controls.Add(this.ComboBuckets);
            this.PnlTop.Controls.Add(this.BtnChooseDir);
            this.PnlTop.Controls.Add(this.TxtKey);
            this.PnlTop.Controls.Add(this.LblBucket);
            this.PnlTop.Controls.Add(this.LblKey);
            this.PnlTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlTop.Location = new System.Drawing.Point(3, 3);
            this.PnlTop.MinimumSize = new System.Drawing.Size(400, 150);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(579, 199);
            this.PnlTop.TabIndex = 0;
            // 
            // BtnEditProfile
            // 
            this.BtnEditProfile.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnEditProfile.AutoSize = true;
            this.BtnEditProfile.Enabled = false;
            this.BtnEditProfile.Image = global::S3MultipartUploader.Properties.Resources.edit_profile;
            this.BtnEditProfile.Location = new System.Drawing.Point(430, 3);
            this.BtnEditProfile.Name = "BtnEditProfile";
            this.BtnEditProfile.Size = new System.Drawing.Size(38, 38);
            this.BtnEditProfile.TabIndex = 9;
            this.ToolTipMain.SetToolTip(this.BtnEditProfile, "Edit the currently selected AWS credentials profile.");
            this.BtnEditProfile.UseVisualStyleBackColor = false;
            this.BtnEditProfile.Click += new System.EventHandler(this.BtnEditProfile_Click);
            // 
            // BtnDeleteProfile
            // 
            this.BtnDeleteProfile.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnDeleteProfile.AutoSize = true;
            this.BtnDeleteProfile.Enabled = false;
            this.BtnDeleteProfile.Image = global::S3MultipartUploader.Properties.Resources.delete_profile;
            this.BtnDeleteProfile.Location = new System.Drawing.Point(474, 3);
            this.BtnDeleteProfile.Name = "BtnDeleteProfile";
            this.BtnDeleteProfile.Size = new System.Drawing.Size(38, 38);
            this.BtnDeleteProfile.TabIndex = 8;
            this.ToolTipMain.SetToolTip(this.BtnDeleteProfile, "Delete the currently selected AWS credentials profile.");
            this.BtnDeleteProfile.UseVisualStyleBackColor = false;
            this.BtnDeleteProfile.Click += new System.EventHandler(this.BtnDeleteProfile_Click);
            // 
            // LblRegion
            // 
            this.LblRegion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblRegion.Image = global::S3MultipartUploader.Properties.Resources.regions;
            this.LblRegion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblRegion.Location = new System.Drawing.Point(68, 45);
            this.LblRegion.Name = "LblRegion";
            this.LblRegion.Size = new System.Drawing.Size(78, 34);
            this.LblRegion.TabIndex = 7;
            this.LblRegion.Text = "Region:";
            this.LblRegion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ToolTipMain.SetToolTip(this.LblRegion, "Choose the AWS region containing the bucket where you want to upload.");
            // 
            // ComboRegions
            // 
            this.ComboRegions.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ComboRegions.DisplayMember = "DisplayName";
            this.ComboRegions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboRegions.FormattingEnabled = true;
            this.ErrorMain.SetIconPadding(this.ComboRegions, 3);
            this.ComboRegions.Location = new System.Drawing.Point(152, 53);
            this.ComboRegions.Name = "ComboRegions";
            this.ComboRegions.Size = new System.Drawing.Size(210, 21);
            this.ComboRegions.TabIndex = 2;
            this.ToolTipMain.SetToolTip(this.ComboRegions, "Choose the AWS region containing the bucket where you want to upload.");
            this.ComboRegions.SelectedIndexChanged += new System.EventHandler(this.ComboRegions_SelectedIndexChanged);
            // 
            // BtnAddProfile
            // 
            this.BtnAddProfile.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnAddProfile.AutoSize = true;
            this.BtnAddProfile.Image = ((System.Drawing.Image)(resources.GetObject("BtnAddProfile.Image")));
            this.BtnAddProfile.Location = new System.Drawing.Point(386, 3);
            this.BtnAddProfile.Name = "BtnAddProfile";
            this.BtnAddProfile.Size = new System.Drawing.Size(38, 38);
            this.BtnAddProfile.TabIndex = 1;
            this.ToolTipMain.SetToolTip(this.BtnAddProfile, "Add a new AWS credentials profile.");
            this.BtnAddProfile.UseVisualStyleBackColor = false;
            this.BtnAddProfile.Click += new System.EventHandler(this.BtnAddProfile_Click);
            // 
            // BtnOptions
            // 
            this.BtnOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnOptions.AutoSize = true;
            this.BtnOptions.Image = global::S3MultipartUploader.Properties.Resources.advanced_options;
            this.BtnOptions.Location = new System.Drawing.Point(476, 156);
            this.BtnOptions.Name = "BtnOptions";
            this.BtnOptions.Size = new System.Drawing.Size(38, 38);
            this.BtnOptions.TabIndex = 6;
            this.ToolTipMain.SetToolTip(this.BtnOptions, "Advanced options.");
            this.BtnOptions.UseVisualStyleBackColor = true;
            this.BtnOptions.Click += new System.EventHandler(this.BtnOptions_Click);
            // 
            // LblChooseDir
            // 
            this.LblChooseDir.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblChooseDir.AutoSize = true;
            this.LblChooseDir.Location = new System.Drawing.Point(203, 174);
            this.LblChooseDir.Name = "LblChooseDir";
            this.LblChooseDir.Size = new System.Drawing.Size(110, 13);
            this.LblChooseDir.TabIndex = 0;
            this.LblChooseDir.Text = "Object Parts Directory";
            this.ToolTipMain.SetToolTip(this.LblChooseDir, "Select the directory containing the parts of the object to upload.");
            // 
            // ComboProfiles
            // 
            this.ComboProfiles.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ComboProfiles.DisplayMember = "Name";
            this.ComboProfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboProfiles.Enabled = false;
            this.ComboProfiles.FormattingEnabled = true;
            this.ErrorMain.SetIconPadding(this.ComboProfiles, 3);
            this.ComboProfiles.Location = new System.Drawing.Point(152, 13);
            this.ComboProfiles.Name = "ComboProfiles";
            this.ComboProfiles.Size = new System.Drawing.Size(210, 21);
            this.ComboProfiles.TabIndex = 0;
            this.ToolTipMain.SetToolTip(this.ComboProfiles, "Choose one of the AWS credentials profile stored on this machine.");
            this.ComboProfiles.SelectedIndexChanged += new System.EventHandler(this.ComboProfile_SelectedIndexChanged);
            // 
            // ComboBuckets
            // 
            this.ComboBuckets.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ComboBuckets.DisplayMember = "BucketName";
            this.ComboBuckets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBuckets.Enabled = false;
            this.ComboBuckets.FormattingEnabled = true;
            this.ErrorMain.SetIconPadding(this.ComboBuckets, 3);
            this.ComboBuckets.Location = new System.Drawing.Point(152, 94);
            this.ComboBuckets.Name = "ComboBuckets";
            this.ComboBuckets.Size = new System.Drawing.Size(210, 21);
            this.ComboBuckets.TabIndex = 3;
            this.ToolTipMain.SetToolTip(this.ComboBuckets, "Choose one of the buckets available to the chosen AWS profile.");
            this.ComboBuckets.SelectedIndexChanged += new System.EventHandler(this.ComboBucket_SelectedIndexChanged);
            // 
            // BtnChooseDir
            // 
            this.BtnChooseDir.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnChooseDir.AutoSize = true;
            this.BtnChooseDir.Location = new System.Drawing.Point(152, 169);
            this.BtnChooseDir.Name = "BtnChooseDir";
            this.BtnChooseDir.Size = new System.Drawing.Size(45, 23);
            this.BtnChooseDir.TabIndex = 5;
            this.BtnChooseDir.Text = "...";
            this.ToolTipMain.SetToolTip(this.BtnChooseDir, "Select the directory containing the parts of the object to upload.");
            this.BtnChooseDir.UseVisualStyleBackColor = true;
            this.BtnChooseDir.Click += new System.EventHandler(this.BtnChooseDir_Click);
            // 
            // TxtKey
            // 
            this.TxtKey.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ErrorMain.SetIconPadding(this.TxtKey, 3);
            this.TxtKey.Location = new System.Drawing.Point(152, 135);
            this.TxtKey.Name = "TxtKey";
            this.TxtKey.Size = new System.Drawing.Size(210, 20);
            this.TxtKey.TabIndex = 4;
            this.ToolTipMain.SetToolTip(this.TxtKey, resources.GetString("TxtKey.ToolTip"));
            this.TxtKey.TextChanged += new System.EventHandler(this.TxtKey_TextChanged);
            this.TxtKey.Validating += new System.ComponentModel.CancelEventHandler(this.TxtKey_Validating);
            // 
            // PnlBottom
            // 
            this.PnlBottom.Controls.Add(this.BtnStop);
            this.PnlBottom.Controls.Add(this.ProgressMain);
            this.PnlBottom.Controls.Add(this.BtnStartPause);
            this.PnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlBottom.Location = new System.Drawing.Point(3, 551);
            this.PnlBottom.Name = "PnlBottom";
            this.PnlBottom.Size = new System.Drawing.Size(579, 49);
            this.PnlBottom.TabIndex = 15;
            // 
            // BtnStop
            // 
            this.BtnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnStop.AutoSize = true;
            this.BtnStop.Enabled = false;
            this.BtnStop.Image = global::S3MultipartUploader.Properties.Resources.stop_upload;
            this.BtnStop.Location = new System.Drawing.Point(538, 3);
            this.BtnStop.Name = "BtnStop";
            this.BtnStop.Size = new System.Drawing.Size(38, 38);
            this.BtnStop.TabIndex = 1;
            this.ToolTipMain.SetToolTip(this.BtnStop, "Abort this multipart upload.");
            this.BtnStop.UseVisualStyleBackColor = true;
            this.BtnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // ProgressMain
            // 
            this.ProgressMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressMain.Enabled = false;
            this.ProgressMain.Location = new System.Drawing.Point(3, 3);
            this.ProgressMain.Name = "ProgressMain";
            this.ProgressMain.Size = new System.Drawing.Size(484, 38);
            this.ProgressMain.TabIndex = 0;
            this.ToolTipMain.SetToolTip(this.ProgressMain, "Upload has not started yet.");
            // 
            // BtnStartPause
            // 
            this.BtnStartPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnStartPause.AutoSize = true;
            this.BtnStartPause.Enabled = false;
            this.BtnStartPause.Image = global::S3MultipartUploader.Properties.Resources.start_resume_upload;
            this.BtnStartPause.Location = new System.Drawing.Point(493, 3);
            this.BtnStartPause.Name = "BtnStartPause";
            this.BtnStartPause.Size = new System.Drawing.Size(39, 38);
            this.BtnStartPause.TabIndex = 0;
            this.ToolTipMain.SetToolTip(this.BtnStartPause, "Start uploading object parts!");
            this.BtnStartPause.UseVisualStyleBackColor = true;
            this.BtnStartPause.Click += new System.EventHandler(this.BtnStartPause_Click);
            // 
            // CntxtMenuParts
            // 
            this.CntxtMenuParts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemRestartUpload,
            this.MenuItemPauseUpload});
            this.CntxtMenuParts.Name = "CntxtMenuParts";
            this.CntxtMenuParts.Size = new System.Drawing.Size(155, 48);
            // 
            // MenuItemRestartUpload
            // 
            this.MenuItemRestartUpload.Name = "MenuItemRestartUpload";
            this.MenuItemRestartUpload.Size = new System.Drawing.Size(154, 22);
            this.MenuItemRestartUpload.Text = "Restart Upload ";
            // 
            // MenuItemPauseUpload
            // 
            this.MenuItemPauseUpload.Name = "MenuItemPauseUpload";
            this.MenuItemPauseUpload.Size = new System.Drawing.Size(154, 22);
            this.MenuItemPauseUpload.Text = "Pause Upload";
            // 
            // FolderBrowserParts
            // 
            this.FolderBrowserParts.Description = "Select a directory containing object parts to upload.";
            this.FolderBrowserParts.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // ErrorMain
            // 
            this.ErrorMain.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.ErrorMain.ContainerControl = this;
            // 
            // LblAdvanced
            // 
            this.LblAdvanced.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LblAdvanced.AutoSize = true;
            this.LblAdvanced.Location = new System.Drawing.Point(520, 169);
            this.LblAdvanced.Name = "LblAdvanced";
            this.LblAdvanced.Size = new System.Drawing.Size(56, 13);
            this.LblAdvanced.TabIndex = 10;
            this.LblAdvanced.Text = "Advanced";
            this.ToolTipMain.SetToolTip(this.LblAdvanced, "Advanced options.");
            // 
            // cvStartUpload
            // 
            this.cvStartUpload.ValidityChanged += new System.EventHandler(this.VsmStartUpload_ValidityChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 603);
            this.Controls.Add(this.TblLayoutMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(480, 620);
            this.Name = "MainForm";
            this.Text = "S3 Multipart Uploader";
            this.TblLayoutMain.ResumeLayout(false);
            this.SplitMain.Panel1.ResumeLayout(false);
            this.SplitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitMain)).EndInit();
            this.SplitMain.ResumeLayout(false);
            this.TblLayoutParts.ResumeLayout(false);
            this.TblLayoutParts.PerformLayout();
            this.TblLayoutLogs.ResumeLayout(false);
            this.TblLayoutLogs.PerformLayout();
            this.PnlTop.ResumeLayout(false);
            this.PnlTop.PerformLayout();
            this.PnlBottom.ResumeLayout(false);
            this.PnlBottom.PerformLayout();
            this.CntxtMenuParts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblProfile;
        private System.Windows.Forms.Label LblBucket;
        private System.Windows.Forms.Label LblKey;
        private System.Windows.Forms.TableLayoutPanel TblLayoutMain;
        private System.Windows.Forms.ComboBox ComboProfiles;
        private System.Windows.Forms.ComboBox ComboBuckets;
        private System.Windows.Forms.TextBox TxtKey;
        private System.Windows.Forms.Panel PnlTop;
        private System.Windows.Forms.Button BtnChooseDir;
        private System.Windows.Forms.Label LblChooseDir;
        private System.Windows.Forms.SplitContainer SplitMain;
        private System.Windows.Forms.ListBox ListLog;
        private System.Windows.Forms.Button BtnOptions;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserParts;
        private System.Windows.Forms.ErrorProvider ErrorMain;
        private System.Windows.Forms.ToolTip ToolTipMain;
        private System.Windows.Forms.Panel PnlBottom;
        private System.Windows.Forms.ProgressBar ProgressMain;
        private System.Windows.Forms.Button BtnStartPause;
        private System.Windows.Forms.ContextMenuStrip CntxtMenuParts;
        private System.Windows.Forms.ToolStripMenuItem MenuItemRestartUpload;
        private System.Windows.Forms.ToolStripMenuItem MenuItemPauseUpload;
        private System.Windows.Forms.Button BtnAddProfile;
        private System.Windows.Forms.Button BtnStop;
        private System.Windows.Forms.Label LblRegion;
        private System.Windows.Forms.ComboBox ComboRegions;
        private System.Windows.Forms.TableLayoutPanel TblLayoutParts;
        private System.Windows.Forms.Label LblPars;
        private System.Windows.Forms.TableLayoutPanel TblLayoutLogs;
        private System.Windows.Forms.Label LblLogs;
        private System.Windows.Forms.ListBox ListParts;
        private System.Windows.Forms.Button BtnDeleteProfile;
        private System.Windows.Forms.Button BtnEditProfile;
        private ControlValidator cvStartUpload;
        private System.Windows.Forms.Label LblAdvanced;
    }
}

