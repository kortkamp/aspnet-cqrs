using System.Reflection;

using Microsoft.EntityFrameworkCore;

using Syslog.Application.Providers.CodeGenerator;
using Syslog.Data.Context;
using Syslog.Data.Repositories;
using Syslog.Domain.Interfaces.Repositories;

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
            services.AddScoped<IDeliveryRepository, DeliveryRepository>();
        }
    }
}