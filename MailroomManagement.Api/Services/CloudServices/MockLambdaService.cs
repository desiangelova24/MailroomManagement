namespace MailroomManagement.Api.Services.CloudServices
{
    public class MockLambdaService : ILambdaService
    {
        public Task<string> InvokeFunctionAsync(string functionName, string payload)
        {
            // Simulate Lambda function processing
            return Task.FromResult($"Processed by {functionName}: {payload}");
        }
    }
}
