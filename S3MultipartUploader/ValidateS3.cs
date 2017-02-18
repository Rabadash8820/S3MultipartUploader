using System;
using System.Text.RegularExpressions;

using static S3MultipartUploader.Properties.Resources;

namespace S3MultipartUploader {

    internal static class ValidateS3 {

        public static bool Key(string name, out string error) {
            bool valid = true;
            error = "";

            if (name == "") {
                error = MissingS3Key;
                valid = false;
            }
            else if (!Regex.IsMatch(name, S3KeyRegex)) {
                error = InvalidS3Key;
                valid = false;
            }

            return valid;
        }

    }

}
