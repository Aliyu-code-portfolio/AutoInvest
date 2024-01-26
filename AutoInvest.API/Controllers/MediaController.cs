using AutoInvest.Application.Abstraction;
using AutoInvest.Application.Implementation;
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

        [HttpPost("create-media")]
        public async Task<IActionResult> CreateMedia([FromBody] MediaRequestDto mediaRequestDto)
        {
            var creatorId = "1234";//pull from JWT
            var result = await _mediaService.CreateMediaAsync(creatorId, mediaRequestDto);
            return CreatedAtAction(nameof(GetMediaById), new { Id = result.Data.Id }, result.Data);
        }

        [HttpGet("get-media-by-Id/{Id}", Name="GetMediaById")]
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
        
        [HttpPut("upload-media/{Id}")]
        public async Task<IActionResult> UpdateMedia(string Id, IFormFile file)
        {
            var result = await _mediaService.UploadMedia(Id, file);
            return StatusCode(result.StatusCode, result);
        }

        
    }
}
