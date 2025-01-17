using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Project.BL.ExternalServices.Abstactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.ExternalServices.Implementations
{
    public class FileUpload : IFileUpload
    {
        public Task DeleteFile(string fileNameWithExtensions)
        {
            
        }

        public Task<string> UploadFile(IFormFile filePath, string allowedExtensions)
        {
            throw new NotImplementedException();
        }
    }
}
