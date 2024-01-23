using AutoInvest.Shared.DTO.Request;
using AutoInvest.Shared.DTO.Response;

namespace AutoInvest.Application.Abstraction
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewResponseDto>> GetAllReview();
        Task<ReviewResponseDto> GetReveiwById(string reviewId);
        Task<ReviewResponseDto> CreateReviewAsync(string creatorId, ReviewRequestDto reviewRequestDto);
        Task UpdateVehicle(ReviewRequestDto reviewRequestDto);
        Task DeleteReview(string reviewId);
    }
}
