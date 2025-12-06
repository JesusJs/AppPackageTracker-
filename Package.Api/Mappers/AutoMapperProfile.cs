using AutoMapper;
using Package.Api.Dtos;
using Package.Domain.Entity;
using Package.Domain.Models;

namespace Package.Api.Mappers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            // 1. Mapeo de Entrada
            CreateMap<PackageDto, PackageModels>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.Ignore()
                );
            CreateMap<PackageModels, PackageDto>();
            CreateMap<PackageEntity, PackageModels>();
            CreateMap<PackageModels, PackageEntity>();

        }

    }
}
