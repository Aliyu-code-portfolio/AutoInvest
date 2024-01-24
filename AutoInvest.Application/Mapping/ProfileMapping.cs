using AutoInvest.Domain.Models;
using AutoInvest.Shared.DTO.Request;
using AutoInvest.Shared.DTO.Response;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoInvest.Application.Mapping
{
    public class ProfileMapping:Profile
    {
        public ProfileMapping()
        {
            CreateMap<ShopRequestDto, Shop>();
            CreateMap<Shop, ShopResponseDto>(); 
        }
    }
}
