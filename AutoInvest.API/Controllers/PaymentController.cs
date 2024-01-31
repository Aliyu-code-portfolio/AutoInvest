using AutoInvest.Application.Abstraction;
using AutoInvest.Shared.DTO.Request;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AutoInvest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet("get-all-payments")]
        public async Task<IActionResult> GetAllPayments()
        {
            var result = await _paymentService.GetAllPayment();
            return StatusCode(result.StatusCode, result);
        }

        // GET api/<PaymentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PaymentController>
        [HttpPost("check-out")]
        public async Task<IActionResult> CheckOut([FromBody] InitializePaymentRequestDto paymentRequestDto)
        {
            var result = await _paymentService.InitializePayment( paymentRequestDto);
            return StatusCode(result.StatusCode, result);
        }

        // PUT api/<PaymentController>/5
        [HttpPut("confirm-payment/{paymentId}")]
        public async Task<IActionResult> ConfirmPayment(string paymentId)
        {
            var result = await _paymentService.ConfirmPayment(paymentId);
            return StatusCode(result.StatusCode);
        }

        // DELETE api/<PaymentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
