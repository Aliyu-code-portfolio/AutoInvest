using AutoInvest.Application.Abstraction;
using AutoInvest.Domain.Models;
using AutoInvest.Infrastructure.Repository.Abstraction;
using AutoInvest.Shared.DTO.Request;
using AutoInvest.Shared.DTO.Response;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace AutoInvest.Application.Implementation
{
   
    public class ShopService : IShopService
    {
        private readonly IRepositoryBase<Shop> _repositoryBase;
        private readonly IMapper _mapper;


        public ShopService(IRepositoryBase<Shop> repositoryBase, IMapper mapper)
        {
            this._repositoryBase = repositoryBase;
            _mapper = mapper;
        }

        public async Task<ShopResponseDto> CreateShopAsync(string creatorId, ShopRequestDto shopRequestDto)
        {
            var shop = _mapper.Map<Shop>(shopRequestDto);
            await _repositoryBase.CreateAsync(shop);
            await _repositoryBase.SaveChangesAsync();
            var shopResponse = _mapper.Map<ShopResponseDto>(shop);  
            return shopResponse;
        }

        public async Task DeleteShop(string shopId)
        {
            var shop = await _repositoryBase.FindByCondition(trackChanges: false,expression: x => x.Id == shopId).SingleOrDefaultAsync();
            if (shop == null)
            {
                return;
            }
            _repositoryBase.Delete(shop);
            await _repositoryBase.SaveChangesAsync();
        }

        public async Task<IEnumerable<ShopResponseDto>> GetAllShop()
        {
            var shops = await _repositoryBase.FindAll(trackChanges: true).ToListAsync();
            var shopsDtos = _mapper.Map<IEnumerable<ShopResponseDto>>(shops);
            return shopsDtos;

        }

        public async Task<ShopResponseDto> GetShopById(string shopId)
        {
            var shop = await _repositoryBase.FindByCondition(trackChanges: false, expression: x => x.Id == shopId).SingleOrDefaultAsync();
            var shopDto = _mapper.Map<ShopResponseDto>(shop);
            return shopDto;
        }

        public async Task UpdateShop( string shopId, ShopRequestDto shopRequestDto)
        {
            var shop = await _repositoryBase.FindByCondition(trackChanges: true, expression: x => x.Id == shopId).SingleOrDefaultAsync();
            if(shop == null) 
            { return; }
            _mapper.Map(shop, shopRequestDto);
            await _repositoryBase.SaveChangesAsync();
        }
    }
}
