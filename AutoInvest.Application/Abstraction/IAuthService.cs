using AutoInvest.Shared.DTO.Request;
using AutoInvest.Shared.DTO.StandardResponse;
using Microsoft.AspNetCore.Identity;

namespace AutoInvest.Application.Abstraction
{
    public interface IAuthService
    {
        Task<StandardResponse<IdentityResult>> RegisterUser(RegisterUserDto registerUserDto);
        
    }
}
