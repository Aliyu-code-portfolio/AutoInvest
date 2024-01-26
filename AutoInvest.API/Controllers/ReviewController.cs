using AutoInvest.Application.Abstraction;
using AutoInvest.Shared.DTO.Request;
using Microsoft.AspNetCore.Mvc;

namespace AutoInvest.API.Controllers
{
    [Route("api/Controller")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet("get-all review")]
        public async Task<IActionResult> GetAllReview()
        {
            var result = await _reviewService.GetAllReview();
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("get-review-by-Id/{Id}")]
        public async Task<IActionResult> GetReviewById(string id)
        {
            var result = await _reviewService.GetReveiwById(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("create-review")]
        public async Task<IActionResult> CreateReview([FromBody] ReviewRequestDto reviewRequestDto)
        {
            var creatorId = "1234";
            var result = await _reviewService.CreateReviewAsync(creatorId, reviewRequestDto);
            return StatusCode(result.StatusCode, result);
        }


        [HttpDelete("delete-review/{Id}")]

        public async Task<IActionResult> DeleteReviewById(string Id)
        {
            var result = await _reviewService.DeleteReview(Id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("update-review/{Id}")]
        public async Task<IActionResult> UpdateReview(string Id, [FromBody] ReviewRequestDto reviewRequestDto)
        {
            var result = await _reviewService.UpdateReview(Id, reviewRequestDto);
            return StatusCode(result.StatusCode, result);
        }


    }
}
