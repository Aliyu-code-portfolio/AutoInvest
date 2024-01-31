using AutoInvest.Shared.DTO.Request;
using AutoInvest.Shared.DTO.Response;
using AutoInvest.Shared.DTO.StandardResponse;

namespace AutoInvest.Application.Abstraction
{
    public interface IPaymentService
    {
        Task<StandardResponse<IEnumerable<PaymentResponseDto>>> GetAllPayment();
        Task<StandardResponse<string>> ConfirmPayment(string paymentId);
        Task<StandardResponse<InitializePaymentResponseDto>> InitializePayment(InitializePaymentRequestDto initializePaymentRequestDto);
    }
}
