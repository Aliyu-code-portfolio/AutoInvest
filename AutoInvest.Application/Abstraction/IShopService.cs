
using AutoInvest.Shared.DTO.Request;
using AutoInvest.Shared.DTO.Response;
using AutoInvest.Shared.DTO.StandardResponse;

namespace AutoInvest.Application.Abstraction
{
    public interface IShopService
    {
        Task<StandardResponse<IEnumerable<ShopResponseDto>>> GetAllShop();
        Task<StandardResponse<ShopResponseDto>> GetShopById(string shopId);
        Task<StandardResponse<ShopResponseDto>> CreateShopAsync(string creatorId, ShopRequestDto shopRequestDto);
        Task<StandardResponse<string>> UpdateShop(string shopId, ShopRequestDto shopRequestDto);
        Task<StandardResponse<string>> DeleteShop(string shopId);
    }
}
