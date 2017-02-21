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
            this.panel1 = new System.Windows.Forms.Panel();
            this.LblAsynchronous = new System.Windows.Forms.Label();
            this.UpDownRetries = new System.Windows.Forms.NumericUpDown();
            this.LblNumRetries = new System.Windows.Forms.Label();
            this.ChkAsynchronous = new System.Windows.Forms.CheckBox();
            this.ComboStorageClass = new System.Windows.Forms.ComboBox();
            this.LblStorageClass = new System.Windows.Forms.Label();
            this.LblWebsite = new System.Windows.Forms.Label();
            this.TxtWebsite = new System.Windows.Forms.TextBox();
            this.LblExpires = new System.Windows.Forms.Label();
            this.UpDownExpires = new System.Windows.Forms.NumericUpDown();
            this.LblRequestPayer = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.GrpMetadata.SuspendLayout();
            this.PnlBottom.SuspendLayout();
            this.TblLayoutMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvMetadata)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownRetries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownExpires)).BeginInit();
            this.SuspendLayout();
            // 
            // GrpMetadata
            // 
            this.GrpMetadata.Controls.Add(this.DgvMetadata);
            this.GrpMetadata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpMetadata.Location = new System.Drawing.Point(3, 126);
            this.GrpMetadata.Name = "GrpMetadata";
            this.GrpMetadata.Size = new System.Drawing.Size(528, 68);
            this.GrpMetadata.TabIndex = 22;
            this.GrpMetadata.TabStop = false;
            this.GrpMetadata.Text = "Metadata";
            // 
            // PnlBottom
            // 
            this.PnlBottom.Controls.Add(this.BtnCancel);
            this.PnlBottom.Controls.Add(this.BtnOK);
            this.PnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlBottom.Location = new System.Drawing.Point(3, 468);
            this.PnlBottom.Name = "PnlBottom";
            this.PnlBottom.Size = new System.Drawing.Size(528, 42);
            this.PnlBottom.TabIndex = 0;
            // 
            // BtnOK
            // 
            this.BtnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnOK.AutoSize = true;
            this.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnOK.Location = new System.Drawing.Point(363, 10);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(75, 23);
            this.BtnOK.TabIndex = 19;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancel.AutoSize = true;
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(444, 10);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 20;
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
            this.TblLayoutMain.Controls.Add(this.panel1, 0, 0);
            this.TblLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TblLayoutMain.Location = new System.Drawing.Point(0, 0);
            this.TblLayoutMain.Name = "TblLayoutMain";
            this.TblLayoutMain.RowCount = 6;
            this.TblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.TblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.TblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.TblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.TblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.TblLayoutMain.Size = new System.Drawing.Size(534, 513);
            this.TblLayoutMain.TabIndex = 22;
            // 
            // GrpContent
            // 
            this.GrpContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpContent.Location = new System.Drawing.Point(3, 200);
            this.GrpContent.Name = "GrpContent";
            this.GrpContent.Size = new System.Drawing.Size(528, 94);
            this.GrpContent.TabIndex = 23;
            this.GrpContent.TabStop = false;
            this.GrpContent.Text = "Content";
            // 
            // GrpAccessCtrl
            // 
            this.GrpAccessCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpAccessCtrl.Location = new System.Drawing.Point(3, 300);
            this.GrpAccessCtrl.Name = "GrpAccessCtrl";
            this.GrpAccessCtrl.Size = new System.Drawing.Size(528, 79);
            this.GrpAccessCtrl.TabIndex = 24;
            this.GrpAccessCtrl.TabStop = false;
            this.GrpAccessCtrl.Text = "Access Control";
            // 
            // GrpSse
            // 
            this.GrpSse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpSse.Location = new System.Drawing.Point(3, 385);
            this.GrpSse.Name = "GrpSse";
            this.GrpSse.Size = new System.Drawing.Size(528, 77);
            this.GrpSse.TabIndex = 25;
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
            this.DgvMetadata.Size = new System.Drawing.Size(522, 49);
            this.DgvMetadata.TabIndex = 2;
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
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.LblRequestPayer);
            this.panel1.Controls.Add(this.UpDownExpires);
            this.panel1.Controls.Add(this.LblExpires);
            this.panel1.Controls.Add(this.TxtWebsite);
            this.panel1.Controls.Add(this.LblWebsite);
            this.panel1.Controls.Add(this.LblAsynchronous);
            this.panel1.Controls.Add(this.UpDownRetries);
            this.panel1.Controls.Add(this.LblNumRetries);
            this.panel1.Controls.Add(this.ChkAsynchronous);
            this.panel1.Controls.Add(this.ComboStorageClass);
            this.panel1.Controls.Add(this.LblStorageClass);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(528, 117);
            this.panel1.TabIndex = 26;
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
            // UpDownRetries
            // 
            this.UpDownRetries.Location = new System.Drawing.Point(257, 7);
            this.UpDownRetries.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.UpDownRetries.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.UpDownRetries.Name = "UpDownRetries";
            this.UpDownRetries.Size = new System.Drawing.Size(71, 20);
            this.UpDownRetries.TabIndex = 26;
            this.UpDownRetries.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // LblNumRetries
            // 
            this.LblNumRetries.AutoSize = true;
            this.LblNumRetries.Location = new System.Drawing.Point(183, 9);
            this.LblNumRetries.Name = "LblNumRetries";
            this.LblNumRetries.Size = new System.Drawing.Size(68, 13);
            this.LblNumRetries.TabIndex = 25;
            this.LblNumRetries.Text = "Num Retries:";
            // 
            // ChkAsynchronous
            // 
            this.ChkAsynchronous.AutoSize = true;
            this.ChkAsynchronous.Checked = true;
            this.ChkAsynchronous.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkAsynchronous.Location = new System.Drawing.Point(151, 9);
            this.ChkAsynchronous.Name = "ChkAsynchronous";
            this.ChkAsynchronous.Size = new System.Drawing.Size(15, 14);
            this.ChkAsynchronous.TabIndex = 24;
            this.ToolTipMain.SetToolTip(this.ChkAsynchronous, "If selected, then object parts will be uploaded in parallel.  Otherwise, parts wi" +
        "ll be uploaded one at a time.");
            this.ChkAsynchronous.UseVisualStyleBackColor = true;
            // 
            // ComboStorageClass
            // 
            this.ComboStorageClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboStorageClass.FormattingEnabled = true;
            this.ComboStorageClass.Items.AddRange(new object[] {
            "STANDARD",
            "STANDARD_IA",
            "GLACIER"});
            this.ComboStorageClass.Location = new System.Drawing.Point(151, 35);
            this.ComboStorageClass.Name = "ComboStorageClass";
            this.ComboStorageClass.Size = new System.Drawing.Size(100, 21);
            this.ComboStorageClass.TabIndex = 23;
            // 
            // LblStorageClass
            // 
            this.LblStorageClass.AutoSize = true;
            this.LblStorageClass.Location = new System.Drawing.Point(70, 38);
            this.LblStorageClass.Name = "LblStorageClass";
            this.LblStorageClass.Size = new System.Drawing.Size(75, 13);
            this.LblStorageClass.TabIndex = 22;
            this.LblStorageClass.Text = "Storage Class:";
            // 
            // LblWebsite
            // 
            this.LblWebsite.AutoSize = true;
            this.LblWebsite.Location = new System.Drawing.Point(9, 65);
            this.LblWebsite.Name = "LblWebsite";
            this.LblWebsite.Size = new System.Drawing.Size(136, 13);
            this.LblWebsite.TabIndex = 28;
            this.LblWebsite.Text = "Website Redirect Location:";
            // 
            // TxtWebsite
            // 
            this.TxtWebsite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtWebsite.Location = new System.Drawing.Point(151, 62);
            this.TxtWebsite.Name = "TxtWebsite";
            this.TxtWebsite.Size = new System.Drawing.Size(374, 20);
            this.TxtWebsite.TabIndex = 29;
            // 
            // LblExpires
            // 
            this.LblExpires.AutoSize = true;
            this.LblExpires.Location = new System.Drawing.Point(350, 9);
            this.LblExpires.Name = "LblExpires";
            this.LblExpires.Size = new System.Drawing.Size(44, 13);
            this.LblExpires.TabIndex = 30;
            this.LblExpires.Text = "Expires:";
            // 
            // UpDownExpires
            // 
            this.UpDownExpires.Location = new System.Drawing.Point(400, 7);
            this.UpDownExpires.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.UpDownExpires.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.UpDownExpires.Name = "UpDownExpires";
            this.UpDownExpires.Size = new System.Drawing.Size(71, 20);
            this.UpDownExpires.TabIndex = 31;
            this.UpDownExpires.ThousandsSeparator = true;
            this.UpDownExpires.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // LblRequestPayer
            // 
            this.LblRequestPayer.AutoSize = true;
            this.LblRequestPayer.Location = new System.Drawing.Point(65, 91);
            this.LblRequestPayer.Name = "LblRequestPayer";
            this.LblRequestPayer.Size = new System.Drawing.Size(80, 13);
            this.LblRequestPayer.TabIndex = 32;
            this.LblRequestPayer.Text = "Request Payer:";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(151, 88);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(374, 20);
            this.textBox1.TabIndex = 33;
            // 
            // AdvancedOptionsForm
            // 
            this.AcceptButton = this.BtnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(534, 513);
            this.Controls.Add(this.TblLayoutMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(550, 39);
            this.Name = "AdvancedOptionsForm";
            this.ShowInTaskbar = false;
            this.Text = "Advanced S3 Upload Options";
            this.GrpMetadata.ResumeLayout(false);
            this.PnlBottom.ResumeLayout(false);
            this.PnlBottom.PerformLayout();
            this.TblLayoutMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvMetadata)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownRetries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownExpires)).EndInit();
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown UpDownExpires;
        private System.Windows.Forms.Label LblExpires;
        private System.Windows.Forms.TextBox TxtWebsite;
        private System.Windows.Forms.Label LblWebsite;
        private System.Windows.Forms.Label LblAsynchronous;
        private System.Windows.Forms.NumericUpDown UpDownRetries;
        private System.Windows.Forms.Label LblNumRetries;
        private System.Windows.Forms.CheckBox ChkAsynchronous;
        private System.Windows.Forms.ComboBox ComboStorageClass;
        private System.Windows.Forms.Label LblStorageClass;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label LblRequestPayer;
    }
}