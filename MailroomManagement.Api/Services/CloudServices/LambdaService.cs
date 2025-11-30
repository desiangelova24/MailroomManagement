using Amazon.Lambda;
using Amazon.Lambda.Model;

namespace MailroomManagement.Api.Services.CloudServices
{
    public class LambdaService : ILambdaService
    {
        private readonly IAmazonLambda _lambdaClient;

        public LambdaService(IAmazonLambda lambdaClient)
        {
            _lambdaClient = lambdaClient;
        }

        public async Task<string> InvokeFunctionAsync(string functionName, string payload)
        {
            var request = new InvokeRequest
            {
                FunctionName = functionName,
                Payload = payload
            };

            var response = await _lambdaClient.InvokeAsync(request);
            using var reader = new StreamReader(response.Payload);
            return await reader.ReadToEndAsync();
        }
    }
}
