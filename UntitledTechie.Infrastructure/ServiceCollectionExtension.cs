using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using UntitledTechie.Infrastructure.Data;

namespace UntitledTechie.Infrastructure
{
    public static class ServiceCollectionExtension
    {
        public static void ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration) {
            services.AddDbContext<TechieContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("TechieContextConnection")));
        }
    }
}