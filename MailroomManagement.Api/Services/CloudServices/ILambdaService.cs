namespace MailroomManagement.Api.Services.CloudServices
{
    public interface ILambdaService
    {
        Task<string> InvokeFunctionAsync(string functionName, string payload);
    }
}
