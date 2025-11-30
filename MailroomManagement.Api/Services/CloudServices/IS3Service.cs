namespace MailroomManagement.Api.Services.CloudServices
{
    public interface IS3Service
    {
        Task<string> UploadFileAsync(Stream fileStream, string fileName, string contentType);
        Task<Stream> DownloadFileAsync(string fileName);
        Task<bool> DeleteFileAsync(string fileName);
    }
}
