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
        Task<string> UploadFile(FormFile file, string envPath);
        Task DeleteFile( string envPath);
    }
}
