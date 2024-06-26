﻿using AutoInvest.Application.Abstraction;
using AutoInvest.Domain.Models;
using AutoInvest.Infrastructure.Repository.Abstraction;
using AutoInvest.Shared.DTO.Request;
using AutoInvest.Shared.DTO.Response;
using AutoInvest.Shared.DTO.StandardResponse;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AutoInvest.Application.Implementation
{
    public class SaleService : ISaleService
    {
        private readonly IRepositoryBase<Sale> _repositoryBase;
        private readonly IVehicleService _vehicleService;
        private readonly IMapper _mapper;

        public SaleService(IRepositoryBase<Sale> repositoryBase,IVehicleService vehicleService, IMapper mapper)
        {
            _repositoryBase = repositoryBase;
            _vehicleService = vehicleService;
            _mapper = mapper;
        }

        public async Task<StandardResponse<SalesResponseDto>> CreateSaleAsync(string creatorId, SaleRequestDto saleRequestDto)
        {
            var vehicle = await _vehicleService.GetVehicleById(saleRequestDto.VehicleId);
            if(!vehicle.Success)
            {
                return StandardResponse<SalesResponseDto>.Failed("Request failed, vehicle does not exists", 400);
            }
            var sales = _mapper.Map<Sale>(saleRequestDto);
            sales.Amount = vehicle.Data.Price;
            sales.ShopId = vehicle.Data.ShopId;
            sales.CreatorId = creatorId;
            await _repositoryBase.CreateAsync(sales);
            await _repositoryBase.SaveChangesAsync();
            var salesresponse = _mapper.Map<SalesResponseDto>(sales);
            return StandardResponse<SalesResponseDto>.Succeeded("Sales successfully updated", salesresponse, 200);
        }

        public async Task<StandardResponse<IEnumerable<SalesResponseDto>>> GetAllSales()
        {
            var sales = await _repositoryBase.FindAll(trackChanges: false).ToListAsync();
            var salesDto = _mapper.Map<IEnumerable<SalesResponseDto>>(sales);
            return StandardResponse<IEnumerable<SalesResponseDto>>.Succeeded("Sales successfuly retrieved", salesDto, 200);
        }

        public async Task<StandardResponse<SalesResponseDto>> GetSalesById(string saleId)
        {
            var sales = await _repositoryBase.FindByCondition(trackChanges: false, expression: x => x.Id == saleId).SingleOrDefaultAsync();

            if (sales == null)
            {
                return StandardResponse<SalesResponseDto>.Failed("Sale was not retrieved successfully", 404);
            }
            var salesResponse = _mapper.Map<SalesResponseDto>(sales);
            return StandardResponse<SalesResponseDto>.Succeeded("Sales was retrieved successfully", salesResponse, 200);


        }

        public async Task<StandardResponse<string>> UpdateSale(string salesId, SaleRequestDto saleRequestDto)
        {
            var sales = await _repositoryBase.FindByCondition(trackChanges: true, expression: x => x.Id == salesId).SingleOrDefaultAsync();
            if (sales == null)
            {
                return StandardResponse<string>.Failed("Sales not found", 404);
            }
            _mapper.Map<SaleRequestDto>(sales);
            await _repositoryBase.SaveChangesAsync();
            return StandardResponse<string>.Succeeded("Sales successfully updated", "Success", 200);

        }


    }
}
