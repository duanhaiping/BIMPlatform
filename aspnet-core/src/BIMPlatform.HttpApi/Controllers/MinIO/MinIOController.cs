using BIMPlatform.Application.Contracts.MinIO;
using BIMPlatform.MinIOService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Platform.ToolKits.Base;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BIMPlatform.Controllers.MinIO
{
    /// <summary>
    /// MinIO 文件存储
    /// </summary>
    [ApiExplorerSettings(GroupName = ApiGrouping.GroupName_v1)]
    public class MinIOController : BaseController
    {
        private IMinIOService MinIOService { get; set; }
        public MinIOController(IMinIOService minIOService)
        {
            this.MinIOService = minIOService;
        }
        /// <summary>
        /// 上传文件-单文件上传
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerResponse(200, "", typeof(ServiceResult<MinioUploadDto>))]
        public async Task<ServiceResult> Upload(IFormFile file)
        {
            var minioUploadDto = await MinIOService.Upload(file);
            return await ServiceResult<MinioUploadDto>.IsSuccess(minioUploadDto);
        }
        /// <summary>
        ///  上传文件-多单文件上传
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerResponse(200, "", typeof(ServiceResult<MinioUploadDto>))]
        public async Task<ServiceResult> MuiltUpload(ICollection<IFormFile> files)
        {
            var minioUploadDto = await MinIOService.Upload(files);
            return await ServiceResult<IList< MinioUploadDto>>.IsSuccess(minioUploadDto);
        }
        [HttpDelete]
        [SwaggerResponse(200, "", typeof(ServiceResult<MinioUploadDto>))]
        public async Task<ServiceResult> Delete([FromQuery]string fileName)
        {
            await MinIOService.Delete(fileName);
            return await ServiceResult.IsSuccess();
        }
    }
}
