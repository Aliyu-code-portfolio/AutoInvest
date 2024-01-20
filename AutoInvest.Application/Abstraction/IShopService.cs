using AutoInvest.Domain.Models;
using AutoInvest.Shared.DTO.Response;

namespace AutoInvest.Application.Abstraction
{
    public interface IShopService
    {
        Task<Shop> GetAllShop(ShopResponseDto shopResponseDto);
        Task<Shop> GetShopById(ShopResponseDto shopResponseDto);
        Task CreateShopAsync(ShopResponseDto shopResponseDto);
        void UpdateShop(ShopResponseDto shopResponseDto);
        void DeleteShop(ShopResponseDto shopResponseDto);
    }
}
