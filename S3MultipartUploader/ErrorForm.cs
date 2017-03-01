using System;
using System.Net.Mail;
using System.Threading;
using System.Windows.Forms;

using static S3MultipartUploader.Properties.Resources;

using Amazon;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;

namespace S3MultipartUploader {

    public partial class ErrorForm : Form {

        private CancellationTokenSource _cts = new CancellationTokenSource();

        public ErrorForm() {
            InitializeComponent();
        }
        public ErrorForm(Exception e) {
            InitializeComponent();

            TxtError.Text = e.ToString();
        }

        private void BtnSendReport_Click(object sender, EventArgs e) {
            // Get error message text
            string subject = string.Format(FatalErrorEmailSubject, DateTime.Now);
            string from = TxtFrom.Text;
            string body = TxtBody.Text;
            string errTxt = TxtError.Text;
            string msg = string.Format(FatalErrorEmailBody, from, body, errTxt);

            publishToSns(subject, msg);
        }
        private void ChkSendReport_CheckedChanged(object sender, EventArgs e) {
            bool sendingErr = ChkSendReport.Checked;

            SplitMain.Panel2.Enabled = sendingErr;
            this.AcceptButton = (sendingErr ? BtnSendReport : BtnClose);
        }
        private void publishToSns(string subject, string message) {
            try {
                // Get the error SNS Topic
                var sns = new AmazonSimpleNotificationServiceClient(FatalErrorUserAccessKeyId, FatalErrorUserSecretAccessKey, RegionEndpoint.USEast2);
                Topic topic = sns.FindTopic(FatalErrorSnsTopic);

                // Publish to that Topic
                var request = new PublishRequest(topic.TopicArn, message, subject);
                PublishResponse response = sns.Publish(request);
            }

            // At this point, we just gotta squash any Exceptions...
            catch (Exception) { }
        }
    }
}
