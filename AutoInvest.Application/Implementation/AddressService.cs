using AutoInvest.Application.Abstraction;
using AutoInvest.Domain.Models;
using AutoInvest.Infrastructure.Repository.Abstraction;
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
    public class AddressService : IAddressService
    {
        private readonly IRepositoryBase<Address> _repositoryBase;
        private readonly IMapper _mapper;
        public AddressService(IRepositoryBase<Address> repositoryBase, IMapper mapper)
        {
            _repositoryBase = repositoryBase;
            _mapper = mapper;
        }



        public async Task<StandardResponse<AddressResponseDto>> CreateAddressAsync(string creatorId, AddressRequestDto addressRequestDto)
        {
            var address = _mapper.Map<Address>(addressRequestDto);
            address.CreatorId = creatorId;
           await  _repositoryBase.CreateAsync(address);
            await _repositoryBase.SaveChangesAsync();
            var addressResponse = _mapper.Map<AddressResponseDto>(address);
            return StandardResponse<AddressResponseDto>.Succeeded("Address was created successfully", addressResponse, 200);

        }

        public async Task<StandardResponse<string>> DeleteAddress(string addressId)
        {
           var address = await _repositoryBase.FindByCondition(trackChanges:false,expression:x => x.Id == addressId).SingleOrDefaultAsync();
           if(address == null)
            {
                return StandardResponse<string>.Failed("Address not found", 404);
            }
           _repositoryBase.Delete(address);
           await _repositoryBase.SaveChangesAsync();
            return StandardResponse<string>.Succeeded("Address has been successfully deleted", "deleted", 200);
        }

        public async Task<StandardResponse<IEnumerable<AddressResponseDto>>> GetAllAddress()
        {
            var address = await _repositoryBase.FindAll(trackChanges:true).ToListAsync();
            var addressResponse = _mapper.Map<IEnumerable<AddressResponseDto>>(address);
            return StandardResponse<IEnumerable<AddressResponseDto>>.Succeeded("Address retrieved", addressResponse, 200);
        }

        public async Task<StandardResponse<AddressResponseDto>> GetAddressById(string addressId, AddressResponseDto addressResponseDto)
        {
            var address = await _repositoryBase.FindByCondition(trackChanges:false, expression: x => x.Id == addressId).SingleOrDefaultAsync();
            if(address == null)
            {
                return StandardResponse<AddressResponseDto>.Failed("Address not found", 404);
            }
            var addressResponse = _mapper.Map<AddressResponseDto>(address);
            return StandardResponse<AddressResponseDto>.Succeeded("Address found", addressResponse, 200);

        }

        public async Task<StandardResponse<string>> UpdateAddress(string addressId, AddressRequestDto addressRequestDto)
        {
            var address = await _repositoryBase.FindByCondition(trackChanges: false, expression: x => x.Id == addressId).SingleOrDefaultAsync();
           if(address == null)
            {
                return StandardResponse<string>.Failed("Address not found", 404);
            }
            _mapper.Map<AddressRequestDto>(address);
            await _repositoryBase.SaveChangesAsync();
            return StandardResponse<string>.Succeeded("Address Successfully updated", "Updated", 200);


        }
    }
}
