using System;
using System.Windows.Forms;

namespace S3MultipartUploader {

    public partial class AdvancedOptionsForm : Form {

        public AdvancedOptionsForm() {
            InitializeComponent();

            DatePickerExpires.MinDate = DateTime.Now;
            ComboAcl.SelectedIndex = 0;
        }

        private void RadioKMS_CheckedChanged(object sender, EventArgs e) {
            resetKmsCtrls(RadioKMS.Checked);
        }

        private void resetKmsCtrls(bool enabled) {
            LblSseKey.Enabled = enabled;
            LblSseAlgorithm.Enabled = enabled;
            LblSseKeyMd5.Enabled = enabled;
            LblSseKeyId.Enabled = enabled;

            TxtSseKey.Enabled = enabled;
            TxtSseAlgorithm.Enabled = enabled;
            TxtSseKeyMd5.Enabled = enabled;
            TxtSseKeyId.Enabled = enabled;
        }

    }

}
