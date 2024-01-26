using AutoInvest.Shared.DTO.Request;
using AutoInvest.Shared.DTO.Response;
using AutoInvest.Shared.DTO.StandardResponse;

namespace AutoInvest.Application.Abstraction
{
    public interface IAddressService
    {
        Task <StandardResponse<AddressResponseDto>> CreateAddressAsync(string creatorId, AddressRequestDto addressRequestDto);
        Task<StandardResponse<IEnumerable<AddressResponseDto>>> GetAllAddress();
        Task<StandardResponse<AddressResponseDto>> GetAddressById(string vehicleId, AddressResponseDto addressResponseDto);
        Task<StandardResponse<string>> UpdateAddress (string  addressId, AddressRequestDto addressRequestDto);  
        Task<StandardResponse<string>> DeleteAddress (string addressId );
    }
}
