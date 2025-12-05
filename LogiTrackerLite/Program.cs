using Microsoft.EntityFrameworkCore;
using Package.Api.Mappers;
using Package.Application.Interfaces;
using Package.Application.UseCase;
using Package.Domain.Interfaces;
using Package.Infrastructure.Context;
using Package.Infrastructure.Repository;
using RabbitMQ.Client;
using Tracking.Api.EndPoints;
using Tracking.Application.Interfaces;
using Tracking.Application.UseCase;
using Tracking.Domain.Interfaces;
using Tracking.Infrastructure.Context;
using Tracking.Infrastructure.Repository;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile(new AutoMapperProfile());
    cfg.AddProfile(new AutoMapperTrackingProfile());
});
builder.Services.AddDbContext<PackageDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<TrackingDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); 


var factory = new ConnectionFactory()
{
    // Usa el nombre del servicio de Docker si tu app también corre en Docker Compose
    HostName = "rabbitmq_local",
    Port = 5672, // 5672
    UserName = "guest",
    Password = "guest"
};
builder.Services.AddScoped<IPackageUseCase, PackageUseCase>();
builder.Services.AddScoped<IPackageRepository, PackageRepository>();
builder.Services.AddScoped<ITrackingUseCase, TrackingUseCase>();
builder.Services.AddScoped<ITrackingRepository, TrackingRepository>();
//builder.Services.AddSingleton<IConnectionFactory>(factory);

var app = builder.Build();
app.MapPackageEndPoint();
app.MapTrackingEndPoint();



app.Run();
