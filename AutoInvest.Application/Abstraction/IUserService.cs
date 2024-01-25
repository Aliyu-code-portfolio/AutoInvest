using AutoInvest.Shared.DTO.Request;
using AutoInvest.Shared.DTO.Response;
using AutoInvest.Shared.DTO.StandardResponse;

namespace AutoInvest.Application.Abstraction
{
    public interface IUserService
    {
        Task<StandardResponse<IEnumerable<UserResponseDto>>> GetAllRegisterUser();
        Task<StandardResponse<UserResponseDto>> GetRegisterUserById(string userId);
        Task<StandardResponse<string>> DeleteRegister(string userId);
    }
}
