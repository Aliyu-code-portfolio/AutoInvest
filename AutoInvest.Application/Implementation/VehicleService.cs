using AutoInvest.Application.Abstraction;
using AutoInvest.Shared.DTO.Request;
using AutoInvest.Shared.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoInvest.Application.Implementation
{
    public class VehicleService : IVehicleService
    {
        public Task<VehicleResponseDto> CreateVehicleAsync(string creatorId, VehicleRequestDto vehicleRequestDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteVehicle(string vehicleId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VehicleResponseDto>> GetAllVehicle()
        {
            throw new NotImplementedException();
        }

        public Task<VehicleResponseDto> GetVehicleById(string vehicleId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateVehicle(VehicleRequestDto vehicleRequestDto)
        {
            throw new NotImplementedException();
        }
    }
}
