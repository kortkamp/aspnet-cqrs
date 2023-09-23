namespace Syslog.Api.Providers.CodeGenerator
{
    public interface ICodeGenerator
    {
        Task<string> Generate();
    }
}