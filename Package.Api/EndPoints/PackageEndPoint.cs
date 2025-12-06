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

            var result = await packageUseCase.Create(datos);

            if (!result.Success)
                return Results.StatusCode(500);

            return Results.Created($"El paquete quedo", result);
        });


        app.MapGet("/package/{id:int}", async (
            int id,
            IPackageUseCase packageUseCase,
            IMapper mapper) =>
        {
            var data = await packageUseCase.GetById(id);

            if (data == null)
                return Results.NotFound($"Package con ID {id} no existe");

            var dto = mapper.Map<PackageDto>(data);

            return Results.Ok(dto);
        });


        app.MapPut("/package/update/{id:int}", async (
            int id,
            PackageDto dto,
            IPackageUseCase packageUseCase,
            IMapper mapper) =>
        {
            var datos = mapper.Map<PackageModels>(dto);

            var updated = await packageUseCase.Update(id, datos);

            if (!updated.Exists)
                return Results.NotFound($"Package con ID {id} no existe");

            if (!updated.Success)
                return Results.StatusCode(500);

            return Results.Ok(updated);
        });

        app.MapDelete("/package/delete/{id:int}", async (
            int id,
            IPackageUseCase packageUseCase) =>
        {
            var deleted = await packageUseCase.Delete(id);

            if (!deleted.Exists)
                return Results.NotFound($"Package con ID {id} no existe");

            if (!deleted.Success)
                return Results.StatusCode(500);

            return Results.NoContent(); // 204
        });
    }
}