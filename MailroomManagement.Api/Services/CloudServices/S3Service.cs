using Amazon.S3;
using Amazon.S3.Model;

namespace MailroomManagement.Api.Services.CloudServices
{
    public class S3Service : IS3Service
    {
        private readonly IAmazonS3 _s3Client;
        private readonly string _bucketName;

        public S3Service(IAmazonS3 s3Client, IConfiguration configuration)
        {
            _s3Client = s3Client;
            _bucketName = configuration["AWS:S3BucketName"];
        }

        public async Task<string> UploadFileAsync(Stream fileStream, string fileName, string contentType)
        {
            var request = new PutObjectRequest
            {
                BucketName = _bucketName,
                Key = fileName,
                InputStream = fileStream,
                ContentType = contentType
            };

            var response = await _s3Client.PutObjectAsync(request);
            return response.ETag;
        }

        public async Task<Stream> DownloadFileAsync(string fileName)
        {
            var request = new GetObjectRequest
            {
                BucketName = _bucketName,
                Key = fileName
            };

            var response = await _s3Client.GetObjectAsync(request);
            return response.ResponseStream;
        }

        public async Task<bool> DeleteFileAsync(string fileName)
        {
            var request = new DeleteObjectRequest
            {
                BucketName = _bucketName,
                Key = fileName
            };

            await _s3Client.DeleteObjectAsync(request);
            return true;
        }
    }
}
