using AutoMapper;
using Tracking.Application.Interfaces;
using Tracking.Domain.Entity;
using Tracking.Domain.Interfaces;
using Tracking.Domain.Models;

namespace Tracking.Application.UseCase
{
    public class TrackingUseCase : ITrackingUseCase
    {
        private readonly IMapper? _mapper;
        private readonly ITrackingRepository _repo;

        public TrackingUseCase(IMapper mapper, ITrackingRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public async Task<string> Create(TrackingModels datos)
        {
            var response = await _repo.CreatePackage(_mapper.Map<TrackingEntity>(datos));

            return response;
        }

        public Task Execute(TrackingModels data)
        {
            throw new NotImplementedException();
        }
    }
}