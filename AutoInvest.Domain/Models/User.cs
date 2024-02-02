using AutoInvest.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace AutoInvest.Domain.Models
{
    public class User:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserType UserType { get; set; }
        public string NIN { get; set; }
        public bool IsVerified { get; set; }
        public string? AddressId { get; set; } 
        public virtual Address? Address { get; set; }
    }
}
