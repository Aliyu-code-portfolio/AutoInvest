using AutoInvest.Shared.DTO.Request;
using AutoInvest.Shared.DTO.StandardResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace AutoInvest.Application.Abstraction
{
    public interface IAuthService
    {
        Task<StandardResponse<IdentityResult>> RegisterUser(RegisterUserDto registerUserDto, HttpRequest httpRequest);
        Task<StandardResponse<IdentityResult>> ConfirmEmail(string email, string tokenIn64String);
        Task<StandardResponse<string>> LoginUser(LoginRequestDto loginRequestDto);
    }
}
