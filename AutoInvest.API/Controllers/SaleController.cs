using AutoInvest.Application.Abstraction;
using AutoInvest.Shared.DTO.Request;
using Microsoft.AspNetCore.Mvc;

namespace AutoInvest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase

    {
        private readonly ISaleService _saleService;

        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }


        [HttpGet("get-all-sales")]
        public async Task<IActionResult> GetAllSales()
        {
            var result = await _saleService.GetAllSales();
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("get-sales-by-Id/{id}", Name = "GetById")]
        public async Task<IActionResult> GetSalesById(string id)
        {
            var result = await _saleService.GetSalesById(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("create-shop")]
        public async Task<IActionResult> CreateSale([FromBody] SaleRequestDto salesRequestDto)
        {
            var creatorId = "1234";
            var result = await _saleService.CreateSaleAsync(creatorId, salesRequestDto);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("update-shop/{Id}")]
        public async Task<IActionResult> UpdateSale(string Id, [FromBody] SaleRequestDto saleRequestDto)
        {
            var result = await _saleService.UpdateSale(Id, saleRequestDto);
            return StatusCode(result.StatusCode, result);
        }


    }
}
