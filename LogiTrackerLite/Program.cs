using LogiTrackLite.Shared;
using LogiTrackLite.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using Package.Api.Mappers;
using Package.Application.Interfaces;
using Package.Application.UseCase;
using Package.Domain.Interfaces;
using Package.Infrastructure.Context;
using Package.Infrastructure.Messaging.RabbitMQ;
using Package.Infrastructure.Repository;
using RabbitMQ.Client;
using Tracking.Api.EndPoints;
using Tracking.Application.Interfaces;
using Tracking.Application.UseCase;
using Tracking.Domain.Interfaces;
using Tracking.Infrastructure.Context;
using Tracking.Infrastructure.Messaging.RabbitMQ.Abstractions;
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

// 1. Cargar configuración
var rabbitSettings = builder.Configuration.GetSection("RabbitMQ");


// Registrar la Factory de RabbitMQ
builder.Services.AddSingleton<IConnectionFactory>(sp => new ConnectionFactory()
{
    HostName = rabbitSettings["HostName"],
    Port = int.Parse(rabbitSettings["Port"] ?? "5672"),
    UserName = rabbitSettings["UserName"],
    Password = rabbitSettings["Password"],
    VirtualHost = rabbitSettings["VirtualHost"] ?? "/",
});

// Registrar nuestra clase persistente como Singleton
builder.Services.AddSingleton<IRabbitMqConnection, RabbitMqPersistentConnection>();
builder.Services.AddScoped<IPackageUseCase, PackageUseCase>();
builder.Services.AddScoped<IPackageRepository, PackageRepository>();
builder.Services.AddScoped<ITrackingUseCase, TrackingUseCase>();
builder.Services.AddScoped<ITrackingRepository, TrackingRepository>();
builder.Services.AddScoped<IPackageEventPublisher, RabbitMqPackageEventPublisher>();
builder.Services.AddScoped<ITrackingConsumer, PackageCreatedConsumer>();
builder.Services.AddHostedService<MessagingHostedService>();

var app = builder.Build();
app.MapPackageEndPoint();
app.MapTrackingEndPoint();



app.Run();
