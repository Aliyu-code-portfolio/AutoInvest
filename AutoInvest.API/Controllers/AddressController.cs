using AutoInvest.Application.Abstraction;
using AutoInvest.Shared.DTO.Request;
using AutoInvest.Shared.DTO.Response;
using Microsoft.AspNetCore.Mvc;

namespace AutoInvest.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }


        [HttpGet("get-all-address")]
        public async Task<IActionResult> GetAllAddress()
        {
            var result = await _addressService.GetAllAddress();
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("get-address-by-Id/{Id}")]
        public async Task<IActionResult> GetAddressById(string id, [FromBody] AddressResponseDto addressResponseDto)
        {
            var result = await _addressService.GetAddressById(id, addressResponseDto);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("Create-address")]
        public async Task<IActionResult> CreateAddress([FromBody] AddressRequestDto addressRequestDto)
        {
            string creatorId = "1234";
            var result = await _addressService.CreateAddressAsync(creatorId, addressRequestDto);
            return StatusCode(result.StatusCode, result);
        }

        
        [HttpDelete("delete-address/{Id}")]
        
        public async Task<IActionResult> DeleteAddress(string Id)
        {
            var result = await _addressService.DeleteAddress(Id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("update-address/{Id}")]
        public async Task<IActionResult> UpdateAddress(string Id, [FromBody] AddressRequestDto addressRequestDto)
        {
            var result = await _addressService.UpdateAddress(Id,addressRequestDto);
            return StatusCode(result.StatusCode, result);
        }

        
    }
}
