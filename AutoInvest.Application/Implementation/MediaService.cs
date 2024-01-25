using AutoInvest.Application.Abstraction;
using AutoInvest.Domain.Models;
using AutoInvest.Infrastructure.Repository.Abstraction;
using AutoInvest.Shared.DTO.Request;
using AutoInvest.Shared.DTO.Response;
using AutoInvest.Shared.DTO.StandardResponse;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoInvest.Application.Implementation
{
    public class MediaService : IMediaService

    {
        private readonly IRepositoryBase<Media> _repositoryBase;
        private readonly IMapper _mapper;

        public Task<StandardResponse<MediaResponseDto>> CreateMediaAsync(string creatorId, MediaRequestDto mediaRequestDto)
        {
            throw new NotImplementedException();
        }

        public async Task<StandardResponse<IEnumerable<MediaResponseDto>>> GetAllMedia()
        {
            var media = await _repositoryBase.FindAll(trackChanges: true).ToListAsync();
            var mediaDtos = _mapper.Map<IEnumerable<MediaResponseDto>>(media);
            return StandardResponse<IEnumerable<MediaResponseDto>>.Succeeded("Media retrieved successfully", mediaDtos, 200);
        }

        public async Task<StandardResponse<MediaResponseDto>> GetMediaById(string mediaId)
        {
            var media = await _repositoryBase.FindByCondition(trackChanges:false, expression: x => x.Id == mediaId).SingleOrDefaultAsync(); 
            if (media == null)
            {
                return StandardResponse<MediaResponseDto>.Failed("Media Cannot be found", 404);
            }
            var mediaDto= _mapper.Map<MediaResponseDto>(media);
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
            return StandardResponse<string>.Succeeded("Delete Successful", "Deleted");
        }

        

        
    }
}
