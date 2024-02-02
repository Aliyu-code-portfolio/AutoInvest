using AutoInvest.API.Extensions;
using AutoInvest.API.Middleware;
using AutoInvest.Application.Mapping;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((context, loggerConfig)=>loggerConfig.ReadFrom.Configuration(context.Configuration));
// Add services to the container.
builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureRepositoryBase();
builder.Services.ConfigureApplicationServices();
builder.Services.AddAutoMapper(typeof(ProfileMapping));
builder.Services.ConfigureCloudinary(builder.Configuration);
builder.Services.ConfigurePaystackHelper(builder.Configuration);
builder.Services.ConfigureIdentity();
builder.Services.ConfigureEmailService(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.ConfigureExceptionHandler();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
Log.Logger.Information("Application is running");
app.Run();

