using AutoInvest.Domain.Models;

namespace AutoInvest.Application.Abstraction
{
    public interface ITokenService
    {
        Task<string> CreateToken(User user);
    }
}
