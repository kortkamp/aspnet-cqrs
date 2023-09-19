namespace Syslog.Api.Providers.CodeGenerator
{
    public class CodeGeneratorRandom : ICodeGenerator
    {
        private readonly Random _random;
        public CodeGeneratorRandom()
        {
            _random = new Random();
        }
        public Task<string> Generate()
        {
            return Task.FromResult(_random.Next(1000000).ToString());
        }
    }
}