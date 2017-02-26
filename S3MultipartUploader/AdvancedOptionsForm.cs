using System;
using System.Windows.Forms;

namespace S3MultipartUploader {

    public partial class AdvancedOptionsForm : Form {

        public AdvancedOptionsForm() {
            InitializeComponent();

            initializeDatePicker();
            ComboAcl.SelectedIndex = 0;
        }

        private void RadioKMS_CheckedChanged(object sender, EventArgs e) {
            resetKmsCtrls(RadioKMS.Checked);
        }

        private void initializeDatePicker() {
            DatePickerExpires.MinDate = DateTime.Now;
            DatePickerExpires.Value = DatePickerExpires.MaxDate;
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
