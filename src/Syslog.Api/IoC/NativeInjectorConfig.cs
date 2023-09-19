using MediatR;
using Syslog.Api.Providers.CodeGenerator;

namespace Syslog.Api.IoC
{
    public static class NativeInjectorConfig
    {
        public static void RegisterService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(Program));

            services.AddScoped<ICodeGenerator, CodeGeneratorRandom>();
        }
    }
}