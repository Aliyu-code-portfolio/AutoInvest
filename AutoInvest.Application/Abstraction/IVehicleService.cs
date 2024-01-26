using AutoInvest.Shared.DTO.Request;
using AutoInvest.Shared.DTO.Response;
using AutoInvest.Shared.DTO.StandardResponse;

namespace AutoInvest.Application.Abstraction
{
    public interface IVehicleService
    {
        Task <StandardResponse<IEnumerable<VehicleResponseDto>>> GetAllVehicle();
        Task<StandardResponse<VehicleResponseDto>> GetVehicleById(string vehicleId);
        Task<StandardResponse<VehicleResponseDto>> CreateVehicleAsync(string creatorId, VehicleRequestDto vehicleRequestDto);
        Task <StandardResponse<string>>UpdateVehicle( string vehicleId, VehicleRequestDto vehicleRequestDto);
        Task <StandardResponse<string>>DeleteVehicle(string vehicleId);
    }
}
