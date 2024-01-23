using AutoInvest.Shared.DTO.Request;
using AutoInvest.Shared.DTO.Response;

namespace AutoInvest.Application.Abstraction
{
    public interface IMediaService
    {
        Task<IEnumerable<MediaResponseDto>> GetAllMedia();
        Task<MediaResponseDto> GetMediaById(string mediaId);
        Task<MediaResponseDto> CreateMediaAsync(string creatorId, MediaRequestDto mediaRequestDto);
        Task DeleteMedia(string mediaId);
    }
}
