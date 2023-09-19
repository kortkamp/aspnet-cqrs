using System.Reflection;
using Syslog.Api.Providers.CodeGenerator;

namespace Syslog.Api.IoC
{
    public static class NativeInjectorConfig
    {
        public static void RegisterService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddScoped<ICodeGenerator, CodeGeneratorRandom>();
        }
    }
}