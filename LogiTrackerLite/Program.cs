using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Package.Application.Interfaces;
using Package.Application.UseCase;
using Package.Infrastructure.Context;
using RabbitMQ.Client;
using System;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PackageDbContext>(options =>
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
builder.Services.AddSingleton<IConnectionFactory>(factory);

var app = builder.Build();
app.MapProductEndpoints();

app.Run();
