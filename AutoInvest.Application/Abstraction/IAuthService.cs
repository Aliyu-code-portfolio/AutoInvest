using AutoInvest.Shared.DTO.Request;
using Microsoft.AspNetCore.Identity;

namespace AutoInvest.Application.Abstraction
{
    public interface IAuthService
    {
        Task<IdentityResult> RegisterUser(RegisterUserDto registerUserDto);
        
    }
}
