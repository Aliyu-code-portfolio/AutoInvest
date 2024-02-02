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
            CreateMap<RegisterUserDto, User>();
            CreateMap<ShopRequestDto, Shop>();
            CreateMap<Shop, ShopResponseDto>(); 
            CreateMap<MediaRequestDto, Media>();
            CreateMap<Media, MediaResponseDto>(); 
            CreateMap<VehicleRequestDto, Vehicle>();
            CreateMap<Vehicle, VehicleResponseDto>(); 
            CreateMap<Review,ReviewRequestDto>();
            CreateMap<Review,ReviewResponseDto>();
            CreateMap<SaleRequestDto,Sale>();
            CreateMap<Sale,SalesResponseDto>();
            CreateMap<Address,AddressResponseDto>();
            CreateMap<Address,AddressRequestDto>();
            CreateMap<User,UserResponseDto>();
            CreateMap<Payment,PaymentResponseDto>();
        }
    }
}
