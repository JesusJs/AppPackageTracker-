using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracking.Domain.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tracking.Application.Interfaces
{
    public interface ITrackingUseCase
    {
        Task<string> Create(TrackingModels datos);
        Task Execute(TrackingModels data);
    }
}
