using AutoInvest.Shared.DTO.Request;
using AutoInvest.Shared.DTO.Response;

namespace AutoInvest.Application.Abstraction
{
    public interface IUserService
    {
        Task<IEnumerable<RegisterUserDto>> GetAllRegisterUser();
        Task<RegisterUserDto> GetRegisterUserById(string userId);
        Task DeleteRegister(string userId);
    }
}
