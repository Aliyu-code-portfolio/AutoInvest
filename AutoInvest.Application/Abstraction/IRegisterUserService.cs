using AutoInvest.Shared.DTO.Request;
using AutoInvest.Shared.DTO.Response;

namespace AutoInvest.Application.Abstraction
{
    public class IRegisterUserService
    {
        Task<IEnumerable<RegisterUserDto>> GetAllRegisterUser();
        Task<RegisterUserDto> GetRegisterUserById(string creatorId);
        Task<RegisterUserDto> CreateRegisterUserAsync(string creatorId, RegisterUserDto registerUserRequestDto);
        Task DeleteRegister(string creatorId);
    }
}
