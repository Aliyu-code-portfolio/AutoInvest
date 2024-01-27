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
    public class VehicleService : IVehicleService
    {

        private readonly IRepositoryBase<Vehicle> _repositoryBase;
        private readonly IMapper _mapper;
        public VehicleService(IRepositoryBase<Vehicle> repositoryBase, IMapper mapper)
        {
            _repositoryBase = repositoryBase;
            _mapper = mapper;
        }



        public async Task<StandardResponse<VehicleResponseDto>> CreateVehicleAsync(string creatorId, VehicleRequestDto vehicleRequestDto)
        {
            var vehicle = _mapper.Map<Vehicle>(vehicleRequestDto);
            vehicle.CreatorId = creatorId;
            await _repositoryBase.CreateAsync(vehicle);
            await _repositoryBase.SaveChangesAsync();
            var vehicleResponse = _mapper.Map<VehicleResponseDto>(vehicle);
            return StandardResponse<VehicleResponseDto>.Succeeded("Vehicle Successfully created", vehicleResponse, 200);
        }

        public async Task<StandardResponse<string>> DeleteVehicle(string vehicleId)
        {
           var vehicle = await _repositoryBase.FindByCondition(trackChanges:false , expression: x => x.Id == vehicleId).SingleOrDefaultAsync();
            if (vehicle == null)
            {
                return StandardResponse<string>.Failed("Vehicle does not exist", 404);
            }
            _repositoryBase.Delete(vehicle);
            await _repositoryBase.SaveChangesAsync();
            return StandardResponse<string>.Succeeded("Vehicle deleted successfully", "Success", 200);
        }

        public async Task<StandardResponse<IEnumerable<VehicleResponseDto>>> GetAllVehicle()
        {
           var vehicle = await _repositoryBase.FindAll(trackChanges:true).ToListAsync();
            var vehicleResponse = _mapper.Map<IEnumerable<VehicleResponseDto>>(vehicle);
            return StandardResponse<IEnumerable<VehicleResponseDto>>.Succeeded("Vehicle successfully retrieved", vehicleResponse, 200);
         }

        public async Task<StandardResponse<VehicleResponseDto>> GetVehicleById(string vehicleId)
        {
            var vehicle = await _repositoryBase.FindByCondition(trackChanges:false , expression: x => x.Id == vehicleId).SingleOrDefaultAsync();
            if (vehicle == null)
            {
                return StandardResponse<VehicleResponseDto>.Failed("Vehicle not found", 404);
            }
            var vehicleResponse = _mapper.Map<VehicleResponseDto>(vehicle);
            return StandardResponse<VehicleResponseDto>.Succeeded("Vehicle successfully retrieved", vehicleResponse, 200);
        }

        public async Task<StandardResponse<string>> UpdateVehicle( string vehicleId, VehicleRequestDto vehicleRequestDto)
        {
            var vehicle = await _repositoryBase.FindByCondition(trackChanges:false,expression:x => x.Id == vehicleId).SingleOrDefaultAsync();
            if(vehicle == null)
            {
                return StandardResponse<string>.Failed("Vehicle not found", 404);

            }
            _mapper.Map<VehicleRequestDto>(vehicle);
            await _repositoryBase.SaveChangesAsync();
            return StandardResponse<string>.Succeeded("Vehicle successfully updated", "success", 200);


        }
    }
}
