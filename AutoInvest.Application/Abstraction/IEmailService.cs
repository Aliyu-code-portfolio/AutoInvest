namespace AutoInvest.Application.Abstraction
{
    public interface IEmailService
    {
        void SendEmail(string receiverEmail, string subject, string body);
    }
}
