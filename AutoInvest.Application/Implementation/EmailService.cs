using AutoInvest.Application.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoInvest.Application.Implementation
{
    public class EmailService : IEmailService
    {
        public void SendEmail(string receiverEmail, string subject, string body)
        {
            throw new NotImplementedException();
        }
    }
}
