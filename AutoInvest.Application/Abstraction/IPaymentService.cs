using AutoInvest.Shared.DTO.Request;
using AutoInvest.Shared.DTO.Response;
using AutoInvest.Shared.DTO.StandardResponse;

namespace AutoInvest.Application.Abstraction
{
    public interface IPaymentService
    {
        Task<StandardResponse<IEnumerable<PaymentResponseDto>>> GetAllPayment();
        Task<StandardResponse<PaymentResponseDto>> GetPaymentById(string paymentId);
        Task<StandardResponse<string>> ConfirmPayment(string paymentId);
        Task<StandardResponse<InitializePaymentResponseDto>> InitializePayment(InitializePaymentRequestDto initializePaymentRequestDto);
        Task<StandardResponse<string>> DeletePayment(string paymentId);
    }
}
