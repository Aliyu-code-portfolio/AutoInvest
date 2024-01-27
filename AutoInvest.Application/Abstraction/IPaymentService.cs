using AutoInvest.Shared.DTO.Request;
using AutoInvest.Shared.DTO.Response;
using AutoInvest.Shared.DTO.StandardResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoInvest.Application.Abstraction
{
    public interface IPaymentService
    {
        Task<StandardResponse<InitializePaymentResponseDto>> InitializePayment(InitializePaymentRequestDto initializePaymentRequestDto);
    }
}
