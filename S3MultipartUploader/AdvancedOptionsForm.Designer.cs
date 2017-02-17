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
            this.ChkAsynchronous = new System.Windows.Forms.CheckBox();
            this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
            this.BtnOK = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ChkAsynchronous
            // 
            this.ChkAsynchronous.AutoSize = true;
            this.ChkAsynchronous.Checked = true;
            this.ChkAsynchronous.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkAsynchronous.Location = new System.Drawing.Point(12, 12);
            this.ChkAsynchronous.Name = "ChkAsynchronous";
            this.ChkAsynchronous.Size = new System.Drawing.Size(137, 17);
            this.ChkAsynchronous.TabIndex = 18;
            this.ChkAsynchronous.Text = "Upload Asynchronously";
            this.ToolTipMain.SetToolTip(this.ChkAsynchronous, "If selected, then object parts will be uploaded in parallel.  Otherwise, parts wi" +
        "ll be uploaded one at a time.");
            this.ChkAsynchronous.UseVisualStyleBackColor = true;
            // 
            // BtnOK
            // 
            this.BtnOK.AutoSize = true;
            this.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnOK.Location = new System.Drawing.Point(116, 226);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(75, 23);
            this.BtnOK.TabIndex = 19;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            // 
            // BtnCancel
            // 
            this.BtnCancel.AutoSize = true;
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(197, 226);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 20;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // AdvancedOptionsForm
            // 
            this.AcceptButton = this.BtnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.ChkAsynchronous);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdvancedOptionsForm";
            this.Text = "Advanced S3 Upload Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ChkAsynchronous;
        private System.Windows.Forms.ToolTip ToolTipMain;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.Button BtnCancel;
    }
}