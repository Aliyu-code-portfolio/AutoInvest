using AutoInvest.Application.Abstraction;
using AutoInvest.Domain.Models;
using AutoInvest.Infrastructure.Repository.Abstraction;
using AutoInvest.Shared.DTO.Request;
using AutoInvest.Shared.DTO.Response;
using AutoInvest.Shared.DTO.StandardResponse;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public async Task<StandardResponse<ShopResponseDto>> CreateShopAsync(string creatorId, ShopRequestDto shopRequestDto)
        {
            var shop = _mapper.Map<Shop>(shopRequestDto);
            shop.CreatorId = creatorId;
            await _repositoryBase.CreateAsync(shop);
            await _repositoryBase.SaveChangesAsync();
            var shopResponse = _mapper.Map<ShopResponseDto>(shop);
            return StandardResponse<ShopResponseDto>.Succeeded("Shops retrieved successfully", shopResponse, 200);
        }

        public async Task<StandardResponse<string>> DeleteShop(string shopId)
        {
            var shop = await _repositoryBase.FindByCondition(trackChanges: false,expression: x => x.Id == shopId).SingleOrDefaultAsync();
            if (shop == null)
            {
                return StandardResponse<string>.Failed("Shop does not exist", 404);
            }
            _repositoryBase.Delete(shop);
            await _repositoryBase.SaveChangesAsync();
            return StandardResponse<string>.Succeeded("Delete Successful", "Deleted",200);
        }

        public async Task<StandardResponse<IEnumerable<ShopResponseDto>>> GetAllShop()
        {
            var shops = await _repositoryBase.FindAll(trackChanges: true).ToListAsync();
            var shopsDtos = _mapper.Map<IEnumerable<ShopResponseDto>>(shops);
            return StandardResponse<IEnumerable<ShopResponseDto>>.Succeeded("Shops retrieved successfully", shopsDtos, 200);

        }

        public async Task<StandardResponse<ShopResponseDto>> GetShopById(string shopId)
        {
            var shop = await _repositoryBase.FindByCondition(trackChanges: false, expression: x => x.Id == shopId).SingleOrDefaultAsync();
            if(shop == null)
            {
                return StandardResponse<ShopResponseDto>.Failed("Shop does not exist", 404);
            }
            var shopDto = _mapper.Map<ShopResponseDto>(shop);
            return StandardResponse<ShopResponseDto>.Succeeded("Shops retrieved successfully", shopDto, 200);
        }

        public async Task<StandardResponse<string>> UpdateShop( string shopId, ShopRequestDto shopRequestDto)
        {
            var shop = await _repositoryBase.FindByCondition(trackChanges: true, expression: x => x.Id == shopId).SingleOrDefaultAsync();
            if(shop == null) 
            { return StandardResponse<string>.Failed("Shop not found", 404); }
            _mapper.Map(shop, shopRequestDto);
            await _repositoryBase.SaveChangesAsync();
            return StandardResponse<string>.Succeeded("Shop successfully retrieved", "Success", 200);
        }
    }
}
