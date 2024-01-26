using AutoInvest.Application.Abstraction;
using AutoInvest.Shared.DTO.Request;
using Microsoft.AspNetCore.Mvc;

namespace AutoInvest.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private readonly IMediaService _mediaService;

        public MediaController(IMediaService mediaService)
        {
            _mediaService = mediaService;
        }

        [HttpGet("get-all-media")]
        public async Task<IActionResult> GetAllMedia()
        {
            var result = await _mediaService.GetAllMedia();
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("get-media-by-Id/{Id}", Name="GetById")]
        public async Task<IActionResult> GetMediaById(string Id)
        {
            var result = await _mediaService.GetMediaById(Id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("delete-media/{Id}")]
        public async Task<IActionResult> DeleteMedia(string Id)
        {
            var result = await _mediaService.DeleteMedia(Id);
            return StatusCode(result.StatusCode, result);
        }

       
        [HttpPut("update-media/{Id}")]
        public async Task<IActionResult> UpdateMedia(string Id, [FromBody] MediaRequestDto mediaRequestDto)
        {
            var result = await _mediaService.UpdateMedia(Id, mediaRequestDto);
            return StatusCode(result.StatusCode, result);
        }

        
    }
}
