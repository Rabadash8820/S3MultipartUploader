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
            this.LblProfile = new System.Windows.Forms.Label();
            this.LblBucket = new System.Windows.Forms.Label();
            this.LblKey = new System.Windows.Forms.Label();
            this.TblLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.SplitOuter = new System.Windows.Forms.SplitContainer();
            this.ListLog = new System.Windows.Forms.ListBox();
            this.PnlTop = new System.Windows.Forms.Panel();
            this.BtnOptions = new System.Windows.Forms.Button();
            this.LblChooseDir = new System.Windows.Forms.Label();
            this.ComboProfile = new System.Windows.Forms.ComboBox();
            this.ComboBucket = new System.Windows.Forms.ComboBox();
            this.BtnChooseDir = new System.Windows.Forms.Button();
            this.TxtKey = new System.Windows.Forms.TextBox();
            this.PnlBottom = new System.Windows.Forms.Panel();
            this.ProgressMain = new System.Windows.Forms.ProgressBar();
            this.BtnStartStop = new System.Windows.Forms.Button();
            this.FolderBrowserParts = new System.Windows.Forms.FolderBrowserDialog();
            this.ErrorProviderMain = new System.Windows.Forms.ErrorProvider(this.components);
            this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
            this.BtnAddProfile = new System.Windows.Forms.Button();
            this.CntxtMenuParts = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.restartPartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseUploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ListParts = new System.Windows.Forms.CheckedListBox();
            this.TblLayoutMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitOuter)).BeginInit();
            this.SplitOuter.Panel1.SuspendLayout();
            this.SplitOuter.Panel2.SuspendLayout();
            this.SplitOuter.SuspendLayout();
            this.PnlTop.SuspendLayout();
            this.PnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProviderMain)).BeginInit();
            this.CntxtMenuParts.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblProfile
            // 
            this.LblProfile.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblProfile.AutoSize = true;
            this.LblProfile.Location = new System.Drawing.Point(50, 12);
            this.LblProfile.Name = "LblProfile";
            this.LblProfile.Size = new System.Drawing.Size(36, 13);
            this.LblProfile.TabIndex = 0;
            this.LblProfile.Text = "Profile";
            this.ToolTipMain.SetToolTip(this.LblProfile, "Choose one of the AWS credentials profile already stored on this machine.");
            // 
            // LblBucket
            // 
            this.LblBucket.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblBucket.AutoSize = true;
            this.LblBucket.Enabled = false;
            this.LblBucket.Location = new System.Drawing.Point(45, 39);
            this.LblBucket.Name = "LblBucket";
            this.LblBucket.Size = new System.Drawing.Size(41, 13);
            this.LblBucket.TabIndex = 1;
            this.LblBucket.Text = "Bucket";
            this.ToolTipMain.SetToolTip(this.LblBucket, "Choose one of the buckets available to the chosen AWS profile.");
            // 
            // LblKey
            // 
            this.LblKey.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblKey.AutoSize = true;
            this.LblKey.Location = new System.Drawing.Point(61, 66);
            this.LblKey.Name = "LblKey";
            this.LblKey.Size = new System.Drawing.Size(25, 13);
            this.LblKey.TabIndex = 2;
            this.LblKey.Text = "Key";
            this.ToolTipMain.SetToolTip(this.LblKey, "The unique key where this object will be stored in the S3 bucket.");
            // 
            // TblLayoutMain
            // 
            this.TblLayoutMain.ColumnCount = 1;
            this.TblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TblLayoutMain.Controls.Add(this.SplitOuter, 0, 1);
            this.TblLayoutMain.Controls.Add(this.PnlTop, 0, 0);
            this.TblLayoutMain.Controls.Add(this.PnlBottom, 0, 2);
            this.TblLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TblLayoutMain.Location = new System.Drawing.Point(0, 0);
            this.TblLayoutMain.Name = "TblLayoutMain";
            this.TblLayoutMain.RowCount = 3;
            this.TblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.TblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.TblLayoutMain.Size = new System.Drawing.Size(409, 581);
            this.TblLayoutMain.TabIndex = 4;
            // 
            // SplitOuter
            // 
            this.SplitOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitOuter.Location = new System.Drawing.Point(3, 160);
            this.SplitOuter.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.SplitOuter.Name = "SplitOuter";
            this.SplitOuter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitOuter.Panel1
            // 
            this.SplitOuter.Panel1.Controls.Add(this.ListParts);
            // 
            // SplitOuter.Panel2
            // 
            this.SplitOuter.Panel2.Controls.Add(this.ListLog);
            this.SplitOuter.Size = new System.Drawing.Size(403, 386);
            this.SplitOuter.SplitterDistance = 168;
            this.SplitOuter.TabIndex = 13;
            // 
            // ListLog
            // 
            this.ListLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListLog.FormattingEnabled = true;
            this.ListLog.Items.AddRange(new object[] {
            "Welcome to the S3 Multipart Uploader!",
            ""});
            this.ListLog.Location = new System.Drawing.Point(0, 0);
            this.ListLog.Name = "ListLog";
            this.ListLog.ScrollAlwaysVisible = true;
            this.ListLog.Size = new System.Drawing.Size(403, 214);
            this.ListLog.TabIndex = 0;
            // 
            // PnlTop
            // 
            this.PnlTop.Controls.Add(this.BtnAddProfile);
            this.PnlTop.Controls.Add(this.BtnOptions);
            this.PnlTop.Controls.Add(this.LblChooseDir);
            this.PnlTop.Controls.Add(this.ComboProfile);
            this.PnlTop.Controls.Add(this.LblProfile);
            this.PnlTop.Controls.Add(this.ComboBucket);
            this.PnlTop.Controls.Add(this.BtnChooseDir);
            this.PnlTop.Controls.Add(this.TxtKey);
            this.PnlTop.Controls.Add(this.LblBucket);
            this.PnlTop.Controls.Add(this.LblKey);
            this.PnlTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlTop.Location = new System.Drawing.Point(3, 3);
            this.PnlTop.MinimumSize = new System.Drawing.Size(400, 150);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(403, 154);
            this.PnlTop.TabIndex = 0;
            // 
            // BtnOptions
            // 
            this.BtnOptions.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnOptions.AutoSize = true;
            this.BtnOptions.Location = new System.Drawing.Point(92, 118);
            this.BtnOptions.Name = "BtnOptions";
            this.BtnOptions.Size = new System.Drawing.Size(75, 23);
            this.BtnOptions.TabIndex = 5;
            this.BtnOptions.Text = "Advanced...";
            this.ToolTipMain.SetToolTip(this.BtnOptions, "Advanced options.");
            this.BtnOptions.UseVisualStyleBackColor = true;
            this.BtnOptions.Click += new System.EventHandler(this.BtnOptions_Click);
            // 
            // LblChooseDir
            // 
            this.LblChooseDir.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblChooseDir.AutoSize = true;
            this.LblChooseDir.Location = new System.Drawing.Point(143, 94);
            this.LblChooseDir.Name = "LblChooseDir";
            this.LblChooseDir.Size = new System.Drawing.Size(107, 13);
            this.LblChooseDir.TabIndex = 0;
            this.LblChooseDir.Text = "Object parts directory";
            // 
            // ComboProfile
            // 
            this.ComboProfile.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ComboProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboProfile.FormattingEnabled = true;
            this.ComboProfile.Location = new System.Drawing.Point(92, 9);
            this.ComboProfile.Name = "ComboProfile";
            this.ComboProfile.Size = new System.Drawing.Size(210, 21);
            this.ComboProfile.TabIndex = 0;
            this.ToolTipMain.SetToolTip(this.ComboProfile, "Choose one of the AWS credentials profile already stored on this machine.");
            // 
            // ComboBucket
            // 
            this.ComboBucket.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ComboBucket.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBucket.Enabled = false;
            this.ComboBucket.FormattingEnabled = true;
            this.ComboBucket.Location = new System.Drawing.Point(92, 36);
            this.ComboBucket.Name = "ComboBucket";
            this.ComboBucket.Size = new System.Drawing.Size(210, 21);
            this.ComboBucket.TabIndex = 2;
            this.ToolTipMain.SetToolTip(this.ComboBucket, "Choose one of the buckets available to the chosen AWS profile.");
            // 
            // BtnChooseDir
            // 
            this.BtnChooseDir.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnChooseDir.AutoSize = true;
            this.BtnChooseDir.Location = new System.Drawing.Point(92, 89);
            this.BtnChooseDir.Name = "BtnChooseDir";
            this.BtnChooseDir.Size = new System.Drawing.Size(45, 23);
            this.BtnChooseDir.TabIndex = 4;
            this.BtnChooseDir.Text = "...";
            this.ToolTipMain.SetToolTip(this.BtnChooseDir, "Select the directory containing this object\'s parts.");
            this.BtnChooseDir.UseVisualStyleBackColor = true;
            this.BtnChooseDir.Click += new System.EventHandler(this.BtnChooseDir_Click);
            // 
            // TxtKey
            // 
            this.TxtKey.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtKey.Location = new System.Drawing.Point(92, 63);
            this.TxtKey.Name = "TxtKey";
            this.TxtKey.Size = new System.Drawing.Size(210, 20);
            this.TxtKey.TabIndex = 3;
            this.ToolTipMain.SetToolTip(this.TxtKey, "The unique key where this object will be stored in the S3 bucket.");
            // 
            // PnlBottom
            // 
            this.PnlBottom.Controls.Add(this.ProgressMain);
            this.PnlBottom.Controls.Add(this.BtnStartStop);
            this.PnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlBottom.Location = new System.Drawing.Point(3, 549);
            this.PnlBottom.Name = "PnlBottom";
            this.PnlBottom.Size = new System.Drawing.Size(403, 29);
            this.PnlBottom.TabIndex = 15;
            // 
            // ProgressMain
            // 
            this.ProgressMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressMain.Enabled = false;
            this.ProgressMain.Location = new System.Drawing.Point(3, 3);
            this.ProgressMain.Name = "ProgressMain";
            this.ProgressMain.Size = new System.Drawing.Size(316, 23);
            this.ProgressMain.TabIndex = 0;
            this.ToolTipMain.SetToolTip(this.ProgressMain, "Upload has not started yet.");
            // 
            // BtnStartStop
            // 
            this.BtnStartStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnStartStop.AutoSize = true;
            this.BtnStartStop.Enabled = false;
            this.BtnStartStop.Location = new System.Drawing.Point(325, 3);
            this.BtnStartStop.Name = "BtnStartStop";
            this.BtnStartStop.Size = new System.Drawing.Size(75, 23);
            this.BtnStartStop.TabIndex = 1;
            this.BtnStartStop.Text = "Start";
            this.ToolTipMain.SetToolTip(this.BtnStartStop, "Begin uploading object parts!");
            this.BtnStartStop.UseVisualStyleBackColor = true;
            // 
            // FolderBrowserParts
            // 
            this.FolderBrowserParts.Description = "Select a directory containing object parts to upload.";
            this.FolderBrowserParts.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // ErrorProviderMain
            // 
            this.ErrorProviderMain.ContainerControl = this;
            // 
            // BtnAddProfile
            // 
            this.BtnAddProfile.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnAddProfile.AutoSize = true;
            this.BtnAddProfile.Location = new System.Drawing.Point(308, 7);
            this.BtnAddProfile.Name = "BtnAddProfile";
            this.BtnAddProfile.Size = new System.Drawing.Size(49, 23);
            this.BtnAddProfile.TabIndex = 1;
            this.BtnAddProfile.Text = "Add";
            this.ToolTipMain.SetToolTip(this.BtnAddProfile, "Add a new AWS credentials profile.");
            this.BtnAddProfile.UseVisualStyleBackColor = true;
            this.BtnAddProfile.Click += new System.EventHandler(this.BtnAddProfile_Click);
            // 
            // CntxtMenuParts
            // 
            this.CntxtMenuParts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restartPartToolStripMenuItem,
            this.pauseUploadToolStripMenuItem});
            this.CntxtMenuParts.Name = "CntxtMenuParts";
            this.CntxtMenuParts.Size = new System.Drawing.Size(155, 48);
            // 
            // restartPartToolStripMenuItem
            // 
            this.restartPartToolStripMenuItem.Name = "restartPartToolStripMenuItem";
            this.restartPartToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.restartPartToolStripMenuItem.Text = "Restart Upload ";
            // 
            // pauseUploadToolStripMenuItem
            // 
            this.pauseUploadToolStripMenuItem.Name = "pauseUploadToolStripMenuItem";
            this.pauseUploadToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.pauseUploadToolStripMenuItem.Text = "Pause Upload";
            // 
            // ListParts
            // 
            this.ListParts.ContextMenuStrip = this.CntxtMenuParts;
            this.ListParts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListParts.Enabled = false;
            this.ListParts.FormattingEnabled = true;
            this.ListParts.Location = new System.Drawing.Point(0, 0);
            this.ListParts.Name = "ListParts";
            this.ListParts.ScrollAlwaysVisible = true;
            this.ListParts.Size = new System.Drawing.Size(403, 168);
            this.ListParts.TabIndex = 17;
            this.ListParts.ThreeDCheckBoxes = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 581);
            this.Controls.Add(this.TblLayoutMain);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(425, 620);
            this.Name = "MainForm";
            this.Text = "S3 Multipart Uploader";
            this.TblLayoutMain.ResumeLayout(false);
            this.SplitOuter.Panel1.ResumeLayout(false);
            this.SplitOuter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitOuter)).EndInit();
            this.SplitOuter.ResumeLayout(false);
            this.PnlTop.ResumeLayout(false);
            this.PnlTop.PerformLayout();
            this.PnlBottom.ResumeLayout(false);
            this.PnlBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProviderMain)).EndInit();
            this.CntxtMenuParts.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblProfile;
        private System.Windows.Forms.Label LblBucket;
        private System.Windows.Forms.Label LblKey;
        private System.Windows.Forms.TableLayoutPanel TblLayoutMain;
        private System.Windows.Forms.ComboBox ComboProfile;
        private System.Windows.Forms.ComboBox ComboBucket;
        private System.Windows.Forms.TextBox TxtKey;
        private System.Windows.Forms.Panel PnlTop;
        private System.Windows.Forms.Button BtnChooseDir;
        private System.Windows.Forms.Label LblChooseDir;
        private System.Windows.Forms.SplitContainer SplitOuter;
        private System.Windows.Forms.ListBox ListLog;
        private System.Windows.Forms.Button BtnOptions;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserParts;
        private System.Windows.Forms.ErrorProvider ErrorProviderMain;
        private System.Windows.Forms.ToolTip ToolTipMain;
        private System.Windows.Forms.Panel PnlBottom;
        private System.Windows.Forms.ProgressBar ProgressMain;
        private System.Windows.Forms.Button BtnStartStop;
        private System.Windows.Forms.Button BtnAddProfile;
        private System.Windows.Forms.ContextMenuStrip CntxtMenuParts;
        private System.Windows.Forms.ToolStripMenuItem restartPartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseUploadToolStripMenuItem;
        private System.Windows.Forms.CheckedListBox ListParts;
    }
}

