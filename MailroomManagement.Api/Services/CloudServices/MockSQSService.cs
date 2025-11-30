namespace MailroomManagement.Api.Services.CloudServices
{
    public class MockSQSService : ISQSService
    {
        private readonly Dictionary<string, Queue<string>> _queues = new Dictionary<string, Queue<string>>();

        public Task SendMessageAsync(string queueUrl, string message)
        {
            if (!_queues.ContainsKey(queueUrl))
                _queues[queueUrl] = new Queue<string>();

            _queues[queueUrl].Enqueue(message);
            return Task.CompletedTask;
        }

        public Task<string> ReceiveMessageAsync(string queueUrl)
        {
            if (!_queues.ContainsKey(queueUrl) || _queues[queueUrl].Count == 0)
                return Task.FromResult<string>(null);

            return Task.FromResult(_queues[queueUrl].Dequeue());
        }

        public Task DeleteMessageAsync(string queueUrl, string receiptHandle)
        {
            // In a real scenario, receiptHandle would be used to identify the message to delete.
            return Task.CompletedTask;
        }
    }
}
