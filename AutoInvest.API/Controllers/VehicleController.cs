using AutoInvest.Application.Abstraction;
using AutoInvest.Shared.DTO.Request;
using Microsoft.AspNetCore.Mvc;

namespace AutoInvest.API.Controllers
{
    [Route("api/Controller")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet("get-all-video")]
        public async Task<IActionResult> GetAllVehicle()
        {
            var result = await _vehicleService.GetAllVehicle();
            return StatusCode(result.StatusCode,result);
        }

        [HttpGet("get-vehicle-by-Id/{Id}")]
        public async Task<IActionResult> GetVehicleById(string Id)
        {
            var result = await _vehicleService.GetVehicleById(Id);
            return StatusCode(result.StatusCode,result);
        }

        [HttpPost("create-vehicle")]
        public async Task<IActionResult> CreateVehicle([FromBody] VehicleRequestDto vehicleRequestDto)
        {
            var shopId = "1234";
            var result = await _vehicleService.CreateVehicleAsync(shopId, vehicleRequestDto);
            return StatusCode(result.StatusCode,result);
        }

        
        [HttpPut("update-vehicle/{Id}")]
        public async Task<IActionResult> UpdateVehicle(string id, VehicleRequestDto vehicleRequestDto)
        {
            var result = await _vehicleService.UpdateVehicle(id, vehicleRequestDto);
            return StatusCode(result.StatusCode,result);
        }

       [HttpDelete("delete-vehicle/{Id}")]
        public async Task<IActionResult> DeleteVehicle(string id)
        {
            var  result = await _vehicleService.DeleteVehicle(id);
            return StatusCode(result.StatusCode,result);
        }

        
    }
}
