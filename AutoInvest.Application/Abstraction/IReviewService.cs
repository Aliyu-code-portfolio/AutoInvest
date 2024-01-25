using AutoInvest.Shared.DTO.Request;
using AutoInvest.Shared.DTO.Response;
using AutoInvest.Shared.DTO.StandardResponse;

namespace AutoInvest.Application.Abstraction
{
    public interface IReviewService
    {
        Task<StandardResponse<IEnumerable<ReviewResponseDto>>> GetAllReview();
        Task<StandardResponse<ReviewResponseDto>> GetReveiwById(string reviewId);
        Task<StandardResponse<ReviewResponseDto>> CreateReviewAsync(string creatorId, ReviewRequestDto reviewRequestDto);
        Task UpdateReview(string reviewId, ReviewRequestDto reviewRequestDto);
        Task <StandardResponse<string>>DeleteReview(string reviewId);
    }
}
