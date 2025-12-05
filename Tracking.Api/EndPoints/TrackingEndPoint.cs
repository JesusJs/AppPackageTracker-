using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Tracking.Api.Dtos;
using Tracking.Application.Interfaces;
using Tracking.Domain.Models;

namespace Tracking.Api.EndPoints
{
    public static class TrackingEndPoint
    {
        public static void MapTrackingEndPoint(this WebApplication app)
        {


            app.MapPost("/tracking/registerEvent", async (
            ITrackingUseCase trackingUseCase, 
            IMapper mapper,                
            TrackingDto dto) =>
            {
                var datos = mapper.Map<TrackingModels>(dto);
                var resultMessage = await trackingUseCase.Create(datos);
                return resultMessage;
            });

        }

    }
}
