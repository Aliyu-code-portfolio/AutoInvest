using AutoInvest.Shared.DTO.Request;
using AutoInvest.Shared.DTO.Response;
using AutoInvest.Shared.DTO.StandardResponse;
using Microsoft.AspNetCore.Http;

namespace AutoInvest.Application.Abstraction
{
    public interface IMediaService
    {
        Task <StandardResponse<IEnumerable<MediaResponseDto>>> GetAllMedia();
        Task<StandardResponse<MediaResponseDto>> GetMediaById(string mediaId);
        Task <StandardResponse<MediaResponseDto>> CreateMediaAsync(string creatorId, MediaRequestDto mediaRequestDto);
        Task <StandardResponse<string>>DeleteMedia(string mediaId);
        Task<StandardResponse<string>> UpdateMedia(string mediaId, MediaRequestDto mediaRequestDto);
        Task<StandardResponse<string>> UploadMedia(string mediaId, IFormFile file);
    }
}
