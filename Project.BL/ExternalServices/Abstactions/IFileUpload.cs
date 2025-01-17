using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.ExternalServices.Abstactions
{
    public interface IFileUpload
    {
        Task<string> UploadFile(IFormFile filePath, string allowedExtensions);
        Task DeleteFile( string fileNameWithExtensions);
    }
}
