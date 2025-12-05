using Tracking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracking.Application.Interfaces
{
    public interface ITrackingUseCase
    {
        Task<string> Create(TrackingModels datos);
    }
}
