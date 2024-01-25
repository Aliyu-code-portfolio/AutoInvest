using AutoInvest.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoInvest.Shared.DTO.Response
{
    public class UserResponseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string EmailComfirmed { get; set; }
        public bool IsVerified { get; set; }
        public string AddressId { get; set; } 
    }
}
