using Amazon.SQS;
using Amazon.SQS.Model;

namespace MailroomManagement.Api.Services.CloudServices
{
    public class SQSService : ISQSService
    {
        private readonly IAmazonSQS _sqsClient;

        public SQSService(IAmazonSQS sqsClient)
        {
            _sqsClient = sqsClient;
        }

        public async Task SendMessageAsync(string queueUrl, string message)
        {
            var request = new SendMessageRequest
            {
                QueueUrl = queueUrl,
                MessageBody = message
            };

            await _sqsClient.SendMessageAsync(request);
        }

        public async Task<string> ReceiveMessageAsync(string queueUrl)
        {
            var request = new ReceiveMessageRequest
            {
                QueueUrl = queueUrl,
                MaxNumberOfMessages = 1
            };

            var response = await _sqsClient.ReceiveMessageAsync(request);
            return response.Messages.FirstOrDefault()?.Body;
        }

        public async Task DeleteMessageAsync(string queueUrl, string receiptHandle)
        {
            var request = new DeleteMessageRequest
            {
                QueueUrl = queueUrl,
                ReceiptHandle = receiptHandle
            };

            await _sqsClient.DeleteMessageAsync(request);
        }
    }

}
