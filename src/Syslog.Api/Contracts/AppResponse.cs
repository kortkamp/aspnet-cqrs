namespace Syslog.Api.Contracts
{
    public class AppResponse : IContract
    {
        public AppResponse(string result)
        {
            Result = result;
        }

        public bool Success { get; } = true;

        public string Result { get; }
    }
}