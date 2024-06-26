﻿using AutoInvest.Application.Abstraction;
using AutoInvest.Application.Implementation;
using AutoInvest.Domain.Models;
using AutoInvest.Infrastructure.ExternalAPI;
using AutoInvest.Infrastructure.Persistent;
using AutoInvest.Infrastructure.Repository.Abstraction;
using AutoInvest.Infrastructure.Repository.Implementation;
using AutoInvest.Shared.SettingModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IShopService, ShopService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<ISaleService, SaleService>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IMediaService, MediaService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPaymentService, PaymentService>();
           
        }
        
        public static void ConfigureCloudinary(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CloudinarySetting>(configuration.GetSection("Cloudinary"));
            services.AddScoped<IMediaUpload, MediaUpload>();
        }
        public static void ConfigurePaystackHelper(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<PaystackHelper>();
        }
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>(o =>
            {
                o.SignIn.RequireConfirmedEmail = true;
                o.User.RequireUniqueEmail = true;
                o.Password.RequireDigit = true;
                o.Password.RequireUppercase = true;
                o.Password.RequireNonAlphanumeric = true;
                o.Password.RequiredLength = 8;
            }).AddEntityFrameworkStores<RepositoryContext>()
            .AddDefaultTokenProviders();
        }
        public static void ConfigureEmailService(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSetting>(configuration.GetSection("SmtpSettings"));
            services.AddScoped<IEmailService, EmailService>();
        }
        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["validIssuer"],
                    ValidAudience = jwtSettings["validAudience"],
                    IssuerSigningKey = new
                    SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["TokenKey"]))
                };
            });
        }
        public static void ConfigureTokenService(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
        }
    }
}
