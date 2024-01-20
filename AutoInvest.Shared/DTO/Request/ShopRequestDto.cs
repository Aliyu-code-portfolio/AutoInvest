using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoInvest.Shared.DTO.Request
{
    public record ShopRequestDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string CompanyName { get; set; }
        public string RCNumber { get; set; }
    }
}
