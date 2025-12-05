using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Package.Api.Dtos;
using Package.Application.Interfaces;
using Package.Domain.Models;

public static class PackageEndpoints
{
  
    public static void MapPackageEndPoint(this WebApplication app)
    {


        app.MapPost("/package/create", async (
        IPackageUseCase packageUseCase,  
        IMapper mapper,                
        PackageDto dto) =>
        {
            var datos = mapper.Map<PackageModels>(dto);
            var resultMessage = await packageUseCase.Create(datos);
            return resultMessage;
        });

    }
}
