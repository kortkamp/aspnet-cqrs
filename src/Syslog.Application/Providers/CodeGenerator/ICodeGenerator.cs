namespace Syslog.Application.Providers.CodeGenerator
{
    public interface ICodeGenerator
    {
        Task<string> Generate();
    }
}