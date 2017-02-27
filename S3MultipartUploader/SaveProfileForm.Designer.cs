namespace S3MultipartUploader {
    partial class SaveProfileForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveProfileForm));
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.LblAccessKeyId = new System.Windows.Forms.Label();
            this.LblSecretAccessKey = new System.Windows.Forms.Label();
            this.LblName = new System.Windows.Forms.Label();
            this.TxtProfileName = new System.Windows.Forms.TextBox();
            this.TxtAccessKeyID = new System.Windows.Forms.TextBox();
            this.TxtSecretAccessKey = new System.Windows.Forms.TextBox();
            this.ErrorMain = new System.Windows.Forms.ErrorProvider(this.components);
            this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
            this.PnlMain = new System.Windows.Forms.Panel();
            this.cvSave = new S3MultipartUploader.ControlValidator();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorMain)).BeginInit();
            this.PnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSave.AutoSize = true;
            this.BtnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnSave.Enabled = false;
            this.BtnSave.Location = new System.Drawing.Point(418, 86);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 1;
            this.BtnSave.Text = "Save";
            this.ToolTipMain.SetToolTip(this.BtnSave, "Save this credentials profile.");
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancel.AutoSize = true;
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(499, 86);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 2;
            this.BtnCancel.Text = "Cancel";
            this.ToolTipMain.SetToolTip(this.BtnCancel, "Cancel adding this creditials profile.");
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // LblAccessKeyId
            // 
            this.LblAccessKeyId.AutoSize = true;
            this.LblAccessKeyId.Location = new System.Drawing.Point(23, 32);
            this.LblAccessKeyId.Name = "LblAccessKeyId";
            this.LblAccessKeyId.Size = new System.Drawing.Size(80, 13);
            this.LblAccessKeyId.TabIndex = 2;
            this.LblAccessKeyId.Text = "Access Key ID:";
            this.ToolTipMain.SetToolTip(this.LblAccessKeyId, "Enter the Access Key ID provided by your AWS administrator.\r\nMust contain exactly" +
        " 20 uppercase letters and/or numbers.\r\n");
            // 
            // LblSecretAccessKey
            // 
            this.LblSecretAccessKey.AutoSize = true;
            this.LblSecretAccessKey.Location = new System.Drawing.Point(3, 58);
            this.LblSecretAccessKey.Name = "LblSecretAccessKey";
            this.LblSecretAccessKey.Size = new System.Drawing.Size(100, 13);
            this.LblSecretAccessKey.TabIndex = 3;
            this.LblSecretAccessKey.Text = "Secret Access Key:";
            this.ToolTipMain.SetToolTip(this.LblSecretAccessKey, resources.GetString("LblSecretAccessKey.ToolTip"));
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.Location = new System.Drawing.Point(33, 6);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(70, 13);
            this.LblName.TabIndex = 4;
            this.LblName.Text = "Profile Name:";
            this.ToolTipMain.SetToolTip(this.LblName, "Enter a unique name for this credentials profile.\r\nMust only contain upper and lo" +
        "wercase alphanumeric characters with no spaces, and any of the following charact" +
        "ers: =,.@-\r\n");
            // 
            // TxtProfileName
            // 
            this.TxtProfileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ErrorMain.SetIconPadding(this.TxtProfileName, 3);
            this.TxtProfileName.Location = new System.Drawing.Point(109, 3);
            this.TxtProfileName.MaxLength = 50;
            this.TxtProfileName.Name = "TxtProfileName";
            this.TxtProfileName.Size = new System.Drawing.Size(465, 20);
            this.TxtProfileName.TabIndex = 0;
            this.ToolTipMain.SetToolTip(this.TxtProfileName, "Enter a unique name for this credentials profile.\r\nMust only contain upper and lo" +
        "wercase alphanumeric characters with no spaces, and any of the following charact" +
        "ers: =,.@-");
            this.TxtProfileName.TextChanged += new System.EventHandler(this.TxtProfileName_TextChanged);
            this.TxtProfileName.Validating += new System.ComponentModel.CancelEventHandler(this.TxtProfileName_Validating);
            // 
            // TxtAccessKeyID
            // 
            this.TxtAccessKeyID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ErrorMain.SetIconPadding(this.TxtAccessKeyID, 3);
            this.TxtAccessKeyID.Location = new System.Drawing.Point(109, 29);
            this.TxtAccessKeyID.MaxLength = 20;
            this.TxtAccessKeyID.Name = "TxtAccessKeyID";
            this.TxtAccessKeyID.Size = new System.Drawing.Size(465, 20);
            this.TxtAccessKeyID.TabIndex = 1;
            this.ToolTipMain.SetToolTip(this.TxtAccessKeyID, "Enter the Access Key ID provided by your AWS administrator.\r\nMust contain exactly" +
        " 20 uppercase letters and/or numbers.");
            this.TxtAccessKeyID.TextChanged += new System.EventHandler(this.TxtAccessKeyID_TextChanged);
            this.TxtAccessKeyID.Validating += new System.ComponentModel.CancelEventHandler(this.TxtAccessKeyID_Validating);
            // 
            // TxtSecretAccessKey
            // 
            this.TxtSecretAccessKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ErrorMain.SetIconPadding(this.TxtSecretAccessKey, 3);
            this.TxtSecretAccessKey.Location = new System.Drawing.Point(109, 55);
            this.TxtSecretAccessKey.MaxLength = 40;
            this.TxtSecretAccessKey.Name = "TxtSecretAccessKey";
            this.TxtSecretAccessKey.Size = new System.Drawing.Size(465, 20);
            this.TxtSecretAccessKey.TabIndex = 2;
            this.ToolTipMain.SetToolTip(this.TxtSecretAccessKey, "Enter the Secret Access Key provided by your AWS administrator.\r\nMust contain exa" +
        "ctly 40 lower and/or uppercase alphanumeric characters with no spaces, forward s" +
        "lashes (\"/\"), and/or plus signs (\"+\").");
            this.TxtSecretAccessKey.UseSystemPasswordChar = true;
            this.TxtSecretAccessKey.TextChanged += new System.EventHandler(this.TxtSecretAccessKey_TextChanged);
            this.TxtSecretAccessKey.Validating += new System.ComponentModel.CancelEventHandler(this.TxtSecretAccessKey_Validating);
            // 
            // ErrorMain
            // 
            this.ErrorMain.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.ErrorMain.ContainerControl = this;
            // 
            // PnlMain
            // 
            this.PnlMain.Controls.Add(this.TxtProfileName);
            this.PnlMain.Controls.Add(this.TxtSecretAccessKey);
            this.PnlMain.Controls.Add(this.LblAccessKeyId);
            this.PnlMain.Controls.Add(this.TxtAccessKeyID);
            this.PnlMain.Controls.Add(this.LblSecretAccessKey);
            this.PnlMain.Controls.Add(this.LblName);
            this.PnlMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlMain.Location = new System.Drawing.Point(0, 0);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(599, 85);
            this.PnlMain.TabIndex = 0;
            // 
            // cvSave
            // 
            this.cvSave.ValidityChanged += new System.EventHandler(this.VsmSave_ValidityChanged);
            // 
            // SaveProfileForm
            // 
            this.AcceptButton = this.BtnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(599, 121);
            this.Controls.Add(this.PnlMain);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(615, 160);
            this.Name = "SaveProfileForm";
            this.ShowInTaskbar = false;
            this.Text = "Add AWS Credentials Profile";
            ((System.ComponentModel.ISupportInitialize)(this.ErrorMain)).EndInit();
            this.PnlMain.ResumeLayout(false);
            this.PnlMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Label LblAccessKeyId;
        private System.Windows.Forms.Label LblSecretAccessKey;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.TextBox TxtProfileName;
        private System.Windows.Forms.TextBox TxtAccessKeyID;
        private System.Windows.Forms.TextBox TxtSecretAccessKey;
        private System.Windows.Forms.ErrorProvider ErrorMain;
        private System.Windows.Forms.ToolTip ToolTipMain;
        private System.Windows.Forms.Panel PnlMain;
        private ControlValidator cvSave;
    }
}