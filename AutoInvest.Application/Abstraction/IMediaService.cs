using AutoInvest.Shared.DTO.Request;
using AutoInvest.Shared.DTO.Response;
using AutoInvest.Shared.DTO.StandardResponse;

namespace AutoInvest.Application.Abstraction
{
    public interface IMediaService
    {
        Task <StandardResponse<IEnumerable<MediaResponseDto>>> GetAllMedia();
        Task<StandardResponse<MediaResponseDto>> GetMediaById(string mediaId);
        Task <StandardResponse<MediaResponseDto>> CreateMediaAsync(string creatorId, MediaRequestDto mediaRequestDto);
        Task <StandardResponse<string>>DeleteMedia(string mediaId);
    }
}
