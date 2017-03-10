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
            this.LblAsynchronous = new System.Windows.Forms.Label();
            this.ChkAsynchronous = new System.Windows.Forms.CheckBox();
            this.ChkRequestPayer = new System.Windows.Forms.CheckBox();
            this.GrpMetadata = new System.Windows.Forms.GroupBox();
            this.DgvMetadata = new System.Windows.Forms.DataGridView();
            this.DgvColMetadataKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColMetadataValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrpContent = new System.Windows.Forms.GroupBox();
            this.LblType = new System.Windows.Forms.Label();
            this.TxtEncoding = new System.Windows.Forms.TextBox();
            this.TxtDisposition = new System.Windows.Forms.TextBox();
            this.DatePickerExpires = new System.Windows.Forms.DateTimePicker();
            this.LblEncoding = new System.Windows.Forms.Label();
            this.TxtType = new System.Windows.Forms.TextBox();
            this.LblExpires = new System.Windows.Forms.Label();
            this.LblDisposition = new System.Windows.Forms.Label();
            this.GrpAccessCtrl = new System.Windows.Forms.GroupBox();
            this.LblUseCannedACL = new System.Windows.Forms.Label();
            this.ChkUseCannedACLs = new System.Windows.Forms.CheckBox();
            this.ComboAcl = new System.Windows.Forms.ComboBox();
            this.LblAcl = new System.Windows.Forms.Label();
            this.DgvGrants = new System.Windows.Forms.DataGridView();
            this.GrpSse = new System.Windows.Forms.GroupBox();
            this.TxtSseKeyId = new System.Windows.Forms.TextBox();
            this.TxtSseCustomerKeyMd5 = new System.Windows.Forms.TextBox();
            this.TxtSseCustomerKey = new System.Windows.Forms.TextBox();
            this.RadioSseKms = new System.Windows.Forms.RadioButton();
            this.RadioSseNewKey = new System.Windows.Forms.RadioButton();
            this.RadioSseNone = new System.Windows.Forms.RadioButton();
            this.LblSseKeyId = new System.Windows.Forms.Label();
            this.LblSseCustomerKeyMd5 = new System.Windows.Forms.Label();
            this.LblSseCustomerKey = new System.Windows.Forms.Label();
            this.LblEncryption = new System.Windows.Forms.Label();
            this.RadioStandardIA = new System.Windows.Forms.RadioButton();
            this.RadioReducedRedund = new System.Windows.Forms.RadioButton();
            this.RadioStandard = new System.Windows.Forms.RadioButton();
            this.LblRequestPayer = new System.Windows.Forms.Label();
            this.TxtWebsite = new System.Windows.Forms.TextBox();
            this.LblWebsite = new System.Windows.Forms.Label();
            this.LblStorageClass = new System.Windows.Forms.Label();
            this.PnlBottom = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.TblLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.PnlTop = new System.Windows.Forms.Panel();
            this.ErrorMain = new System.Windows.Forms.ErrorProvider(this.components);
            this.DgvColGranteeType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DgvColGrantee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColCanRead = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DgvColCanReadAcl = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DgvColCanWriteAcl = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.GrpMetadata.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvMetadata)).BeginInit();
            this.GrpContent.SuspendLayout();
            this.GrpAccessCtrl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGrants)).BeginInit();
            this.GrpSse.SuspendLayout();
            this.PnlBottom.SuspendLayout();
            this.TblLayoutMain.SuspendLayout();
            this.PnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorMain)).BeginInit();
            this.SuspendLayout();
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
            // ChkRequestPayer
            // 
            this.ChkRequestPayer.AutoSize = true;
            this.ChkRequestPayer.Location = new System.Drawing.Point(151, 78);
            this.ChkRequestPayer.Name = "ChkRequestPayer";
            this.ChkRequestPayer.Size = new System.Drawing.Size(15, 14);
            this.ChkRequestPayer.TabIndex = 6;
            this.ToolTipMain.SetToolTip(this.ChkRequestPayer, "Confirms that the requester knows that she or he will be charged for the request." +
        " Bucket owners need not specify this parameter in their requests.");
            this.ChkRequestPayer.UseVisualStyleBackColor = true;
            // 
            // GrpMetadata
            // 
            this.GrpMetadata.Controls.Add(this.DgvMetadata);
            this.GrpMetadata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpMetadata.Location = new System.Drawing.Point(3, 109);
            this.GrpMetadata.Name = "GrpMetadata";
            this.GrpMetadata.Size = new System.Drawing.Size(534, 131);
            this.GrpMetadata.TabIndex = 1;
            this.GrpMetadata.TabStop = false;
            this.GrpMetadata.Text = "Metadata";
            this.ToolTipMain.SetToolTip(this.GrpMetadata, "A map of metadata (key-value pairs) to store with the object in S3.");
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
            this.DgvMetadata.Size = new System.Drawing.Size(528, 112);
            this.DgvMetadata.TabIndex = 0;
            // 
            // DgvColMetadataKey
            // 
            this.DgvColMetadataKey.HeaderText = "Key";
            this.DgvColMetadataKey.Name = "DgvColMetadataKey";
            this.DgvColMetadataKey.ToolTipText = "The metadata key, for example \"UploaderName\" or \"Project\"";
            this.DgvColMetadataKey.Width = 150;
            // 
            // DgvColMetadataValue
            // 
            this.DgvColMetadataValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DgvColMetadataValue.HeaderText = "Value";
            this.DgvColMetadataValue.Name = "DgvColMetadataValue";
            this.DgvColMetadataValue.ToolTipText = "The metadata value.  For example, \"John Doe\" or \"MEA Project\"";
            // 
            // GrpContent
            // 
            this.GrpContent.Controls.Add(this.LblType);
            this.GrpContent.Controls.Add(this.TxtEncoding);
            this.GrpContent.Controls.Add(this.TxtDisposition);
            this.GrpContent.Controls.Add(this.DatePickerExpires);
            this.GrpContent.Controls.Add(this.LblEncoding);
            this.GrpContent.Controls.Add(this.TxtType);
            this.GrpContent.Controls.Add(this.LblExpires);
            this.GrpContent.Controls.Add(this.LblDisposition);
            this.GrpContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpContent.Location = new System.Drawing.Point(3, 246);
            this.GrpContent.Name = "GrpContent";
            this.GrpContent.Size = new System.Drawing.Size(534, 131);
            this.GrpContent.TabIndex = 2;
            this.GrpContent.TabStop = false;
            this.GrpContent.Text = "Content Headers";
            this.ToolTipMain.SetToolTip(this.GrpContent, "Values for the HTTP headers sent to S3 when uploading this object\'s parts.");
            // 
            // LblType
            // 
            this.LblType.AutoSize = true;
            this.LblType.Location = new System.Drawing.Point(33, 22);
            this.LblType.Name = "LblType";
            this.LblType.Size = new System.Drawing.Size(34, 13);
            this.LblType.TabIndex = 6;
            this.LblType.Text = "Type:";
            this.ToolTipMain.SetToolTip(this.LblType, "A standard MIME type describing the format of the object data.");
            // 
            // TxtEncoding
            // 
            this.TxtEncoding.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ErrorMain.SetIconPadding(this.TxtEncoding, 3);
            this.TxtEncoding.Location = new System.Drawing.Point(73, 71);
            this.TxtEncoding.Name = "TxtEncoding";
            this.TxtEncoding.Size = new System.Drawing.Size(439, 20);
            this.TxtEncoding.TabIndex = 2;
            this.ToolTipMain.SetToolTip(this.TxtEncoding, "Specifies what content encodings have been applied to the object and thus what de" +
        "coding mechanisms must be applied to obtain the media-type referenced by the Con" +
        "tent-Type header field.");
            // 
            // TxtDisposition
            // 
            this.TxtDisposition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ErrorMain.SetIconPadding(this.TxtDisposition, 3);
            this.TxtDisposition.Location = new System.Drawing.Point(73, 45);
            this.TxtDisposition.Name = "TxtDisposition";
            this.TxtDisposition.Size = new System.Drawing.Size(439, 20);
            this.TxtDisposition.TabIndex = 1;
            this.ToolTipMain.SetToolTip(this.TxtDisposition, "Specifies presentational information for the object.");
            // 
            // DatePickerExpires
            // 
            this.DatePickerExpires.Location = new System.Drawing.Point(73, 97);
            this.DatePickerExpires.Name = "DatePickerExpires";
            this.DatePickerExpires.Size = new System.Drawing.Size(211, 20);
            this.DatePickerExpires.TabIndex = 3;
            this.ToolTipMain.SetToolTip(this.DatePickerExpires, "The date and time at which the object is no longer cacheable.");
            // 
            // LblEncoding
            // 
            this.LblEncoding.AutoSize = true;
            this.LblEncoding.Location = new System.Drawing.Point(12, 74);
            this.LblEncoding.Name = "LblEncoding";
            this.LblEncoding.Size = new System.Drawing.Size(55, 13);
            this.LblEncoding.TabIndex = 2;
            this.LblEncoding.Text = "Encoding:";
            this.ToolTipMain.SetToolTip(this.LblEncoding, "Specifies what content encodings have been applied to the object and thus what de" +
        "coding mechanisms must be applied to obtain the media-type referenced by the Con" +
        "tent-Type header field.");
            // 
            // TxtType
            // 
            this.TxtType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ErrorMain.SetIconPadding(this.TxtType, 3);
            this.TxtType.Location = new System.Drawing.Point(73, 19);
            this.TxtType.Name = "TxtType";
            this.TxtType.Size = new System.Drawing.Size(439, 20);
            this.TxtType.TabIndex = 0;
            this.ToolTipMain.SetToolTip(this.TxtType, "A standard MIME type describing the format of the object data.");
            // 
            // LblExpires
            // 
            this.LblExpires.AutoSize = true;
            this.LblExpires.Location = new System.Drawing.Point(23, 100);
            this.LblExpires.Name = "LblExpires";
            this.LblExpires.Size = new System.Drawing.Size(44, 13);
            this.LblExpires.TabIndex = 30;
            this.LblExpires.Text = "Expires:";
            this.ToolTipMain.SetToolTip(this.LblExpires, "The date and time at which the object is no longer cacheable.");
            // 
            // LblDisposition
            // 
            this.LblDisposition.AutoSize = true;
            this.LblDisposition.Location = new System.Drawing.Point(6, 48);
            this.LblDisposition.Name = "LblDisposition";
            this.LblDisposition.Size = new System.Drawing.Size(61, 13);
            this.LblDisposition.TabIndex = 0;
            this.LblDisposition.Text = "Disposition:";
            this.ToolTipMain.SetToolTip(this.LblDisposition, "Specifies presentational information for the object.");
            // 
            // GrpAccessCtrl
            // 
            this.GrpAccessCtrl.Controls.Add(this.LblUseCannedACL);
            this.GrpAccessCtrl.Controls.Add(this.ChkUseCannedACLs);
            this.GrpAccessCtrl.Controls.Add(this.ComboAcl);
            this.GrpAccessCtrl.Controls.Add(this.LblAcl);
            this.GrpAccessCtrl.Controls.Add(this.DgvGrants);
            this.GrpAccessCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpAccessCtrl.Location = new System.Drawing.Point(3, 383);
            this.GrpAccessCtrl.Name = "GrpAccessCtrl";
            this.GrpAccessCtrl.Size = new System.Drawing.Size(534, 131);
            this.GrpAccessCtrl.TabIndex = 3;
            this.GrpAccessCtrl.TabStop = false;
            this.GrpAccessCtrl.Text = "Grants";
            this.ToolTipMain.SetToolTip(this.GrpAccessCtrl, "Grant additional permissions to specific grantees.");
            // 
            // LblUseCannedACL
            // 
            this.LblUseCannedACL.AutoSize = true;
            this.LblUseCannedACL.Location = new System.Drawing.Point(6, 25);
            this.LblUseCannedACL.Name = "LblUseCannedACL";
            this.LblUseCannedACL.Size = new System.Drawing.Size(95, 13);
            this.LblUseCannedACL.TabIndex = 8;
            this.LblUseCannedACL.Text = "Use Canned ACL?";
            this.ToolTipMain.SetToolTip(this.LblUseCannedACL, "Should access permissions be granted using Canned Access Control Lists (Canned AC" +
        "Ls), or by specifying grantees explicitly?");
            // 
            // ChkUseCannedACLs
            // 
            this.ChkUseCannedACLs.AutoSize = true;
            this.ChkUseCannedACLs.Location = new System.Drawing.Point(107, 25);
            this.ChkUseCannedACLs.Name = "ChkUseCannedACLs";
            this.ChkUseCannedACLs.Size = new System.Drawing.Size(15, 14);
            this.ChkUseCannedACLs.TabIndex = 7;
            this.ToolTipMain.SetToolTip(this.ChkUseCannedACLs, "Should access permissions be granted using Canned Access Control Lists (Canned AC" +
        "Ls), or by specifying grantees explicitly?");
            this.ChkUseCannedACLs.UseVisualStyleBackColor = true;
            this.ChkUseCannedACLs.CheckedChanged += new System.EventHandler(this.ChkCannedACLs_CheckedChanged);
            // 
            // ComboAcl
            // 
            this.ComboAcl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboAcl.Enabled = false;
            this.ComboAcl.FormattingEnabled = true;
            this.ComboAcl.Items.AddRange(new object[] {
            "private",
            "public-read",
            "public-read-write",
            "authenticated-read",
            "aws-exec-read",
            "bucket-owner-read",
            "bucket-owner-full-control"});
            this.ComboAcl.Location = new System.Drawing.Point(107, 45);
            this.ComboAcl.Name = "ComboAcl";
            this.ComboAcl.Size = new System.Drawing.Size(177, 21);
            this.ComboAcl.TabIndex = 6;
            this.ToolTipMain.SetToolTip(this.ComboAcl, "The canned Access Control List (ACL) to apply to the object.");
            // 
            // LblAcl
            // 
            this.LblAcl.AutoSize = true;
            this.LblAcl.Enabled = false;
            this.LblAcl.Location = new System.Drawing.Point(31, 48);
            this.LblAcl.Name = "LblAcl";
            this.LblAcl.Size = new System.Drawing.Size(70, 13);
            this.LblAcl.TabIndex = 5;
            this.LblAcl.Text = "Canned ACL:";
            this.ToolTipMain.SetToolTip(this.LblAcl, "The canned Access Control List (ACL) to apply to the object.");
            // 
            // DgvGrants
            // 
            this.DgvGrants.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvGrants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvGrants.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgvColGranteeType,
            this.DgvColGrantee,
            this.DgvColCanRead,
            this.DgvColCanReadAcl,
            this.DgvColCanWriteAcl});
            this.DgvGrants.Location = new System.Drawing.Point(3, 72);
            this.DgvGrants.Name = "DgvGrants";
            this.DgvGrants.Size = new System.Drawing.Size(528, 59);
            this.DgvGrants.TabIndex = 1;
            this.DgvGrants.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.DgvGrants_DefaultValuesNeeded);
            // 
            // GrpSse
            // 
            this.GrpSse.Controls.Add(this.TxtSseKeyId);
            this.GrpSse.Controls.Add(this.TxtSseCustomerKeyMd5);
            this.GrpSse.Controls.Add(this.TxtSseCustomerKey);
            this.GrpSse.Controls.Add(this.RadioSseKms);
            this.GrpSse.Controls.Add(this.RadioSseNewKey);
            this.GrpSse.Controls.Add(this.RadioSseNone);
            this.GrpSse.Controls.Add(this.LblSseKeyId);
            this.GrpSse.Controls.Add(this.LblSseCustomerKeyMd5);
            this.GrpSse.Controls.Add(this.LblSseCustomerKey);
            this.GrpSse.Controls.Add(this.LblEncryption);
            this.GrpSse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpSse.Location = new System.Drawing.Point(3, 520);
            this.GrpSse.Name = "GrpSse";
            this.GrpSse.Size = new System.Drawing.Size(534, 129);
            this.GrpSse.TabIndex = 4;
            this.GrpSse.TabStop = false;
            this.GrpSse.Text = "Server-Side Encryption";
            this.ToolTipMain.SetToolTip(this.GrpSse, "Options for requesting S3 to encrypt data at rest.  If chosen, S3 will encrypt yo" +
        "ur data as it writes it to disks in its data centers and decrypt it for you when" +
        " you access it.");
            // 
            // TxtSseKeyId
            // 
            this.TxtSseKeyId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtSseKeyId.Enabled = false;
            this.ErrorMain.SetIconPadding(this.TxtSseKeyId, 3);
            this.TxtSseKeyId.Location = new System.Drawing.Point(91, 44);
            this.TxtSseKeyId.Multiline = true;
            this.TxtSseKeyId.Name = "TxtSseKeyId";
            this.TxtSseKeyId.Size = new System.Drawing.Size(421, 20);
            this.TxtSseKeyId.TabIndex = 6;
            this.ToolTipMain.SetToolTip(this.TxtSseKeyId, "The ID of the AWS Key Management Service (KMS) master encryption key for this obj" +
        "ect.\r\nIf you leave this field blank then S3 will use a default encryption key.");
            // 
            // TxtSseCustomerKeyMd5
            // 
            this.TxtSseCustomerKeyMd5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtSseCustomerKeyMd5.Enabled = false;
            this.ErrorMain.SetIconPadding(this.TxtSseCustomerKeyMd5, 3);
            this.TxtSseCustomerKeyMd5.Location = new System.Drawing.Point(91, 97);
            this.TxtSseCustomerKeyMd5.Multiline = true;
            this.TxtSseCustomerKeyMd5.Name = "TxtSseCustomerKeyMd5";
            this.TxtSseCustomerKeyMd5.Size = new System.Drawing.Size(421, 20);
            this.TxtSseCustomerKeyMd5.TabIndex = 5;
            this.ToolTipMain.SetToolTip(this.TxtSseCustomerKeyMd5, resources.GetString("TxtSseCustomerKeyMd5.ToolTip"));
            // 
            // TxtSseCustomerKey
            // 
            this.TxtSseCustomerKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtSseCustomerKey.Enabled = false;
            this.ErrorMain.SetIconPadding(this.TxtSseCustomerKey, 3);
            this.TxtSseCustomerKey.Location = new System.Drawing.Point(91, 71);
            this.TxtSseCustomerKey.Multiline = true;
            this.TxtSseCustomerKey.Name = "TxtSseCustomerKey";
            this.TxtSseCustomerKey.Size = new System.Drawing.Size(421, 20);
            this.TxtSseCustomerKey.TabIndex = 3;
            this.ToolTipMain.SetToolTip(this.TxtSseCustomerKey, "The new base64-encoded encryption key for Amazon S3 to use in encrypting data.\r\nT" +
        "his value is used to store the object and then is discarded; Amazon does not sto" +
        "re the encryption key.\r\n");
            // 
            // RadioSseKms
            // 
            this.RadioSseKms.AutoSize = true;
            this.RadioSseKms.Location = new System.Drawing.Point(148, 21);
            this.RadioSseKms.Name = "RadioSseKms";
            this.RadioSseKms.Size = new System.Drawing.Size(76, 17);
            this.RadioSseKms.TabIndex = 2;
            this.RadioSseKms.Text = "AWS KMS";
            this.ToolTipMain.SetToolTip(this.RadioSseKms, "Object data will be encrypted using a Key Management Service (KMS) key.");
            this.RadioSseKms.UseVisualStyleBackColor = true;
            this.RadioSseKms.CheckedChanged += new System.EventHandler(this.RadioKMS_CheckedChanged);
            // 
            // RadioSseNewKey
            // 
            this.RadioSseNewKey.AutoSize = true;
            this.RadioSseNewKey.Location = new System.Drawing.Point(230, 21);
            this.RadioSseNewKey.Name = "RadioSseNewKey";
            this.RadioSseNewKey.Size = new System.Drawing.Size(68, 17);
            this.RadioSseNewKey.TabIndex = 1;
            this.RadioSseNewKey.Text = "New Key";
            this.ToolTipMain.SetToolTip(this.RadioSseNewKey, "Object data will be encrypted using a new key that you provide.");
            this.RadioSseNewKey.UseVisualStyleBackColor = true;
            this.RadioSseNewKey.CheckedChanged += new System.EventHandler(this.RadioNewKey_CheckedChanged);
            // 
            // RadioSseNone
            // 
            this.RadioSseNone.AutoSize = true;
            this.RadioSseNone.Location = new System.Drawing.Point(91, 21);
            this.RadioSseNone.Name = "RadioSseNone";
            this.RadioSseNone.Size = new System.Drawing.Size(51, 17);
            this.RadioSseNone.TabIndex = 0;
            this.RadioSseNone.Text = "None";
            this.ToolTipMain.SetToolTip(this.RadioSseNone, "Object data will not be encrypted on S3 servers.");
            this.RadioSseNone.UseVisualStyleBackColor = true;
            this.RadioSseNone.CheckedChanged += new System.EventHandler(this.RadioNone_CheckedChanged);
            // 
            // LblSseKeyId
            // 
            this.LblSseKeyId.AutoSize = true;
            this.LblSseKeyId.Enabled = false;
            this.LblSseKeyId.Location = new System.Drawing.Point(45, 47);
            this.LblSseKeyId.Name = "LblSseKeyId";
            this.LblSseKeyId.Size = new System.Drawing.Size(40, 13);
            this.LblSseKeyId.TabIndex = 4;
            this.LblSseKeyId.Text = "Key Id:";
            this.ToolTipMain.SetToolTip(this.LblSseKeyId, "The ID of the AWS Key Management Service (KMS) master encryption key for this obj" +
        "ect.\r\nIf you leave this field blank then S3 will use a default encryption key.");
            // 
            // LblSseCustomerKeyMd5
            // 
            this.LblSseCustomerKeyMd5.AutoSize = true;
            this.LblSseCustomerKeyMd5.Enabled = false;
            this.LblSseCustomerKeyMd5.Location = new System.Drawing.Point(6, 100);
            this.LblSseCustomerKeyMd5.Name = "LblSseCustomerKeyMd5";
            this.LblSseCustomerKeyMd5.Size = new System.Drawing.Size(79, 13);
            this.LblSseCustomerKeyMd5.TabIndex = 3;
            this.LblSseCustomerKeyMd5.Text = "New Key MD5:";
            this.ToolTipMain.SetToolTip(this.LblSseCustomerKeyMd5, resources.GetString("LblSseCustomerKeyMd5.ToolTip"));
            // 
            // LblSseCustomerKey
            // 
            this.LblSseCustomerKey.AutoSize = true;
            this.LblSseCustomerKey.Enabled = false;
            this.LblSseCustomerKey.Location = new System.Drawing.Point(32, 74);
            this.LblSseCustomerKey.Name = "LblSseCustomerKey";
            this.LblSseCustomerKey.Size = new System.Drawing.Size(53, 13);
            this.LblSseCustomerKey.TabIndex = 2;
            this.LblSseCustomerKey.Text = "New Key:";
            this.ToolTipMain.SetToolTip(this.LblSseCustomerKey, "The new base64-encoded encryption key for Amazon S3 to use in encrypting data.\r\nT" +
        "his value is used to store the object and then is discarded; Amazon does not sto" +
        "re the encryption key.");
            // 
            // LblEncryption
            // 
            this.LblEncryption.AutoSize = true;
            this.LblEncryption.Location = new System.Drawing.Point(25, 23);
            this.LblEncryption.Name = "LblEncryption";
            this.LblEncryption.Size = new System.Drawing.Size(60, 13);
            this.LblEncryption.TabIndex = 0;
            this.LblEncryption.Text = "Encryption:";
            this.ToolTipMain.SetToolTip(this.LblEncryption, "The method of encryption used when storing this object in S3.");
            // 
            // RadioStandardIA
            // 
            this.RadioStandardIA.AutoSize = true;
            this.RadioStandardIA.Location = new System.Drawing.Point(364, 29);
            this.RadioStandardIA.Name = "RadioStandardIA";
            this.RadioStandardIA.Size = new System.Drawing.Size(163, 17);
            this.RadioStandardIA.TabIndex = 3;
            this.RadioStandardIA.Text = "Standard (Infrequent Access)";
            this.ToolTipMain.SetToolTip(this.RadioStandardIA, resources.GetString("RadioStandardIA.ToolTip"));
            this.RadioStandardIA.UseVisualStyleBackColor = true;
            // 
            // RadioReducedRedund
            // 
            this.RadioReducedRedund.AutoSize = true;
            this.RadioReducedRedund.Location = new System.Drawing.Point(225, 29);
            this.RadioReducedRedund.Name = "RadioReducedRedund";
            this.RadioReducedRedund.Size = new System.Drawing.Size(133, 17);
            this.RadioReducedRedund.TabIndex = 2;
            this.RadioReducedRedund.Text = "Reduced Redundancy";
            this.ToolTipMain.SetToolTip(this.RadioReducedRedund, "The Reduced Redundancy Storage (RRS) storage class is designed for noncritical, r" +
        "eproducible data stored at lower levels of redundancy than the STANDARD storage " +
        "class, which reduces storage costs.");
            this.RadioReducedRedund.UseVisualStyleBackColor = true;
            // 
            // RadioStandard
            // 
            this.RadioStandard.AutoSize = true;
            this.RadioStandard.Checked = true;
            this.RadioStandard.Location = new System.Drawing.Point(151, 29);
            this.RadioStandard.Name = "RadioStandard";
            this.RadioStandard.Size = new System.Drawing.Size(68, 17);
            this.RadioStandard.TabIndex = 1;
            this.RadioStandard.TabStop = true;
            this.RadioStandard.Text = "Standard";
            this.ToolTipMain.SetToolTip(this.RadioStandard, "This storage class is ideal for performance-sensitive use cases and frequently ac" +
        "cessed data.");
            this.RadioStandard.UseVisualStyleBackColor = true;
            // 
            // LblRequestPayer
            // 
            this.LblRequestPayer.AutoSize = true;
            this.LblRequestPayer.Location = new System.Drawing.Point(57, 78);
            this.LblRequestPayer.Name = "LblRequestPayer";
            this.LblRequestPayer.Size = new System.Drawing.Size(88, 13);
            this.LblRequestPayer.TabIndex = 32;
            this.LblRequestPayer.Text = "Requester Pays?";
            this.ToolTipMain.SetToolTip(this.LblRequestPayer, "Confirms that the requester knows that she or he will be charged for the request." +
        " Bucket owners need not specify this parameter in their requests.\r\n");
            // 
            // TxtWebsite
            // 
            this.TxtWebsite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ErrorMain.SetIconPadding(this.TxtWebsite, 3);
            this.TxtWebsite.Location = new System.Drawing.Point(151, 52);
            this.TxtWebsite.Name = "TxtWebsite";
            this.TxtWebsite.Size = new System.Drawing.Size(361, 20);
            this.TxtWebsite.TabIndex = 5;
            this.ToolTipMain.SetToolTip(this.TxtWebsite, "If the bucket is configured as a website, then requests for this object are redir" +
        "ected to this URL (possibly another object in the same bucket).");
            // 
            // LblWebsite
            // 
            this.LblWebsite.AutoSize = true;
            this.LblWebsite.Location = new System.Drawing.Point(9, 55);
            this.LblWebsite.Name = "LblWebsite";
            this.LblWebsite.Size = new System.Drawing.Size(136, 13);
            this.LblWebsite.TabIndex = 28;
            this.LblWebsite.Text = "Website Redirect Location:";
            this.ToolTipMain.SetToolTip(this.LblWebsite, "If the bucket is configured as a website, then requests for this object are redir" +
        "ected to this URL (possibly another object in the same bucket).");
            // 
            // LblStorageClass
            // 
            this.LblStorageClass.AutoSize = true;
            this.LblStorageClass.Location = new System.Drawing.Point(70, 31);
            this.LblStorageClass.Name = "LblStorageClass";
            this.LblStorageClass.Size = new System.Drawing.Size(75, 13);
            this.LblStorageClass.TabIndex = 22;
            this.LblStorageClass.Text = "Storage Class:";
            this.ToolTipMain.SetToolTip(this.LblStorageClass, "The type of storage to use for the object.");
            // 
            // PnlBottom
            // 
            this.PnlBottom.Controls.Add(this.BtnCancel);
            this.PnlBottom.Controls.Add(this.BtnSave);
            this.PnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlBottom.Location = new System.Drawing.Point(3, 655);
            this.PnlBottom.Name = "PnlBottom";
            this.PnlBottom.Size = new System.Drawing.Size(534, 34);
            this.PnlBottom.TabIndex = 5;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancel.AutoSize = true;
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(456, 8);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 1;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSave.AutoSize = true;
            this.BtnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnSave.Location = new System.Drawing.Point(375, 8);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 0;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
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
            this.TblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.TblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 137F));
            this.TblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 135F));
            this.TblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.TblLayoutMain.Size = new System.Drawing.Size(540, 692);
            this.TblLayoutMain.TabIndex = 0;
            // 
            // PnlTop
            // 
            this.PnlTop.Controls.Add(this.ChkRequestPayer);
            this.PnlTop.Controls.Add(this.RadioStandardIA);
            this.PnlTop.Controls.Add(this.RadioReducedRedund);
            this.PnlTop.Controls.Add(this.RadioStandard);
            this.PnlTop.Controls.Add(this.LblRequestPayer);
            this.PnlTop.Controls.Add(this.TxtWebsite);
            this.PnlTop.Controls.Add(this.LblWebsite);
            this.PnlTop.Controls.Add(this.LblAsynchronous);
            this.PnlTop.Controls.Add(this.ChkAsynchronous);
            this.PnlTop.Controls.Add(this.LblStorageClass);
            this.PnlTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlTop.Location = new System.Drawing.Point(3, 3);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(534, 100);
            this.PnlTop.TabIndex = 0;
            // 
            // ErrorMain
            // 
            this.ErrorMain.ContainerControl = this;
            // 
            // DgvColGranteeType
            // 
            this.DgvColGranteeType.HeaderText = "Grantee Type";
            this.DgvColGranteeType.Items.AddRange(new object[] {
            "Canonical User ID",
            "Email Address",
            "Group"});
            this.DgvColGranteeType.Name = "DgvColGranteeType";
            this.DgvColGranteeType.ToolTipText = "The type of grantee.  You may specify grantees by the Email address of an AWS acc" +
    "ount, the canonical user ID of an AWS account, or the URI of a predefined group." +
    "";
            this.DgvColGranteeType.Width = 125;
            // 
            // DgvColGrantee
            // 
            this.DgvColGrantee.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DgvColGrantee.HeaderText = "Grantee";
            this.DgvColGrantee.Name = "DgvColGrantee";
            // 
            // DgvColCanRead
            // 
            this.DgvColCanRead.HeaderText = "Can Read";
            this.DgvColCanRead.Name = "DgvColCanRead";
            this.DgvColCanRead.ToolTipText = "Allow grantee to read the object data and its metadata.";
            this.DgvColCanRead.Width = 65;
            // 
            // DgvColCanReadAcl
            // 
            this.DgvColCanReadAcl.HeaderText = "Can Read ACL";
            this.DgvColCanReadAcl.Name = "DgvColCanReadAcl";
            this.DgvColCanReadAcl.ToolTipText = "Allow grantee to read the object ACL.";
            this.DgvColCanReadAcl.Width = 85;
            // 
            // DgvColCanWriteAcl
            // 
            this.DgvColCanWriteAcl.HeaderText = "Can Write ACL";
            this.DgvColCanWriteAcl.Name = "DgvColCanWriteAcl";
            this.DgvColCanWriteAcl.ToolTipText = "Allow grantee to write the ACL for the applicable object.";
            this.DgvColCanWriteAcl.Width = 85;
            // 
            // AdvancedOptionsForm
            // 
            this.AcceptButton = this.BtnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(540, 692);
            this.Controls.Add(this.TblLayoutMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(555, 705);
            this.Name = "AdvancedOptionsForm";
            this.ShowInTaskbar = false;
            this.GrpMetadata.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvMetadata)).EndInit();
            this.GrpContent.ResumeLayout(false);
            this.GrpContent.PerformLayout();
            this.GrpAccessCtrl.ResumeLayout(false);
            this.GrpAccessCtrl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGrants)).EndInit();
            this.GrpSse.ResumeLayout(false);
            this.GrpSse.PerformLayout();
            this.PnlBottom.ResumeLayout(false);
            this.PnlBottom.PerformLayout();
            this.TblLayoutMain.ResumeLayout(false);
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
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.TableLayoutPanel TblLayoutMain;
        private System.Windows.Forms.GroupBox GrpContent;
        private System.Windows.Forms.GroupBox GrpAccessCtrl;
        private System.Windows.Forms.GroupBox GrpSse;
        private System.Windows.Forms.DataGridView DgvMetadata;
        private System.Windows.Forms.Panel PnlTop;
        private System.Windows.Forms.Label LblExpires;
        private System.Windows.Forms.TextBox TxtWebsite;
        private System.Windows.Forms.Label LblWebsite;
        private System.Windows.Forms.Label LblAsynchronous;
        private System.Windows.Forms.CheckBox ChkAsynchronous;
        private System.Windows.Forms.Label LblStorageClass;
        private System.Windows.Forms.Label LblRequestPayer;
        private System.Windows.Forms.Label LblType;
        private System.Windows.Forms.TextBox TxtEncoding;
        private System.Windows.Forms.TextBox TxtDisposition;
        private System.Windows.Forms.Label LblEncoding;
        private System.Windows.Forms.TextBox TxtType;
        private System.Windows.Forms.Label LblDisposition;
        private System.Windows.Forms.DateTimePicker DatePickerExpires;
        private System.Windows.Forms.Label LblEncryption;
        private System.Windows.Forms.RadioButton RadioStandardIA;
        private System.Windows.Forms.RadioButton RadioReducedRedund;
        private System.Windows.Forms.RadioButton RadioStandard;
        private System.Windows.Forms.Label LblSseKeyId;
        private System.Windows.Forms.Label LblSseCustomerKeyMd5;
        private System.Windows.Forms.Label LblSseCustomerKey;
        private System.Windows.Forms.RadioButton RadioSseKms;
        private System.Windows.Forms.RadioButton RadioSseNewKey;
        private System.Windows.Forms.RadioButton RadioSseNone;
        private System.Windows.Forms.TextBox TxtSseCustomerKeyMd5;
        private System.Windows.Forms.TextBox TxtSseCustomerKey;
        private System.Windows.Forms.ErrorProvider ErrorMain;
        private System.Windows.Forms.CheckBox ChkRequestPayer;
        private System.Windows.Forms.DataGridView DgvGrants;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColMetadataKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColMetadataValue;
        private System.Windows.Forms.TextBox TxtSseKeyId;
        private System.Windows.Forms.Label LblUseCannedACL;
        private System.Windows.Forms.CheckBox ChkUseCannedACLs;
        private System.Windows.Forms.ComboBox ComboAcl;
        private System.Windows.Forms.Label LblAcl;
        private System.Windows.Forms.DataGridViewComboBoxColumn DgvColGranteeType;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColGrantee;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DgvColCanRead;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DgvColCanReadAcl;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DgvColCanWriteAcl;
    }
}