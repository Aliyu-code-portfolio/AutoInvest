using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoInvest.Shared.DTO.Response
{
    public record InitializePaymentResponseDto
    {
        public decimal Amount { get; set; }
        public string PaymentUrl { get; set; }
    }
}
