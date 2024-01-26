using AutoInvest.Domain.Models;
using AutoInvest.Shared.DTO.Request;
using AutoInvest.Shared.DTO.Response;
using AutoMapper;

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
