using System;
using System.Windows.Forms;

using static S3MultipartUploader.Properties.Resources;

namespace S3MultipartUploader {

    static class Program {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {

            // Load the MainForm
            try {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }

            // Exit (somewhat) gracefully from any uncaught exceptions
            catch (Exception e) {
                string text = string.Format(UnexpectedErrorText, SupportContact, e.ToString());
                new ErrorForm().ShowDialog();
            }
        }

    }

}
