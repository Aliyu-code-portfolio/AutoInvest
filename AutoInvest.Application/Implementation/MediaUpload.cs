using AutoInvest.Application.Abstraction;
using AutoInvest.Shared.SettingModel;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace AutoInvest.Application.Implementation
{
    public class MediaUpload : IMediaUpload
    {
        private readonly Cloudinary _cloudinary;
        public MediaUpload(IOptions<CloudinarySetting> cloudinarySettings)
        {

            Account account = new Account(cloudinarySettings.Value.CloudName , cloudinarySettings.Value.ApiKey, cloudinarySettings.Value.ApiSecret);
            _cloudinary = new Cloudinary(account);
        }
        public void UploadImage(IFormFile file)
        {
            throw new NotImplementedException();
        }

        public void UploadVideo(IFormFile file)
        {
            throw new NotImplementedException();
        }
    }
}
