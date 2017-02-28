using System;
using System.Net.Mail;
using System.Threading;
using System.Windows.Forms;

using S3MultipartUploader.Properties;

using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;

namespace S3MultipartUploader {

    public partial class ErrorForm : Form {

        private CancellationTokenSource _cts = new CancellationTokenSource();

        public ErrorForm() {
            InitializeComponent();
        }

        private void BtnSendReport_Click(object sender, EventArgs e) {
            // Get message subject/body/from-address
            string subject = TxtSubject.Text;
            string from = TxtFrom.Text;
            string msg = TxtBody.Text;

            // If a From address was provided then append it to the message body
            if (from != "")
                msg += from;

            publishToSns(subject, msg);
        }
        private void ChkSendReport_CheckedChanged(object sender, EventArgs e) {
            SplitMain.Panel2.Enabled = ChkSendReport.Checked;
        }
        private async void publishToSns(string subject, string message) {
            try {
                // Get the error SNS Topic
                Settings settings = Settings.Default;
                var sns = new AmazonSimpleNotificationServiceClient();
                Topic topic = await sns.FindTopicAsync(settings.ErrorSnsTopic);

                // Publish to that Topic
                var request = new PublishRequest(topic.TopicArn, message, subject);
                PublishResponse response = await sns.PublishAsync(request, _cts.Token);
            }
            catch (Exception) { }
        }
    }
}
