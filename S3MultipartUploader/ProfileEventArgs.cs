using System;

namespace S3MultipartUploader {

    public class ProfileEventArgs : EventArgs {
        public ProfileEventArgs(string name, string accessKeyId, string secretKey) {
            ProfileName = name;
            AccessKeyId = accessKeyId;
            SecretAccessKey = secretKey;
        }
        public string ProfileName { get; }
        public string AccessKeyId { get; }
        public string SecretAccessKey { get; }
    }

}
