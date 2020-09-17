using BIMPlatform.Application.Contracts.MinIO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BIMPlatform.MinIOService
{
    public interface IMinIOService
    {
        public Task<MinioUploadDto> Upload(IFormFile file);
        public Task<IList<MinioUploadDto>> Upload(ICollection<IFormFile> files);
        public Task Delete(string fileName);
    }
}
