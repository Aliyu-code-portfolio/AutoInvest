using Microsoft.AspNetCore.Identity;

namespace AutoInvest.Application.Abstraction
{
    public interface IEmailService
    {
        Task<IdentityResult> SendEmail(string receiverEmail, string subject, string body);
    }
}
