using AutoInvest.Application.Abstraction;
using AutoInvest.Domain.Models;
using AutoInvest.Infrastructure.Repository.Abstraction;
using AutoInvest.Shared.DTO.Request;
using AutoInvest.Shared.DTO.Response;
using AutoInvest.Shared.DTO.StandardResponse;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AutoInvest.Application.Implementation
{
    public class ReviewService : IReviewService

    {
        private readonly IRepositoryBase<Review> _repositoryBase;
        private readonly IMapper _mapper;
        public ReviewService(IRepositoryBase<Review> repositoryBase, IMapper mapper)
        {
            _repositoryBase = repositoryBase;
            _mapper = mapper;
        }



        public async Task<StandardResponse<ReviewResponseDto>> CreateReviewAsync(string creatorId, ReviewRequestDto reviewRequestDto)
        {
            var review = _mapper.Map<Review>(reviewRequestDto);
            review.CreatorId = creatorId;
             await _repositoryBase.CreateAsync(review);
            await _repositoryBase.SaveChangesAsync();
            var reviewResponse = _mapper.Map<ReviewResponseDto>(review);
            return StandardResponse<ReviewResponseDto>.Succeeded("Review successfully created", reviewResponse, 200);
        }

        public async Task<StandardResponse<string>> DeleteReview(string reviewId)
        {
            var review = await _repositoryBase.FindByCondition(trackChanges: false, expression: x => x.Id == reviewId).SingleOrDefaultAsync();
            if (review == null)
            {
                return StandardResponse<string>.Failed("Review was not found", 404);

            }
            _repositoryBase.Delete(review);
            await _repositoryBase.SaveChangesAsync();
            return StandardResponse<string>.Succeeded("Review Successfully found", "Success", 200);
        }

        public async Task<StandardResponse<IEnumerable<ReviewResponseDto>>> GetAllReview()
        {
            var review = await _repositoryBase.FindAll(trackChanges: false).ToListAsync();
            var reviewDtos = _mapper.Map<IEnumerable<ReviewResponseDto>>(review);
            return StandardResponse<IEnumerable<ReviewResponseDto>>.Succeeded("Review Successfully found", reviewDtos, 200);
        }

        public async Task<StandardResponse<ReviewResponseDto>> GetReveiwById(string reviewId)
        {
            var review = _repositoryBase.FindByCondition(trackChanges: false, expression: x => x.Id == reviewId).SingleOrDefaultAsync();
            if (review == null)
            {
                return StandardResponse<ReviewResponseDto>.Failed(" Review not found", 404);
            }
            
            var reviewDto = _mapper.Map<ReviewResponseDto>(review);
            return StandardResponse<ReviewResponseDto>.Succeeded("Review was found", reviewDto, 200);
        }

        public async Task <StandardResponse<string>> UpdateReview(string reviewId, ReviewRequestDto reviewRequestDto)
        {
            var review = await _repositoryBase.FindByCondition(trackChanges: true, expression: x => x.Id == reviewId).SingleOrDefaultAsync();
            if (review == null)
            {
                return StandardResponse<string>.Failed("Review was not updated", 404);

            }
            var reviewDto = _mapper.Map(reviewRequestDto, review);
            await _repositoryBase.SaveChangesAsync();
            return StandardResponse<string>.Succeeded("Review was updated successfully", "Sucess", 200);
            

        }

        
    }
}

        
    
