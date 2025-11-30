namespace MailroomManagement.Api.Services.CloudServices
{
    public class MockS3Service : IS3Service
    {
        private readonly Dictionary<string, byte[]> _storage = new Dictionary<string, byte[]>();

        public Task<string> UploadFileAsync(Stream fileStream, string fileName, string contentType)
        {
            using var memoryStream = new MemoryStream();
            fileStream.CopyTo(memoryStream);
            _storage[fileName] = memoryStream.ToArray();
            return Task.FromResult(fileName);
        }

        public Task<Stream> DownloadFileAsync(string fileName)
        {
            if (!_storage.ContainsKey(fileName))
                throw new FileNotFoundException("File not found", fileName);

            var fileData = _storage[fileName];
            return Task.FromResult<Stream>(new MemoryStream(fileData));
        }

        public Task<bool> DeleteFileAsync(string fileName)
        {
            return Task.FromResult(_storage.Remove(fileName));
        }
    }
}
