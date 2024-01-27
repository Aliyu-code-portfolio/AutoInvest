using AutoInvest.Application.Abstraction;
using AutoInvest.Domain.Enums;
using AutoInvest.Domain.Models;
using AutoInvest.Infrastructure.Repository.Abstraction;
using AutoInvest.Shared.DTO.Request;
using AutoInvest.Shared.DTO.Response;
using AutoInvest.Shared.DTO.StandardResponse;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace AutoInvest.Application.Implementation
{
    public class MediaService : IMediaService

    {
        private readonly IRepositoryBase<Media> _repositoryBase;
        private readonly IMediaUpload _mediaUpload;
        private readonly IMapper _mapper;

        public MediaService(IRepositoryBase<Media> repositoryBase, IMapper mapper, IMediaUpload mediaUpload)
        {
            _repositoryBase = repositoryBase;
            _mapper = mapper;
            _mediaUpload = mediaUpload;
        }




        public async Task<StandardResponse<MediaResponseDto>> CreateMediaAsync(string creatorId, MediaRequestDto mediaRequestDto)
        {
            var media = _mapper.Map<Media>(mediaRequestDto);
            media.CreatorId = creatorId;
            await _repositoryBase.CreateAsync(media);
            await _repositoryBase.SaveChangesAsync();
            var mediaDto = _mapper.Map<MediaResponseDto>(media);
            return StandardResponse<MediaResponseDto>.Succeeded("Media created successfully", mediaDto, 200);
        }

        public async Task<StandardResponse<IEnumerable<MediaResponseDto>>> GetAllMedia()
        {
            var media = await _repositoryBase.FindAll(trackChanges: true).ToListAsync();
            var mediaDtos = _mapper.Map<IEnumerable<MediaResponseDto>>(media);
            return StandardResponse<IEnumerable<MediaResponseDto>>.Succeeded("Media retrieved successfully", mediaDtos, 200);
        }

        public async Task<StandardResponse<MediaResponseDto>> GetMediaById(string mediaId)
        {
            var media = await _repositoryBase.FindByCondition(trackChanges: false, expression: x => x.Id == mediaId).SingleOrDefaultAsync();
            if (media == null)
            {
                return StandardResponse<MediaResponseDto>.Failed("Media Cannot be found", 404);
            }
            var mediaDto = _mapper.Map<MediaResponseDto>(media);
            return StandardResponse<MediaResponseDto>.Succeeded("Media found successfully", mediaDto, 200);
        }

        public async Task<StandardResponse<string>> DeleteMedia(string mediaId)
        {
            var media = await _repositoryBase.FindByCondition(trackChanges: false, expression: x => x.Id == mediaId).SingleOrDefaultAsync();
            if (media == null)
            {
                return StandardResponse<string>.Failed("Media does not exist", 404);
            }
            _repositoryBase.Delete(media);
            await _repositoryBase.SaveChangesAsync();
            return StandardResponse<string>.Succeeded("Delete Successful", "Deleted", 200);
        }

        public async Task<StandardResponse<string>> UpdateMedia(string mediaId, MediaRequestDto mediaRequestDto)
        {
            var media = await _repositoryBase.FindByCondition(trackChanges: true, expression: x => x.Id == mediaId).SingleOrDefaultAsync();
            if (media == null)
            {
                return StandardResponse<string>.Failed("Media not found", 404);
            }
            _mapper.Map(media, mediaRequestDto);
            await _repositoryBase.SaveChangesAsync();
            return StandardResponse<string>.Succeeded("Media successfully updated", "Success", 200);
        }

        public async Task<StandardResponse<string>> UploadMedia(string mediaId, IFormFile file)
        {
            var media = await _repositoryBase.FindByCondition(m => m.Id == mediaId, true).SingleOrDefaultAsync();
            if (media == null)
            {
                return StandardResponse<string>.Failed("Media not found", 400);
            }

            string imageUrl = string.Empty;
            if (media.MediaType == MediaType.Images)
            {
                imageUrl = _mediaUpload.UploadImage(file);
            }
            else if(media.MediaType == MediaType.Video)
            {
                imageUrl = _mediaUpload.UploadVideo(file);
            }
            if (string.IsNullOrEmpty(imageUrl))
            {
                return StandardResponse<string>.Failed("Upload failed", 400);
            }
            media.Url = imageUrl;
            await _repositoryBase.SaveChangesAsync();
            return StandardResponse<string>.Succeeded("Upload successful", imageUrl,200);
        }
    }
}
