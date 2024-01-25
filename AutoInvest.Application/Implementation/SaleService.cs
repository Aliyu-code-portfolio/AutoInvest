﻿using AutoInvest.Application.Abstraction;
using AutoInvest.Domain.Models;
using AutoInvest.Infrastructure.Repository.Abstraction;
using AutoInvest.Infrastructure.Repository.Implementation;
using AutoInvest.Shared.DTO.Request;
using AutoInvest.Shared.DTO.Response;
using AutoInvest.Shared.DTO.StandardResponse;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoInvest.Application.Implementation
{
    public class SaleService : ISaleService
    {
        private readonly IRepositoryBase<Sale> _repositoryBase;
        private readonly IMapper _mapper; 

        public async  Task<StandardResponse<SalesResponseDto>>CreateSaleAsync(string shopId, SaleRequestDto saleRequestDto)
        {
            var sales = _mapper.Map<Sale>(saleRequestDto);
            await _repositoryBase.CreateAsync(sales);
            await _repositoryBase.SaveChangesAsync();
            var salesresponse = _mapper.Map<SalesResponseDto>(sales);
            return StandardResponse<SalesResponseDto>.Succeeded("Sales successfully updated", salesresponse, 200);
        }

        public async Task<StandardResponse<IEnumerable<SalesResponseDto>>> GetAllSales()
        {
            var sales = await _repositoryBase.FindAll(trackChanges: true).ToListAsync();
            var salesDto = _mapper.Map<IEnumerable<SalesResponseDto>>(sales);
            return StandardResponse<IEnumerable<SalesResponseDto>>.Succeeded("Sales successfuly retrieved", salesDto, 200);
        }

        public async Task <StandardResponse<SalesResponseDto>>GetSalesById(string saleId)
        {
            var sales = await _repositoryBase.FindByCondition(trackChanges:false , expression: x => x.Id == saleId).SingleOrDefaultAsync();
            
            if(sales == null)
            {
                return StandardResponse<SalesResponseDto>.Failed("Sale was not retrieved successfully", 404);
            }
            var salesResponse = _mapper.Map<SalesResponseDto>(sales);
            return StandardResponse<SalesResponseDto>.Succeeded("Sales was retrieved successfully", salesResponse, 200);


        }

        public async Task UpdateSale(string salesId, SalesResponseDto saleResponseDto)
        {
            var sales = await _repositoryBase.FindByCondition(trackChanges:false, expression: x => x.Id == salesId).SingleOrDefaultAsync();
            if (sales == null)
            {
                return /*StandardResponse<SalesResponseDto>.Failed("Sales not found", 404)*/;
            }
            _mapper.Map<SalesResponseDto>(sales);
            await _repositoryBase.SaveChangesAsync();

        }
    }
}
