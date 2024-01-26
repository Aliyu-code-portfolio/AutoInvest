using AutoInvest.Application.Abstraction;
using AutoInvest.Application.Implementation;
using AutoInvest.Infrastructure.Persistent;
using AutoInvest.Infrastructure.Repository.Abstraction;
using AutoInvest.Infrastructure.Repository.Implementation;
using AutoInvest.Shared.SettingModel;
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
        public static void ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IShopService, ShopService>();
        }
        public static void ConfigureCloudinary(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CloudinarySetting>(configuration.GetSection("Cloudinary"));
            services.AddScoped<IMediaUpload, MediaUpload>();
        }
    }
}
