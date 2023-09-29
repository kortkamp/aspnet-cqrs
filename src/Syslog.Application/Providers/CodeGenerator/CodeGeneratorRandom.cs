using System.Globalization;

namespace Syslog.Application.Providers.CodeGenerator
{
    public class CodeGeneratorRandom : ICodeGenerator
    {
        private readonly Random random;

        public CodeGeneratorRandom()
        {
            random = new Random();
        }

        public Task<string> Generate()
        {
            return Task.FromResult(random.Next(1000000).ToString(CultureInfo.InvariantCulture));
        }
    }
}