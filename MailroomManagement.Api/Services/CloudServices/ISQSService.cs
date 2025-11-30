namespace MailroomManagement.Api.Services.CloudServices
{
    public interface ISQSService
    {
        Task SendMessageAsync(string queueUrl, string message);
        Task<string> ReceiveMessageAsync(string queueUrl);
        Task DeleteMessageAsync(string queueUrl, string receiptHandle);
    }
}
