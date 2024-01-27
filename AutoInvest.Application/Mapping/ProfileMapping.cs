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
            CreateMap<MediaRequestDto, Media>();
            CreateMap<Media, MediaResponseDto>(); 
            CreateMap<VehicleRequestDto, Vehicle>();
            CreateMap<Vehicle, VehicleResponseDto>(); 
            CreateMap<Review,ReviewRequestDto>();
            CreateMap<Review,ReviewResponseDto>();
            CreateMap<Sale,SaleRequestDto>();
            CreateMap<Sale,SalesResponseDto>();
            CreateMap<Address,AddressResponseDto>();
            CreateMap<Address,AddressRequestDto>();
            CreateMap<User,UserResponseDto>();
        }
    }
}
