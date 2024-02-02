using AutoInvest.Application.Abstraction;
using AutoInvest.Shared.SettingModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace AutoInvest.Application.Implementation
{
    public class EmailService : IEmailService
    {
        private readonly EmailSetting _emailSetting;

        public EmailService(IOptions<EmailSetting> emailSetting)
        {
            _emailSetting = emailSetting.Value;
        }

        public Task<IdentityResult> SendEmail(string receiverEmail, string subject, string body)
        {
            try
            {
                string toEmail = receiverEmail;
                string smtpHost = _emailSetting.Host;
                int smtpPort = _emailSetting.Port;
                string userName = _emailSetting.Username;
                string smtpPassword = _emailSetting.Password;
                bool enableSsl = _emailSetting.EnableSsl;
                string senderName = "Auto Invest Inc";
                bool isHtml = false;
                using (var smtpClient = new SmtpClient(smtpHost, smtpPort))
                {
                    smtpClient.EnableSsl = enableSsl;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(userName, smtpPassword);
                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress(userName, senderName),
                        Subject = subject,
                        Body = body,
                        IsBodyHtml = isHtml,
                    };
                    mailMessage.To.Add(toEmail);
                    smtpClient.Send(mailMessage);
                    return Task.FromResult(IdentityResult.Success);
                }
            }
            catch (Exception ex)
            {
                var errorMsg = $"something happened trying to send email. Details: {ex.StackTrace}";
                var identityError = new IdentityError { Code = "500", Description = errorMsg };
                return Task.FromResult(IdentityResult.Failed(identityError));
            }
        }
    }
}
