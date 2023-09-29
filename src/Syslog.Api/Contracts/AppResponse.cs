namespace Syslog.Api.Contracts
{
    public class AppResponse<T> : IContract
    {
        public AppResponse(T? result)
        {
            Result = result;
        }

        public bool Success { get; } = true;

        public T? Result { get; }
    }
}