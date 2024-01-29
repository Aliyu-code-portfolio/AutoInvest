using AutoInvest.Application.Abstraction;
using AutoInvest.Domain.Models;
using AutoInvest.Infrastructure.ExternalAPI;
using AutoInvest.Infrastructure.Repository.Abstraction;
using AutoInvest.Shared.DTO.Request;
using AutoInvest.Shared.DTO.Response;
using AutoInvest.Shared.DTO.Response.PaystackResponses;
using AutoInvest.Shared.DTO.StandardResponse;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Json;

namespace AutoInvest.Application.Implementation
{
    public class PaymentService : IPaymentService
    {
        private readonly IRepositoryBase<Payment> _paymentRepository;
        private readonly IRepositoryBase<Sale> _saleRepository;
        private readonly PaystackHelper _paystackHelper;

        public PaymentService(IRepositoryBase<Payment> paymentRepository, IRepositoryBase<Sale> saleRepository, PaystackHelper paystackHelper)
        {
            _paymentRepository = paymentRepository;
            _saleRepository = saleRepository;
            _paystackHelper = paystackHelper;
        }

        public async Task<StandardResponse<InitializePaymentResponseDto>> InitializePayment(InitializePaymentRequestDto initializePaymentRequestDto)
        {
            decimal totalPaymentAmount = 0;
            var salesIds = string.Empty;
            foreach(var saleId in initializePaymentRequestDto.SalesIds)
            {
                var sale = await _saleRepository.FindByCondition(s => s.Id == saleId, false).SingleOrDefaultAsync();
                if(sale  == null)
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
            var serializedDto = JsonSerializer.Serialize(new
            {
               email = initializePaymentRequestDto.CustomerEmail,
               amount = totalPaymentAmount.ToString()+"00"
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
                Amount = totalPaymentAmount,
                PaymentUrl = payment.Authorization_url
            };
            return StandardResponse<InitializePaymentResponseDto>.Succeeded("Reqeust successful", initializeResponseDto, 200);
        }
    }
}
