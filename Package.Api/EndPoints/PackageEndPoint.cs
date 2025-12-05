using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Package.Api.Dtos;
using Package.Application.Interfaces;

public static class PackageEndpoints
{
    public static void MapProductEndpoints(this WebApplication app)
    {
        app.MapGet("/package/create", async (IPackageUseCase Package, ILogger logger) =>
        {
            logger.LogInformation("Recibida solicitud GET en /PackageCreate");
            var pro = await Package.ObtenerProducto();
            return pro;
        }).WithName("GetProductPackage")
            .Produces<PackageResultDto>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status500InternalServerError);

    }
}
