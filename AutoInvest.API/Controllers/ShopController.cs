using AutoInvest.Application.Abstraction;
using AutoInvest.Shared.DTO.Request;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AutoInvest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IShopService _shopService;

        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }

        [HttpGet("get-all-shops")]
        public async Task<IActionResult> GetAllShops()
        {
            var result =await _shopService.GetAllShop();
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("get-shop-by-id/{id}",Name ="GetShopById")]
        public async Task<IActionResult> GetShopById(string id)
        {
            var result = await _shopService.GetShopById(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("create-shop")]
        public async Task<IActionResult> CreateShop([FromBody] ShopRequestDto shopRequestDto)
        {
            var creatorId = "1234";//pull from JWT
            var result = await _shopService.CreateShopAsync(creatorId, shopRequestDto);
            return CreatedAtAction(nameof(GetShopById), new { Id = result.Data.Id }, result.Data);
            //return StatusCode(result.StatusCode, result);
        }

        [HttpPut("update-shop/{id}")]
        public async Task<IActionResult> UpdateShopById(string id, [FromBody] ShopRequestDto shopRequestDto)
        {
            var result = await _shopService.UpdateShop(id,shopRequestDto);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("delete-shop/{id}")]
        public async Task<IActionResult> DeleteShopById(string id)
        {
            var result = await _shopService.DeleteShop(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}
