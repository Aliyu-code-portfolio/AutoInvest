
using AutoInvest.Shared.DTO.Request;
using AutoInvest.Shared.DTO.Response;

namespace AutoInvest.Application.Abstraction
{
    public interface IShopService
    {
        Task<IEnumerable<ShopResponseDto>> GetAllShop();
        Task<ShopResponseDto> GetShopById(string shopId);
        Task<ShopResponseDto> CreateShopAsync(string creatorId, ShopRequestDto shopRequestDto);
        Task UpdateShop(string shopId, ShopRequestDto shopRequestDto);
        Task DeleteShop(string shopId);
    }
}
