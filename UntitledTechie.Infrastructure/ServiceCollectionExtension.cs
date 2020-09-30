using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using UntitledTechie.Infrastructure.Data;
using UntitledTechie.Infrastructure.Entities;
using UntitledTechie.Infrastructure.Repositories;
using UntitledTechie.Infrastructure.UoW;

namespace UntitledTechie.Infrastructure
{
    public static class ServiceCollectionExtension
    {
        public static void ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TechieContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("TechieContextConnection")));

            services.AddScoped<IUnitOfWork,UnitOfWork>();

            services.AddScoped<IRepository<AccountEntity>, Repository<AccountEntity>>();
            services.AddScoped<IRepository<PostEntity>, Repository<PostEntity>>();
            services.AddScoped<IRepository<CommentEntity>, Repository<CommentEntity>>();
            services.AddScoped<IRepository<SubCommentEntity>, Repository<SubCommentEntity>>();
        }
    }
}