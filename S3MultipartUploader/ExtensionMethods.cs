using System.Linq;
using System.Collections.Generic;

using Amazon.S3.Model;

namespace S3MultipartUploader {

    public static class ExtensionMethods {
        public static bool EqualsRequest(this InitiateMultipartUploadRequest request, InitiateMultipartUploadRequest other) {
            bool propsEq =
                other.BucketName == request.BucketName &&
                other.Key == request.Key &&

                other.StorageClass == request.StorageClass &&
                other.WebsiteRedirectLocation == request.WebsiteRedirectLocation &&
                other.RequestPayer?.Value == request.RequestPayer?.Value &&

                other.CannedACL == request.CannedACL &&

                other.ServerSideEncryptionMethod.Value == request.ServerSideEncryptionMethod.Value &&
                other.ServerSideEncryptionCustomerProvidedKey == request.ServerSideEncryptionCustomerProvidedKey &&
                other.ServerSideEncryptionCustomerMethod == request.ServerSideEncryptionCustomerMethod &&
                other.ServerSideEncryptionCustomerProvidedKeyMD5 == request.ServerSideEncryptionCustomerProvidedKeyMD5 &&
                other.ServerSideEncryptionKeyManagementServiceKeyId == request.ServerSideEncryptionKeyManagementServiceKeyId;
            if (!propsEq)
                return false;

            // Check if metadata include the same keys with the same values
            MetadataCollection otherMeta = other.Metadata;
            MetadataCollection thisMeta = request.Metadata;
            bool metadataCountEq = (otherMeta.Count == thisMeta.Count);
            if (!metadataCountEq)
                return false;
            string[] commonKeys = otherMeta.Keys.Intersect(thisMeta.Keys).ToArray();
            if (commonKeys.Length != otherMeta.Count)
                return false;
            bool metadataEq = commonKeys.All(k => otherMeta[k] == thisMeta[k]);
            if (!metadataEq)
                return false;

            // Check if content headers include the same headers with the same values
            HeadersCollection otherHeaders = other.Headers;
            HeadersCollection thisHeaders = request.Headers;
            bool headerCountEq = (otherHeaders.Count == thisHeaders.Count);
            if (!headerCountEq)
                return false;
            string[] commonHeaders = otherHeaders.Keys.Intersect(thisHeaders.Keys).ToArray();
            if (commonHeaders.Length != otherHeaders.Count)
                return false;
            bool headersEq = commonHeaders.All(k => otherHeaders[k] == thisHeaders[k]);
            if (!headersEq)
                return false;

            // Check if grants include the same grantees with the same permissions
            List<S3Grant> otherGrants = other.Grants;
            List<S3Grant> thisGrants = request.Grants;
            bool grantCountEq = (otherGrants.Count == thisGrants.Count);
            if (!grantCountEq)
                return false;
            S3Grant[] commonGrants = otherGrants.Intersect(thisGrants).ToArray();
            if (commonGrants.Length != otherGrants.Count)
                return false;

            return true;
        }
    }

}
