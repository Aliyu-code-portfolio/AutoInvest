using AutoInvest.Shared.DTO.Request;
using AutoInvest.Shared.DTO.Response;

namespace AutoInvest.Application.Abstraction
{
    public interface IVehicleService
    {
        Task<IEnumerable<VehicleResponseDto>> GetAllVehicle();
        Task<VehicleResponseDto> GetVehicleById(string vehicleId);
        Task<VehicleResponseDto> CreateVehicleAsync(string creatorId, VehicleRequestDto vehicleRequestDto);
        Task UpdateVehicle(VehicleRequestDto vehicleRequestDto);
        Task DeleteVehicle(string vehicleId);
    }
}
