using System;
using System.Text.RegularExpressions;

using static S3MultipartUploader.Properties.Resources;

namespace S3MultipartUploader {

    internal static class ValidateProfile {
        public static bool Name(string name, out string error) {
            bool valid = true;
            error = "";

            if (name == "") {
                error = MissingProfileName;
                valid = false;
            }
            else if (!Regex.IsMatch(name, ProfileNameRegex)) {
                error = InvalidProfileName;
                valid = false;
            }

            return valid;
        }
        public static bool AccessKey(string accessKey, out string error) {
            bool valid = true;
            error = "";

            if (accessKey == "") {
                error = MissingAccessKeyID;
                valid = false;
            }
            else if (!Regex.IsMatch(accessKey, ProfileAccessKeyIDRegex)) {
                error = InvalidProfileAccessKeyID;
                valid = false;
            }

            return valid;
        }
        public static bool SecretKey(string secretKey, out string error) {
            bool valid = true;
            error = "";

            if (secretKey == "") {
                error = MissingSecretAccessKey;
                valid = false;
            }
            else if (!Regex.IsMatch(secretKey, ProfileSecretKeyRegex)) {
                error = InvalidProfileSecretKey;
                valid = false;
            }

            return valid;
        }
    }

}
