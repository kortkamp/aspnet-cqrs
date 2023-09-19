namespace Syslog.Api.Providers.CodeGenerator
{
    public class CodeGenerator : ICodeGenerator
    {
        public Task<string> Generate()
        {
            return Task.FromResult("123123");
        }
    }
}