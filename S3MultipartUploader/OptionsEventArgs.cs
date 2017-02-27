using System;

using Amazon.S3.Model;

namespace S3MultipartUploader {

    public class OptionsEventArgs : EventArgs {
        public OptionsEventArgs(bool uploadAsync, InitiateMultipartUploadRequest request) {
            InitiateMultipartUploadRequest = request;
            UploadAsync = uploadAsync;
        }
        public InitiateMultipartUploadRequest InitiateMultipartUploadRequest { get; }
        public bool UploadAsync { get; }
    }

}
