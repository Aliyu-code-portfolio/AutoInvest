using AutoInvest.Application.Abstraction;
using AutoInvest.Shared.SettingModel;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Serilog;

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
        public string UploadImage(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();
            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(file.Name, stream),
                    /*PublicId = id,
                    Folder = folder*/
                };
                uploadResult = _cloudinary.Upload(uploadParams);
            }
            string url = uploadResult.Url.ToString();
            string publicId = uploadResult.PublicId;

            //check quality of uploaded image
            CheckQuality(publicId);
            return url;
        }

        public string UploadVideo(IFormFile file)
        {
            var uploadResult = new VideoUploadResult();
            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new VideoUploadParams()
                {
                    File = new FileDescription(file.Name, stream),
                    /*PublicId = id,
                    Folder = folder*/
                };
                uploadResult = _cloudinary.Upload(uploadParams);
            }
            string url = uploadResult.Url.ToString();
            return url;
        }

        private void CheckQuality(string publicId)
        {
            var getResourceParams = new GetResourceParams(publicId)
            {
                QualityAnalysis = true
            };
            var getResourceResult = _cloudinary.GetResource(getResourceParams);
            var resultJson = getResourceResult.JsonObj;
            var analysis = resultJson["quality_analysis"];
            var analysisInDouble = double.Parse(analysis["focus"].ToString());
            if (!(analysisInDouble >= 0.6))
            {
                /*RemoveUploadedPhoto(publicId, folder);
                throw new ImageBadQualityException();*/
                Log.Logger.Warning($"Image upload quality is poor, time of upload {DateTime.UtcNow.AddHours(1)}");
            }
        }
    }
}
