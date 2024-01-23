using AutoInvest.Infrastructure.Persistent;
using AutoInvest.Infrastructure.Repository.Abstraction;
using AutoInvest.Infrastructure.Repository.Implementation;
using Microsoft.EntityFrameworkCore;

namespace AutoInvest.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(options => options
            .UseSqlServer(configuration.GetConnectionString("AliyuLocalDB")));
        }
        public static void ConfigureRepositoryBase(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
        }

    }
}
