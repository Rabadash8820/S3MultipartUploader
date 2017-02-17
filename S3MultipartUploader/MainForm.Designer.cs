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
            this.LblOptions = new System.Windows.Forms.Label();
            this.ChkAsynchronous = new System.Windows.Forms.CheckBox();
            this.TxtOptions = new System.Windows.Forms.TextBox();
            this.SplitInner = new System.Windows.Forms.SplitContainer();
            this.ListParts = new System.Windows.Forms.CheckedListBox();
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
            this.TblLayoutMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitOuter)).BeginInit();
            this.SplitOuter.Panel1.SuspendLayout();
            this.SplitOuter.Panel2.SuspendLayout();
            this.SplitOuter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitInner)).BeginInit();
            this.SplitInner.Panel1.SuspendLayout();
            this.SplitInner.Panel2.SuspendLayout();
            this.SplitInner.SuspendLayout();
            this.PnlTop.SuspendLayout();
            this.PnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProviderMain)).BeginInit();
            this.SuspendLayout();
            // 
            // LblProfile
            // 
            this.LblProfile.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblProfile.AutoSize = true;
            this.LblProfile.Location = new System.Drawing.Point(35, 12);
            this.LblProfile.Name = "LblProfile";
            this.LblProfile.Size = new System.Drawing.Size(36, 13);
            this.LblProfile.TabIndex = 0;
            this.LblProfile.Text = "Profile";
            // 
            // LblBucket
            // 
            this.LblBucket.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblBucket.AutoSize = true;
            this.LblBucket.Enabled = false;
            this.LblBucket.Location = new System.Drawing.Point(30, 39);
            this.LblBucket.Name = "LblBucket";
            this.LblBucket.Size = new System.Drawing.Size(41, 13);
            this.LblBucket.TabIndex = 1;
            this.LblBucket.Text = "Bucket";
            // 
            // LblKey
            // 
            this.LblKey.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblKey.AutoSize = true;
            this.LblKey.Location = new System.Drawing.Point(46, 66);
            this.LblKey.Name = "LblKey";
            this.LblKey.Size = new System.Drawing.Size(25, 13);
            this.LblKey.TabIndex = 2;
            this.LblKey.Text = "Key";
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
            this.SplitOuter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SplitOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitOuter.Location = new System.Drawing.Point(3, 163);
            this.SplitOuter.Name = "SplitOuter";
            this.SplitOuter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitOuter.Panel1
            // 
            this.SplitOuter.Panel1.Controls.Add(this.LblOptions);
            this.SplitOuter.Panel1.Controls.Add(this.ChkAsynchronous);
            this.SplitOuter.Panel1.Controls.Add(this.TxtOptions);
            this.SplitOuter.Panel1Collapsed = true;
            // 
            // SplitOuter.Panel2
            // 
            this.SplitOuter.Panel2.Controls.Add(this.SplitInner);
            this.SplitOuter.Size = new System.Drawing.Size(403, 380);
            this.SplitOuter.SplitterDistance = 146;
            this.SplitOuter.TabIndex = 13;
            // 
            // LblOptions
            // 
            this.LblOptions.AutoSize = true;
            this.LblOptions.Location = new System.Drawing.Point(3, 33);
            this.LblOptions.Name = "LblOptions";
            this.LblOptions.Size = new System.Drawing.Size(121, 13);
            this.LblOptions.TabIndex = 17;
            this.LblOptions.Text = "Additional AWS options:";
            // 
            // ChkAsynchronous
            // 
            this.ChkAsynchronous.AutoSize = true;
            this.ChkAsynchronous.Checked = true;
            this.ChkAsynchronous.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkAsynchronous.Location = new System.Drawing.Point(3, 3);
            this.ChkAsynchronous.Name = "ChkAsynchronous";
            this.ChkAsynchronous.Size = new System.Drawing.Size(137, 17);
            this.ChkAsynchronous.TabIndex = 15;
            this.ChkAsynchronous.Text = "Upload Asynchronously";
            this.ChkAsynchronous.UseVisualStyleBackColor = true;
            // 
            // TxtOptions
            // 
            this.TxtOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtOptions.Location = new System.Drawing.Point(0, 49);
            this.TxtOptions.Multiline = true;
            this.TxtOptions.Name = "TxtOptions";
            this.TxtOptions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtOptions.Size = new System.Drawing.Size(399, 92);
            this.TxtOptions.TabIndex = 16;
            // 
            // SplitInner
            // 
            this.SplitInner.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SplitInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitInner.Location = new System.Drawing.Point(0, 0);
            this.SplitInner.Name = "SplitInner";
            this.SplitInner.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitInner.Panel1
            // 
            this.SplitInner.Panel1.Controls.Add(this.ListParts);
            // 
            // SplitInner.Panel2
            // 
            this.SplitInner.Panel2.Controls.Add(this.ListLog);
            this.SplitInner.Size = new System.Drawing.Size(403, 380);
            this.SplitInner.SplitterDistance = 163;
            this.SplitInner.TabIndex = 15;
            // 
            // ListParts
            // 
            this.ListParts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListParts.Enabled = false;
            this.ListParts.FormattingEnabled = true;
            this.ListParts.Location = new System.Drawing.Point(0, 0);
            this.ListParts.Name = "ListParts";
            this.ListParts.ScrollAlwaysVisible = true;
            this.ListParts.Size = new System.Drawing.Size(399, 139);
            this.ListParts.TabIndex = 0;
            this.ListParts.ThreeDCheckBoxes = true;
            // 
            // ListLog
            // 
            this.ListLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListLog.FormattingEnabled = true;
            this.ListLog.Items.AddRange(new object[] {
            "Welcome to the S3 Multipart Uploader!",
            ""});
            this.ListLog.Location = new System.Drawing.Point(0, 0);
            this.ListLog.Name = "ListLog";
            this.ListLog.ScrollAlwaysVisible = true;
            this.ListLog.Size = new System.Drawing.Size(399, 199);
            this.ListLog.TabIndex = 0;
            // 
            // PnlTop
            // 
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
            this.PnlTop.TabIndex = 14;
            // 
            // BtnOptions
            // 
            this.BtnOptions.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnOptions.AutoSize = true;
            this.BtnOptions.Location = new System.Drawing.Point(77, 118);
            this.BtnOptions.Name = "BtnOptions";
            this.BtnOptions.Size = new System.Drawing.Size(75, 23);
            this.BtnOptions.TabIndex = 13;
            this.BtnOptions.Text = "Advanced...";
            this.BtnOptions.UseVisualStyleBackColor = true;
            this.BtnOptions.Click += new System.EventHandler(this.BtnOptions_Click);
            // 
            // LblChooseDir
            // 
            this.LblChooseDir.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblChooseDir.AutoSize = true;
            this.LblChooseDir.Location = new System.Drawing.Point(128, 94);
            this.LblChooseDir.Name = "LblChooseDir";
            this.LblChooseDir.Size = new System.Drawing.Size(107, 13);
            this.LblChooseDir.TabIndex = 0;
            this.LblChooseDir.Text = "Object parts directory";
            // 
            // ComboProfile
            // 
            this.ComboProfile.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ComboProfile.FormattingEnabled = true;
            this.ComboProfile.Location = new System.Drawing.Point(77, 9);
            this.ComboProfile.Name = "ComboProfile";
            this.ComboProfile.Size = new System.Drawing.Size(266, 21);
            this.ComboProfile.TabIndex = 7;
            // 
            // ComboBucket
            // 
            this.ComboBucket.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ComboBucket.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBucket.Enabled = false;
            this.ComboBucket.FormattingEnabled = true;
            this.ComboBucket.Location = new System.Drawing.Point(77, 36);
            this.ComboBucket.Name = "ComboBucket";
            this.ComboBucket.Size = new System.Drawing.Size(266, 21);
            this.ComboBucket.TabIndex = 9;
            // 
            // BtnChooseDir
            // 
            this.BtnChooseDir.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnChooseDir.AutoSize = true;
            this.BtnChooseDir.Location = new System.Drawing.Point(77, 89);
            this.BtnChooseDir.Name = "BtnChooseDir";
            this.BtnChooseDir.Size = new System.Drawing.Size(45, 23);
            this.BtnChooseDir.TabIndex = 1;
            this.BtnChooseDir.Text = "...";
            this.BtnChooseDir.UseVisualStyleBackColor = true;
            this.BtnChooseDir.Click += new System.EventHandler(this.BtnChooseDir_Click);
            // 
            // TxtKey
            // 
            this.TxtKey.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtKey.Location = new System.Drawing.Point(77, 63);
            this.TxtKey.Name = "TxtKey";
            this.TxtKey.Size = new System.Drawing.Size(266, 20);
            this.TxtKey.TabIndex = 10;
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
            this.ProgressMain.TabIndex = 1;
            // 
            // BtnStartStop
            // 
            this.BtnStartStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnStartStop.AutoSize = true;
            this.BtnStartStop.Enabled = false;
            this.BtnStartStop.Location = new System.Drawing.Point(325, 3);
            this.BtnStartStop.Name = "BtnStartStop";
            this.BtnStartStop.Size = new System.Drawing.Size(75, 23);
            this.BtnStartStop.TabIndex = 0;
            this.BtnStartStop.Text = "Start";
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 581);
            this.Controls.Add(this.TblLayoutMain);
            this.MinimumSize = new System.Drawing.Size(425, 620);
            this.Name = "MainForm";
            this.Text = "S3 Multipart Uploader";
            this.TblLayoutMain.ResumeLayout(false);
            this.SplitOuter.Panel1.ResumeLayout(false);
            this.SplitOuter.Panel1.PerformLayout();
            this.SplitOuter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitOuter)).EndInit();
            this.SplitOuter.ResumeLayout(false);
            this.SplitInner.Panel1.ResumeLayout(false);
            this.SplitInner.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitInner)).EndInit();
            this.SplitInner.ResumeLayout(false);
            this.PnlTop.ResumeLayout(false);
            this.PnlTop.PerformLayout();
            this.PnlBottom.ResumeLayout(false);
            this.PnlBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProviderMain)).EndInit();
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
        private System.Windows.Forms.TextBox TxtOptions;
        private System.Windows.Forms.CheckBox ChkAsynchronous;
        private System.Windows.Forms.CheckedListBox ListParts;
        private System.Windows.Forms.ErrorProvider ErrorProviderMain;
        private System.Windows.Forms.Label LblOptions;
        private System.Windows.Forms.ToolTip ToolTipMain;
        private System.Windows.Forms.SplitContainer SplitInner;
        private System.Windows.Forms.Panel PnlBottom;
        private System.Windows.Forms.ProgressBar ProgressMain;
        private System.Windows.Forms.Button BtnStartStop;
    }
}

