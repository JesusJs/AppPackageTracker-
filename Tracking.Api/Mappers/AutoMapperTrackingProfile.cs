using AutoMapper;
using Tracking.Api.Dtos;
using Tracking.Domain.Entity;
using Tracking.Domain.Models;

namespace Package.Api.Mappers
{
    public class AutoMapperTrackingProfile: Profile
    {
        public AutoMapperTrackingProfile()
        {
            // 1. Mapeo de Entrada
            CreateMap<TrackingDto, TrackingModels>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.Ignore()
                );
            CreateMap<TrackingModels, TrackingDto>();
            CreateMap<TrackingEntity, TrackingModels>();
            CreateMap<TrackingModels, TrackingEntity>();

        }

    }
}
