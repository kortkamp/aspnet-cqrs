using System.Reflection;

using Microsoft.EntityFrameworkCore;

using Syslog.Api.Providers.CodeGenerator;
using Syslog.Data.Context;

namespace Syslog.Api.IoC
{
    public static class NativeInjectorConfig
    {
        public static void RegisterService(
          this IServiceCollection services,
          IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(
              options => options.UseSqlServer(configuration.GetConnectionString("DatabaseConnection")));

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddScoped<ICodeGenerator, CodeGeneratorRandom>();
        }
    }
}