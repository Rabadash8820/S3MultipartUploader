namespace S3MultipartUploader {
    partial class AdvancedOptionsForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdvancedOptionsForm));
            this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
            this.GrpMetadata = new System.Windows.Forms.GroupBox();
            this.PnlBottom = new System.Windows.Forms.Panel();
            this.BtnOK = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.TblLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.GrpContent = new System.Windows.Forms.GroupBox();
            this.GrpAccessCtrl = new System.Windows.Forms.GroupBox();
            this.GrpSse = new System.Windows.Forms.GroupBox();
            this.DgvMetadata = new System.Windows.Forms.DataGridView();
            this.DgvColMetadataKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColMetadataValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PnlTop = new System.Windows.Forms.Panel();
            this.LblAsynchronous = new System.Windows.Forms.Label();
            this.ChkAsynchronous = new System.Windows.Forms.CheckBox();
            this.LblStorageClass = new System.Windows.Forms.Label();
            this.LblWebsite = new System.Windows.Forms.Label();
            this.TxtWebsite = new System.Windows.Forms.TextBox();
            this.LblExpires = new System.Windows.Forms.Label();
            this.LblRequestPayer = new System.Windows.Forms.Label();
            this.TxtRequestPayer = new System.Windows.Forms.TextBox();
            this.LblDisposition = new System.Windows.Forms.Label();
            this.TxtDisposition = new System.Windows.Forms.TextBox();
            this.LblEncoding = new System.Windows.Forms.Label();
            this.TxtEncoding = new System.Windows.Forms.TextBox();
            this.LblLanguage = new System.Windows.Forms.Label();
            this.TxtLanguage = new System.Windows.Forms.TextBox();
            this.LblType = new System.Windows.Forms.Label();
            this.TxtType = new System.Windows.Forms.TextBox();
            this.LblAcl = new System.Windows.Forms.Label();
            this.ComboAcl = new System.Windows.Forms.ComboBox();
            this.LblFullControl = new System.Windows.Forms.Label();
            this.LblRead = new System.Windows.Forms.Label();
            this.LblReadAcp = new System.Windows.Forms.Label();
            this.LblWriteAcp = new System.Windows.Forms.Label();
            this.TxtFullControl = new System.Windows.Forms.TextBox();
            this.TxtRead = new System.Windows.Forms.TextBox();
            this.TxtReadAcp = new System.Windows.Forms.TextBox();
            this.TxtWriteAcp = new System.Windows.Forms.TextBox();
            this.DatePickerExpires = new System.Windows.Forms.DateTimePicker();
            this.LblEncryption = new System.Windows.Forms.Label();
            this.RadioStandard = new System.Windows.Forms.RadioButton();
            this.RadioReducedRedund = new System.Windows.Forms.RadioButton();
            this.RadioStandardIA = new System.Windows.Forms.RadioButton();
            this.LblSseAlgorithm = new System.Windows.Forms.Label();
            this.LblSseKey = new System.Windows.Forms.Label();
            this.LblSseKeyMd5 = new System.Windows.Forms.Label();
            this.LblSseKeyId = new System.Windows.Forms.Label();
            this.RadioNone = new System.Windows.Forms.RadioButton();
            this.RadioAES256 = new System.Windows.Forms.RadioButton();
            this.RadioKMS = new System.Windows.Forms.RadioButton();
            this.TxtSseKey = new System.Windows.Forms.TextBox();
            this.TxtSseAlgorithm = new System.Windows.Forms.TextBox();
            this.TxtSseKeyMd5 = new System.Windows.Forms.TextBox();
            this.TxtSseKeyId = new System.Windows.Forms.TextBox();
            this.ErrorMain = new System.Windows.Forms.ErrorProvider(this.components);
            this.GrpMetadata.SuspendLayout();
            this.PnlBottom.SuspendLayout();
            this.TblLayoutMain.SuspendLayout();
            this.GrpContent.SuspendLayout();
            this.GrpAccessCtrl.SuspendLayout();
            this.GrpSse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvMetadata)).BeginInit();
            this.PnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorMain)).BeginInit();
            this.SuspendLayout();
            // 
            // GrpMetadata
            // 
            this.GrpMetadata.Controls.Add(this.DgvMetadata);
            this.GrpMetadata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpMetadata.Location = new System.Drawing.Point(3, 146);
            this.GrpMetadata.Name = "GrpMetadata";
            this.GrpMetadata.Size = new System.Drawing.Size(538, 85);
            this.GrpMetadata.TabIndex = 1;
            this.GrpMetadata.TabStop = false;
            this.GrpMetadata.Text = "Metadata";
            // 
            // PnlBottom
            // 
            this.PnlBottom.Controls.Add(this.BtnCancel);
            this.PnlBottom.Controls.Add(this.BtnOK);
            this.PnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlBottom.Location = new System.Drawing.Point(3, 687);
            this.PnlBottom.Name = "PnlBottom";
            this.PnlBottom.Size = new System.Drawing.Size(538, 31);
            this.PnlBottom.TabIndex = 5;
            // 
            // BtnOK
            // 
            this.BtnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnOK.AutoSize = true;
            this.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnOK.Location = new System.Drawing.Point(379, 5);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(75, 23);
            this.BtnOK.TabIndex = 0;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancel.AutoSize = true;
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(460, 5);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 1;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // TblLayoutMain
            // 
            this.TblLayoutMain.ColumnCount = 1;
            this.TblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TblLayoutMain.Controls.Add(this.PnlBottom, 0, 5);
            this.TblLayoutMain.Controls.Add(this.GrpMetadata, 0, 1);
            this.TblLayoutMain.Controls.Add(this.GrpContent, 0, 2);
            this.TblLayoutMain.Controls.Add(this.GrpAccessCtrl, 0, 3);
            this.TblLayoutMain.Controls.Add(this.GrpSse, 0, 4);
            this.TblLayoutMain.Controls.Add(this.PnlTop, 0, 0);
            this.TblLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TblLayoutMain.Location = new System.Drawing.Point(0, 0);
            this.TblLayoutMain.Name = "TblLayoutMain";
            this.TblLayoutMain.RowCount = 6;
            this.TblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 143F));
            this.TblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 136F));
            this.TblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 159F));
            this.TblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 155F));
            this.TblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.TblLayoutMain.Size = new System.Drawing.Size(544, 721);
            this.TblLayoutMain.TabIndex = 0;
            // 
            // GrpContent
            // 
            this.GrpContent.Controls.Add(this.TxtType);
            this.GrpContent.Controls.Add(this.LblType);
            this.GrpContent.Controls.Add(this.TxtLanguage);
            this.GrpContent.Controls.Add(this.LblLanguage);
            this.GrpContent.Controls.Add(this.TxtEncoding);
            this.GrpContent.Controls.Add(this.LblEncoding);
            this.GrpContent.Controls.Add(this.TxtDisposition);
            this.GrpContent.Controls.Add(this.LblDisposition);
            this.GrpContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpContent.Location = new System.Drawing.Point(3, 237);
            this.GrpContent.Name = "GrpContent";
            this.GrpContent.Size = new System.Drawing.Size(538, 130);
            this.GrpContent.TabIndex = 2;
            this.GrpContent.TabStop = false;
            this.GrpContent.Text = "Content Headers";
            // 
            // GrpAccessCtrl
            // 
            this.GrpAccessCtrl.Controls.Add(this.TxtWriteAcp);
            this.GrpAccessCtrl.Controls.Add(this.TxtReadAcp);
            this.GrpAccessCtrl.Controls.Add(this.TxtRead);
            this.GrpAccessCtrl.Controls.Add(this.TxtFullControl);
            this.GrpAccessCtrl.Controls.Add(this.LblWriteAcp);
            this.GrpAccessCtrl.Controls.Add(this.LblReadAcp);
            this.GrpAccessCtrl.Controls.Add(this.LblRead);
            this.GrpAccessCtrl.Controls.Add(this.LblFullControl);
            this.GrpAccessCtrl.Controls.Add(this.ComboAcl);
            this.GrpAccessCtrl.Controls.Add(this.LblAcl);
            this.GrpAccessCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpAccessCtrl.Location = new System.Drawing.Point(3, 373);
            this.GrpAccessCtrl.Name = "GrpAccessCtrl";
            this.GrpAccessCtrl.Size = new System.Drawing.Size(538, 153);
            this.GrpAccessCtrl.TabIndex = 3;
            this.GrpAccessCtrl.TabStop = false;
            this.GrpAccessCtrl.Text = "Access Control";
            // 
            // GrpSse
            // 
            this.GrpSse.Controls.Add(this.TxtSseKeyId);
            this.GrpSse.Controls.Add(this.TxtSseKeyMd5);
            this.GrpSse.Controls.Add(this.TxtSseAlgorithm);
            this.GrpSse.Controls.Add(this.TxtSseKey);
            this.GrpSse.Controls.Add(this.RadioKMS);
            this.GrpSse.Controls.Add(this.RadioAES256);
            this.GrpSse.Controls.Add(this.RadioNone);
            this.GrpSse.Controls.Add(this.LblSseKeyId);
            this.GrpSse.Controls.Add(this.LblSseKeyMd5);
            this.GrpSse.Controls.Add(this.LblSseKey);
            this.GrpSse.Controls.Add(this.LblSseAlgorithm);
            this.GrpSse.Controls.Add(this.LblEncryption);
            this.GrpSse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpSse.Location = new System.Drawing.Point(3, 532);
            this.GrpSse.Name = "GrpSse";
            this.GrpSse.Size = new System.Drawing.Size(538, 149);
            this.GrpSse.TabIndex = 4;
            this.GrpSse.TabStop = false;
            this.GrpSse.Text = "Server-Side Encryption";
            // 
            // DgvMetadata
            // 
            this.DgvMetadata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvMetadata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgvColMetadataKey,
            this.DgvColMetadataValue});
            this.DgvMetadata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvMetadata.Location = new System.Drawing.Point(3, 16);
            this.DgvMetadata.Name = "DgvMetadata";
            this.DgvMetadata.Size = new System.Drawing.Size(532, 66);
            this.DgvMetadata.TabIndex = 0;
            // 
            // DgvColMetadataKey
            // 
            this.DgvColMetadataKey.HeaderText = "Key";
            this.DgvColMetadataKey.Name = "DgvColMetadataKey";
            this.DgvColMetadataKey.Width = 150;
            // 
            // DgvColMetadataValue
            // 
            this.DgvColMetadataValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DgvColMetadataValue.HeaderText = "Value";
            this.DgvColMetadataValue.Name = "DgvColMetadataValue";
            // 
            // PnlTop
            // 
            this.PnlTop.Controls.Add(this.RadioStandardIA);
            this.PnlTop.Controls.Add(this.RadioReducedRedund);
            this.PnlTop.Controls.Add(this.RadioStandard);
            this.PnlTop.Controls.Add(this.DatePickerExpires);
            this.PnlTop.Controls.Add(this.TxtRequestPayer);
            this.PnlTop.Controls.Add(this.LblRequestPayer);
            this.PnlTop.Controls.Add(this.LblExpires);
            this.PnlTop.Controls.Add(this.TxtWebsite);
            this.PnlTop.Controls.Add(this.LblWebsite);
            this.PnlTop.Controls.Add(this.LblAsynchronous);
            this.PnlTop.Controls.Add(this.ChkAsynchronous);
            this.PnlTop.Controls.Add(this.LblStorageClass);
            this.PnlTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlTop.Location = new System.Drawing.Point(3, 3);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(538, 137);
            this.PnlTop.TabIndex = 0;
            // 
            // LblAsynchronous
            // 
            this.LblAsynchronous.AutoSize = true;
            this.LblAsynchronous.Location = new System.Drawing.Point(21, 9);
            this.LblAsynchronous.Name = "LblAsynchronous";
            this.LblAsynchronous.Size = new System.Drawing.Size(124, 13);
            this.LblAsynchronous.TabIndex = 27;
            this.LblAsynchronous.Text = "Upload Asynchronously?";
            this.ToolTipMain.SetToolTip(this.LblAsynchronous, "If selected, then object parts will be uploaded in parallel.  Otherwise, parts wi" +
        "ll be uploaded one at a time.");
            // 
            // ChkAsynchronous
            // 
            this.ChkAsynchronous.AutoSize = true;
            this.ChkAsynchronous.Checked = true;
            this.ChkAsynchronous.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkAsynchronous.Location = new System.Drawing.Point(151, 9);
            this.ChkAsynchronous.Name = "ChkAsynchronous";
            this.ChkAsynchronous.Size = new System.Drawing.Size(15, 14);
            this.ChkAsynchronous.TabIndex = 0;
            this.ToolTipMain.SetToolTip(this.ChkAsynchronous, "If selected, then object parts will be uploaded in parallel.  Otherwise, parts wi" +
        "ll be uploaded one at a time.");
            this.ChkAsynchronous.UseVisualStyleBackColor = true;
            // 
            // LblStorageClass
            // 
            this.LblStorageClass.AutoSize = true;
            this.LblStorageClass.Location = new System.Drawing.Point(70, 58);
            this.LblStorageClass.Name = "LblStorageClass";
            this.LblStorageClass.Size = new System.Drawing.Size(75, 13);
            this.LblStorageClass.TabIndex = 22;
            this.LblStorageClass.Text = "Storage Class:";
            // 
            // LblWebsite
            // 
            this.LblWebsite.AutoSize = true;
            this.LblWebsite.Location = new System.Drawing.Point(9, 85);
            this.LblWebsite.Name = "LblWebsite";
            this.LblWebsite.Size = new System.Drawing.Size(136, 13);
            this.LblWebsite.TabIndex = 28;
            this.LblWebsite.Text = "Website Redirect Location:";
            // 
            // TxtWebsite
            // 
            this.TxtWebsite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ErrorMain.SetIconPadding(this.TxtWebsite, 3);
            this.TxtWebsite.Location = new System.Drawing.Point(151, 82);
            this.TxtWebsite.Name = "TxtWebsite";
            this.TxtWebsite.Size = new System.Drawing.Size(365, 20);
            this.TxtWebsite.TabIndex = 5;
            // 
            // LblExpires
            // 
            this.LblExpires.AutoSize = true;
            this.LblExpires.Location = new System.Drawing.Point(101, 32);
            this.LblExpires.Name = "LblExpires";
            this.LblExpires.Size = new System.Drawing.Size(44, 13);
            this.LblExpires.TabIndex = 30;
            this.LblExpires.Text = "Expires:";
            // 
            // LblRequestPayer
            // 
            this.LblRequestPayer.AutoSize = true;
            this.LblRequestPayer.Location = new System.Drawing.Point(65, 111);
            this.LblRequestPayer.Name = "LblRequestPayer";
            this.LblRequestPayer.Size = new System.Drawing.Size(80, 13);
            this.LblRequestPayer.TabIndex = 32;
            this.LblRequestPayer.Text = "Request Payer:";
            // 
            // TxtRequestPayer
            // 
            this.TxtRequestPayer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ErrorMain.SetIconPadding(this.TxtRequestPayer, 3);
            this.TxtRequestPayer.Location = new System.Drawing.Point(151, 108);
            this.TxtRequestPayer.Name = "TxtRequestPayer";
            this.TxtRequestPayer.Size = new System.Drawing.Size(365, 20);
            this.TxtRequestPayer.TabIndex = 6;
            // 
            // LblDisposition
            // 
            this.LblDisposition.AutoSize = true;
            this.LblDisposition.Location = new System.Drawing.Point(6, 48);
            this.LblDisposition.Name = "LblDisposition";
            this.LblDisposition.Size = new System.Drawing.Size(61, 13);
            this.LblDisposition.TabIndex = 0;
            this.LblDisposition.Text = "Disposition:";
            // 
            // TxtDisposition
            // 
            this.TxtDisposition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ErrorMain.SetIconPadding(this.TxtDisposition, 3);
            this.TxtDisposition.Location = new System.Drawing.Point(73, 19);
            this.TxtDisposition.Name = "TxtDisposition";
            this.TxtDisposition.Size = new System.Drawing.Size(443, 20);
            this.TxtDisposition.TabIndex = 0;
            // 
            // LblEncoding
            // 
            this.LblEncoding.AutoSize = true;
            this.LblEncoding.Location = new System.Drawing.Point(12, 74);
            this.LblEncoding.Name = "LblEncoding";
            this.LblEncoding.Size = new System.Drawing.Size(55, 13);
            this.LblEncoding.TabIndex = 2;
            this.LblEncoding.Text = "Encoding:";
            // 
            // TxtEncoding
            // 
            this.TxtEncoding.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ErrorMain.SetIconPadding(this.TxtEncoding, 3);
            this.TxtEncoding.Location = new System.Drawing.Point(73, 45);
            this.TxtEncoding.Name = "TxtEncoding";
            this.TxtEncoding.Size = new System.Drawing.Size(443, 20);
            this.TxtEncoding.TabIndex = 1;
            // 
            // LblLanguage
            // 
            this.LblLanguage.AutoSize = true;
            this.LblLanguage.Location = new System.Drawing.Point(9, 100);
            this.LblLanguage.Name = "LblLanguage";
            this.LblLanguage.Size = new System.Drawing.Size(58, 13);
            this.LblLanguage.TabIndex = 4;
            this.LblLanguage.Text = "Language:";
            // 
            // TxtLanguage
            // 
            this.TxtLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ErrorMain.SetIconPadding(this.TxtLanguage, 3);
            this.TxtLanguage.Location = new System.Drawing.Point(73, 71);
            this.TxtLanguage.Name = "TxtLanguage";
            this.TxtLanguage.Size = new System.Drawing.Size(443, 20);
            this.TxtLanguage.TabIndex = 2;
            // 
            // LblType
            // 
            this.LblType.AutoSize = true;
            this.LblType.Location = new System.Drawing.Point(33, 22);
            this.LblType.Name = "LblType";
            this.LblType.Size = new System.Drawing.Size(34, 13);
            this.LblType.TabIndex = 6;
            this.LblType.Text = "Type:";
            // 
            // TxtType
            // 
            this.TxtType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ErrorMain.SetIconPadding(this.TxtType, 3);
            this.TxtType.Location = new System.Drawing.Point(73, 97);
            this.TxtType.Name = "TxtType";
            this.TxtType.Size = new System.Drawing.Size(443, 20);
            this.TxtType.TabIndex = 3;
            // 
            // LblAcl
            // 
            this.LblAcl.AutoSize = true;
            this.LblAcl.Location = new System.Drawing.Point(75, 22);
            this.LblAcl.Name = "LblAcl";
            this.LblAcl.Size = new System.Drawing.Size(70, 13);
            this.LblAcl.TabIndex = 0;
            this.LblAcl.Text = "Canned ACL:";
            // 
            // ComboAcl
            // 
            this.ComboAcl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboAcl.FormattingEnabled = true;
            this.ComboAcl.Items.AddRange(new object[] {
            "private",
            "public-read",
            "public-read-write",
            "authenticated-read",
            "aws-exec-read",
            "bucket-owner-read",
            "bucket-owner-full-control"});
            this.ComboAcl.Location = new System.Drawing.Point(151, 19);
            this.ComboAcl.Name = "ComboAcl";
            this.ComboAcl.Size = new System.Drawing.Size(177, 21);
            this.ComboAcl.TabIndex = 0;
            // 
            // LblFullControl
            // 
            this.LblFullControl.AutoSize = true;
            this.LblFullControl.Location = new System.Drawing.Point(46, 49);
            this.LblFullControl.Name = "LblFullControl";
            this.LblFullControl.Size = new System.Drawing.Size(99, 13);
            this.LblFullControl.TabIndex = 6;
            this.LblFullControl.Text = "Grant full control to:";
            // 
            // LblRead
            // 
            this.LblRead.AutoSize = true;
            this.LblRead.Location = new System.Drawing.Point(36, 75);
            this.LblRead.Name = "LblRead";
            this.LblRead.Size = new System.Drawing.Size(109, 13);
            this.LblRead.TabIndex = 7;
            this.LblRead.Text = "Grant read access to:";
            // 
            // LblReadAcp
            // 
            this.LblReadAcp.AutoSize = true;
            this.LblReadAcp.Location = new System.Drawing.Point(12, 101);
            this.LblReadAcp.Name = "LblReadAcp";
            this.LblReadAcp.Size = new System.Drawing.Size(133, 13);
            this.LblReadAcp.TabIndex = 8;
            this.LblReadAcp.Text = "Grant read ACP access to:";
            // 
            // LblWriteAcp
            // 
            this.LblWriteAcp.AutoSize = true;
            this.LblWriteAcp.Location = new System.Drawing.Point(11, 127);
            this.LblWriteAcp.Name = "LblWriteAcp";
            this.LblWriteAcp.Size = new System.Drawing.Size(134, 13);
            this.LblWriteAcp.TabIndex = 9;
            this.LblWriteAcp.Text = "Grant write ACP access to:";
            // 
            // TxtFullControl
            // 
            this.TxtFullControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ErrorMain.SetIconPadding(this.TxtFullControl, 3);
            this.TxtFullControl.Location = new System.Drawing.Point(151, 46);
            this.TxtFullControl.Name = "TxtFullControl";
            this.TxtFullControl.Size = new System.Drawing.Size(365, 20);
            this.TxtFullControl.TabIndex = 1;
            // 
            // TxtRead
            // 
            this.TxtRead.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ErrorMain.SetIconPadding(this.TxtRead, 3);
            this.TxtRead.Location = new System.Drawing.Point(151, 72);
            this.TxtRead.Name = "TxtRead";
            this.TxtRead.Size = new System.Drawing.Size(365, 20);
            this.TxtRead.TabIndex = 2;
            // 
            // TxtReadAcp
            // 
            this.TxtReadAcp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ErrorMain.SetIconPadding(this.TxtReadAcp, 3);
            this.TxtReadAcp.Location = new System.Drawing.Point(151, 98);
            this.TxtReadAcp.Name = "TxtReadAcp";
            this.TxtReadAcp.Size = new System.Drawing.Size(365, 20);
            this.TxtReadAcp.TabIndex = 3;
            // 
            // TxtWriteAcp
            // 
            this.TxtWriteAcp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ErrorMain.SetIconPadding(this.TxtWriteAcp, 3);
            this.TxtWriteAcp.Location = new System.Drawing.Point(151, 124);
            this.TxtWriteAcp.Name = "TxtWriteAcp";
            this.TxtWriteAcp.Size = new System.Drawing.Size(365, 20);
            this.TxtWriteAcp.TabIndex = 4;
            // 
            // DatePickerExpires
            // 
            this.DatePickerExpires.Location = new System.Drawing.Point(151, 29);
            this.DatePickerExpires.Name = "DatePickerExpires";
            this.DatePickerExpires.Size = new System.Drawing.Size(197, 20);
            this.DatePickerExpires.TabIndex = 1;
            // 
            // LblEncryption
            // 
            this.LblEncryption.AutoSize = true;
            this.LblEncryption.Location = new System.Drawing.Point(21, 20);
            this.LblEncryption.Name = "LblEncryption";
            this.LblEncryption.Size = new System.Drawing.Size(60, 13);
            this.LblEncryption.TabIndex = 0;
            this.LblEncryption.Text = "Encryption:";
            // 
            // RadioStandard
            // 
            this.RadioStandard.AutoSize = true;
            this.RadioStandard.Checked = true;
            this.RadioStandard.Location = new System.Drawing.Point(151, 56);
            this.RadioStandard.Name = "RadioStandard";
            this.RadioStandard.Size = new System.Drawing.Size(68, 17);
            this.RadioStandard.TabIndex = 2;
            this.RadioStandard.TabStop = true;
            this.RadioStandard.Text = "Standard";
            this.RadioStandard.UseVisualStyleBackColor = true;
            // 
            // RadioReducedRedund
            // 
            this.RadioReducedRedund.AutoSize = true;
            this.RadioReducedRedund.Location = new System.Drawing.Point(225, 56);
            this.RadioReducedRedund.Name = "RadioReducedRedund";
            this.RadioReducedRedund.Size = new System.Drawing.Size(133, 17);
            this.RadioReducedRedund.TabIndex = 3;
            this.RadioReducedRedund.Text = "Reduced Redundancy";
            this.RadioReducedRedund.UseVisualStyleBackColor = true;
            // 
            // RadioStandardIA
            // 
            this.RadioStandardIA.AutoSize = true;
            this.RadioStandardIA.Location = new System.Drawing.Point(364, 56);
            this.RadioStandardIA.Name = "RadioStandardIA";
            this.RadioStandardIA.Size = new System.Drawing.Size(163, 17);
            this.RadioStandardIA.TabIndex = 4;
            this.RadioStandardIA.Text = "Standard (Infrequent Access)";
            this.RadioStandardIA.UseVisualStyleBackColor = true;
            // 
            // LblSseAlgorithm
            // 
            this.LblSseAlgorithm.AutoSize = true;
            this.LblSseAlgorithm.Enabled = false;
            this.LblSseAlgorithm.Location = new System.Drawing.Point(28, 70);
            this.LblSseAlgorithm.Name = "LblSseAlgorithm";
            this.LblSseAlgorithm.Size = new System.Drawing.Size(53, 13);
            this.LblSseAlgorithm.TabIndex = 1;
            this.LblSseAlgorithm.Text = "Algorithm:";
            // 
            // LblSseKey
            // 
            this.LblSseKey.AutoSize = true;
            this.LblSseKey.Enabled = false;
            this.LblSseKey.Location = new System.Drawing.Point(6, 44);
            this.LblSseKey.Name = "LblSseKey";
            this.LblSseKey.Size = new System.Drawing.Size(75, 13);
            this.LblSseKey.TabIndex = 2;
            this.LblSseKey.Text = "Customer Key:";
            // 
            // LblSseKeyMd5
            // 
            this.LblSseKeyMd5.AutoSize = true;
            this.LblSseKeyMd5.Enabled = false;
            this.LblSseKeyMd5.Location = new System.Drawing.Point(27, 96);
            this.LblSseKeyMd5.Name = "LblSseKeyMd5";
            this.LblSseKeyMd5.Size = new System.Drawing.Size(54, 13);
            this.LblSseKeyMd5.TabIndex = 3;
            this.LblSseKeyMd5.Text = "Key MD5:";
            // 
            // LblSseKeyId
            // 
            this.LblSseKeyId.AutoSize = true;
            this.LblSseKeyId.Enabled = false;
            this.LblSseKeyId.Location = new System.Drawing.Point(41, 122);
            this.LblSseKeyId.Name = "LblSseKeyId";
            this.LblSseKeyId.Size = new System.Drawing.Size(40, 13);
            this.LblSseKeyId.TabIndex = 4;
            this.LblSseKeyId.Text = "Key Id:";
            // 
            // RadioNone
            // 
            this.RadioNone.AutoSize = true;
            this.RadioNone.Checked = true;
            this.RadioNone.Location = new System.Drawing.Point(87, 18);
            this.RadioNone.Name = "RadioNone";
            this.RadioNone.Size = new System.Drawing.Size(51, 17);
            this.RadioNone.TabIndex = 0;
            this.RadioNone.TabStop = true;
            this.RadioNone.Text = "None";
            this.RadioNone.UseVisualStyleBackColor = true;
            // 
            // RadioAES256
            // 
            this.RadioAES256.AutoSize = true;
            this.RadioAES256.Location = new System.Drawing.Point(144, 18);
            this.RadioAES256.Name = "RadioAES256";
            this.RadioAES256.Size = new System.Drawing.Size(64, 17);
            this.RadioAES256.TabIndex = 1;
            this.RadioAES256.Text = "AES256";
            this.RadioAES256.UseVisualStyleBackColor = true;
            // 
            // RadioKMS
            // 
            this.RadioKMS.AutoSize = true;
            this.RadioKMS.Location = new System.Drawing.Point(214, 18);
            this.RadioKMS.Name = "RadioKMS";
            this.RadioKMS.Size = new System.Drawing.Size(76, 17);
            this.RadioKMS.TabIndex = 2;
            this.RadioKMS.Text = "AWS KMS";
            this.RadioKMS.UseVisualStyleBackColor = true;
            this.RadioKMS.CheckedChanged += new System.EventHandler(this.RadioKMS_CheckedChanged);
            // 
            // TxtSseKey
            // 
            this.TxtSseKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtSseKey.Enabled = false;
            this.ErrorMain.SetIconPadding(this.TxtSseKey, 3);
            this.TxtSseKey.Location = new System.Drawing.Point(87, 41);
            this.TxtSseKey.Name = "TxtSseKey";
            this.TxtSseKey.Size = new System.Drawing.Size(429, 20);
            this.TxtSseKey.TabIndex = 3;
            // 
            // TxtSseAlgorithm
            // 
            this.TxtSseAlgorithm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtSseAlgorithm.Enabled = false;
            this.ErrorMain.SetIconPadding(this.TxtSseAlgorithm, 3);
            this.TxtSseAlgorithm.Location = new System.Drawing.Point(87, 67);
            this.TxtSseAlgorithm.Name = "TxtSseAlgorithm";
            this.TxtSseAlgorithm.Size = new System.Drawing.Size(429, 20);
            this.TxtSseAlgorithm.TabIndex = 4;
            // 
            // TxtSseKeyMd5
            // 
            this.TxtSseKeyMd5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtSseKeyMd5.Enabled = false;
            this.ErrorMain.SetIconPadding(this.TxtSseKeyMd5, 3);
            this.TxtSseKeyMd5.Location = new System.Drawing.Point(87, 93);
            this.TxtSseKeyMd5.Name = "TxtSseKeyMd5";
            this.TxtSseKeyMd5.Size = new System.Drawing.Size(429, 20);
            this.TxtSseKeyMd5.TabIndex = 5;
            // 
            // TxtSseKeyId
            // 
            this.TxtSseKeyId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtSseKeyId.Enabled = false;
            this.ErrorMain.SetIconPadding(this.TxtSseKeyId, 3);
            this.TxtSseKeyId.Location = new System.Drawing.Point(87, 119);
            this.TxtSseKeyId.Name = "TxtSseKeyId";
            this.TxtSseKeyId.Size = new System.Drawing.Size(429, 20);
            this.TxtSseKeyId.TabIndex = 6;
            // 
            // ErrorMain
            // 
            this.ErrorMain.ContainerControl = this;
            // 
            // AdvancedOptionsForm
            // 
            this.AcceptButton = this.BtnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(544, 721);
            this.Controls.Add(this.TblLayoutMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(560, 760);
            this.Name = "AdvancedOptionsForm";
            this.ShowInTaskbar = false;
            this.Text = "Advanced S3 Upload Options";
            this.GrpMetadata.ResumeLayout(false);
            this.PnlBottom.ResumeLayout(false);
            this.PnlBottom.PerformLayout();
            this.TblLayoutMain.ResumeLayout(false);
            this.GrpContent.ResumeLayout(false);
            this.GrpContent.PerformLayout();
            this.GrpAccessCtrl.ResumeLayout(false);
            this.GrpAccessCtrl.PerformLayout();
            this.GrpSse.ResumeLayout(false);
            this.GrpSse.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvMetadata)).EndInit();
            this.PnlTop.ResumeLayout(false);
            this.PnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip ToolTipMain;
        private System.Windows.Forms.GroupBox GrpMetadata;
        private System.Windows.Forms.Panel PnlBottom;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.TableLayoutPanel TblLayoutMain;
        private System.Windows.Forms.GroupBox GrpContent;
        private System.Windows.Forms.GroupBox GrpAccessCtrl;
        private System.Windows.Forms.GroupBox GrpSse;
        private System.Windows.Forms.DataGridView DgvMetadata;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColMetadataKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColMetadataValue;
        private System.Windows.Forms.Panel PnlTop;
        private System.Windows.Forms.Label LblExpires;
        private System.Windows.Forms.TextBox TxtWebsite;
        private System.Windows.Forms.Label LblWebsite;
        private System.Windows.Forms.Label LblAsynchronous;
        private System.Windows.Forms.CheckBox ChkAsynchronous;
        private System.Windows.Forms.Label LblStorageClass;
        private System.Windows.Forms.TextBox TxtRequestPayer;
        private System.Windows.Forms.Label LblRequestPayer;
        private System.Windows.Forms.TextBox TxtType;
        private System.Windows.Forms.Label LblType;
        private System.Windows.Forms.TextBox TxtLanguage;
        private System.Windows.Forms.Label LblLanguage;
        private System.Windows.Forms.TextBox TxtEncoding;
        private System.Windows.Forms.Label LblEncoding;
        private System.Windows.Forms.TextBox TxtDisposition;
        private System.Windows.Forms.Label LblDisposition;
        private System.Windows.Forms.ComboBox ComboAcl;
        private System.Windows.Forms.Label LblAcl;
        private System.Windows.Forms.TextBox TxtWriteAcp;
        private System.Windows.Forms.TextBox TxtReadAcp;
        private System.Windows.Forms.TextBox TxtRead;
        private System.Windows.Forms.TextBox TxtFullControl;
        private System.Windows.Forms.Label LblWriteAcp;
        private System.Windows.Forms.Label LblReadAcp;
        private System.Windows.Forms.Label LblRead;
        private System.Windows.Forms.Label LblFullControl;
        private System.Windows.Forms.DateTimePicker DatePickerExpires;
        private System.Windows.Forms.Label LblEncryption;
        private System.Windows.Forms.RadioButton RadioStandardIA;
        private System.Windows.Forms.RadioButton RadioReducedRedund;
        private System.Windows.Forms.RadioButton RadioStandard;
        private System.Windows.Forms.Label LblSseKeyId;
        private System.Windows.Forms.Label LblSseKeyMd5;
        private System.Windows.Forms.Label LblSseKey;
        private System.Windows.Forms.Label LblSseAlgorithm;
        private System.Windows.Forms.RadioButton RadioKMS;
        private System.Windows.Forms.RadioButton RadioAES256;
        private System.Windows.Forms.RadioButton RadioNone;
        private System.Windows.Forms.TextBox TxtSseKeyId;
        private System.Windows.Forms.TextBox TxtSseKeyMd5;
        private System.Windows.Forms.TextBox TxtSseAlgorithm;
        private System.Windows.Forms.TextBox TxtSseKey;
        private System.Windows.Forms.ErrorProvider ErrorMain;
    }
}