using AutoInvest.Shared.DTO.Request;
using AutoInvest.Shared.DTO.Response;

namespace AutoInvest.Application.Abstraction
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewRequestDto>> GetAllReview();
        Task<ReviewRequestDto> GetReveiwById(string reviewId);
        Task<ReviewRequestDto> CreateReviewAsync(string creatorId, ReviewResponseDto reviewResponseDto);
        Task UpdateVehicle(ReviewResponseDto reviewResponseDto);
        Task DeleteReview(string reviewId);
    }
}
