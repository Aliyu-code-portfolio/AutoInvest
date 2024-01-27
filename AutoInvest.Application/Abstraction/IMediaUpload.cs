using Microsoft.AspNetCore.Http;

namespace AutoInvest.Application.Abstraction
{
    public interface IMediaUpload
    {
        string UploadImage(IFormFile file);
        string UploadVideo(IFormFile file);
    }

}
