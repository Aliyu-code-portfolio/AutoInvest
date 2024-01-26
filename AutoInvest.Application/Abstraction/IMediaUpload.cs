using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoInvest.Application.Abstraction
{
    public interface IMediaUpload
    {
        void UploadImage(IFormFile file);
        void UploadVideo(IFormFile file);
    }

}
