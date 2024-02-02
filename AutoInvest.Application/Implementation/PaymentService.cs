using AutoInvest.Application.Abstraction;
using AutoInvest.Domain.Models;
using AutoInvest.Infrastructure.ExternalAPI;
using AutoInvest.Infrastructure.Repository.Abstraction;
using AutoInvest.Shared.DTO.Request;
using AutoInvest.Shared.DTO.Response;
using AutoInvest.Shared.DTO.Response.PaystackResponses.ConfirmTransaction;
using AutoInvest.Shared.DTO.Response.PaystackResponses.InitializeTransaction;
using AutoInvest.Shared.DTO.StandardResponse;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace AutoInvest.Application.Implementation
{
    public class PaymentService : IPaymentService
    {
        private readonly IRepositoryBase<Payment> _paymentRepository;
        private readonly ISaleService _saleService;
        private readonly IMapper _mapper;
        private readonly PaystackHelper _paystackHelper;

        public PaymentService(IRepositoryBase<Payment> paymentRepository, PaystackHelper paystackHelper, ISaleService saleService, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _paystackHelper = paystackHelper;
            _saleService = saleService;
            _mapper = mapper;
        }

        public async Task<StandardResponse<string>> ConfirmPayment(string paymentId)
        {
            var payment = await _paymentRepository.FindByCondition(x => x.Id == paymentId, true).SingleOrDefaultAsync();
            if (payment == null)
            {
                return StandardResponse<string>.Failed("Request failed", 400);
            }
            ConfirmTransaction result;
            using (HttpResponseMessage responseMessage = await _paystackHelper.PaystackClient.GetAsync($"transaction/verify/{payment.Reference}"))
            {
                if (responseMessage.IsSuccessStatusCode)
                {
                    result = await responseMessage.Content.ReadFromJsonAsync<ConfirmTransaction>(); 
                }
                else
                {
                    return StandardResponse<string>.Failed("Request failed, Failed to confirm payment");
                }
            }
            if(result.Data.Status== "success")
            {
                payment.IsPaid = true;
                await _paymentRepository.SaveChangesAsync();
                return StandardResponse<string>.Succeeded("Request successful", string.Empty, 200);
            }
            return StandardResponse<string>.Failed($"Request failed, Payment not made yet. Reason: {result.Data.Status}");
        }

        public async Task<StandardResponse<string>> DeletePayment(string paymentId)
        {
            var payment = await _paymentRepository.FindByCondition(x=>x.Id == paymentId, true).SingleOrDefaultAsync();
            if (payment == null)
            {
                return StandardResponse<string>.Failed("Payment not found", 401);
            }
             _paymentRepository.Delete(payment);
            await _paymentRepository.SaveChangesAsync();
            return StandardResponse<string>.Succeeded("Payment Deleted", "Deleted", 200);
        }

        public async Task<StandardResponse<IEnumerable<PaymentResponseDto>>> GetAllPayment()
        {
            var payments = await _paymentRepository.FindAll(false).ToListAsync();
            var paymentsDtos = _mapper.Map<IEnumerable<PaymentResponseDto>>(payments);
            return StandardResponse<IEnumerable<PaymentResponseDto>>.Succeeded("Request successful", paymentsDtos, 200);
        }

        public async Task<StandardResponse<PaymentResponseDto>> GetPaymentById(string paymentId)
        {
            var payments = await _paymentRepository.FindByCondition(x=>x.Id==paymentId,false).SingleOrDefaultAsync();
            var paymentDtos = _mapper.Map<PaymentResponseDto>(payments);
            if (payments == null)
            {
                return StandardResponse<PaymentResponseDto>.Failed("Request failed", paymentDtos, 401);
            }
            return StandardResponse<PaymentResponseDto>.Succeeded("Request successful",paymentDtos, 200);
        }

        public async Task<StandardResponse<InitializePaymentResponseDto>> InitializePayment(InitializePaymentRequestDto initializePaymentRequestDto)
        {
            decimal totalPaymentAmount = 0;
            var salesIds = string.Empty;
            foreach(var saleId in initializePaymentRequestDto.SalesIds)
            {
                var saleResult = await _saleService.GetSalesById(saleId);
                var sale = saleResult.Data;
                if(!saleResult.Success)
                {
                    return StandardResponse<InitializePaymentResponseDto>.Failed("Request failed, The request contains invalid saleIds");
                }
                if(sale.IsSold)
                {
                    return StandardResponse<InitializePaymentResponseDto>.Failed("Request failed, Some sales has already been completed");
                }
                totalPaymentAmount += sale.Amount;
                salesIds += sale.Id+",";
            }
            string paymentId = Guid.NewGuid().ToString();
            var serializedDto = JsonSerializer.Serialize(new
            {
               email = initializePaymentRequestDto.CustomerEmail,
               amount = totalPaymentAmount.ToString()+"00",
               callback_url = $"https://localhost:7147/api/payment/confirm-payment/{paymentId}"
            });//addition of kobo not working
            //Implement webhook or callback_url
            InitializePayment paystackResponse;
            var httpContent = new StringContent(serializedDto, Encoding.UTF8, "application/json");
            using (HttpResponseMessage response =await _paystackHelper.PaystackClient.PostAsync("transaction/initialize",httpContent))
            {
                if (response.IsSuccessStatusCode)
                {
                    paystackResponse = await response.Content.ReadFromJsonAsync<InitializePayment>();
                }
                else
                {
                    return StandardResponse<InitializePaymentResponseDto>.Failed("Request failed, Failed to initialize payment");

                }
            }
            Payment payment = new Payment
            {
                Id = paymentId,
                Amount = totalPaymentAmount,
                SaleIds = salesIds,
                Access_code = paystackResponse.data.access_code,
                Reference = paystackResponse.data.reference,
                Authorization_url = paystackResponse.data.authorization_url
            };
            await _paymentRepository.CreateAsync(payment);
            await _paymentRepository.SaveChangesAsync();
            var initializeResponseDto = new InitializePaymentResponseDto
            {
                Id = payment.Id,
                Amount = totalPaymentAmount,
                PaymentUrl = payment.Authorization_url
            };
            return StandardResponse<InitializePaymentResponseDto>.Succeeded("Reqeust successful", initializeResponseDto, 200);
        }
    }
}
