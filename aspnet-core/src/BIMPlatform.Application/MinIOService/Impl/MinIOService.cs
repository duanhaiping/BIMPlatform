using BIMPlatform.Application.Contracts.MinIO;
using BIMPlatform.Configurations;
using Minio;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BIMPlatform.MinIOService.Impl
{
    public class MinIOService : BaseService, IMinIOService
    {
       
        public Task Delete(string fileName)
        {
            MinioClient minioClient = new MinioClient(AppSettings.MinIO.EndPoint, AppSettings.MinIO.AccessKey, AppSettings.MinIO.SecretKey);
            minioClient.RemoveObjectAsync(AppSettings.MinIO.BucketName, fileName);
            return Task.CompletedTask;
        }

        public async Task<MinioUploadDto> Upload(IFormFile file)
        {
            MinioClient minioClient = new MinioClient(AppSettings.MinIO.EndPoint, AppSettings.MinIO.AccessKey, AppSettings.MinIO.SecretKey);
            bool isExist = await minioClient.BucketExistsAsync(AppSettings.MinIO.BucketName);
            if (!isExist)
            {
                minioClient.MakeBucketAsync(AppSettings.MinIO.BucketName);
                //minioClient.SetPolicyAsync(AppSettings.MinIO.BucketName, "*.*", PolicyType.WRITE_ONLY);
            }
            var fileName = file.Name;
            string objectName = $"{Clock.Now.ToString("yyyyMMdd")}/fileName";
            minioClient.PutObjectAsync(AppSettings.MinIO.BucketName, objectName, fileName, file.ContentType);
            MinioUploadDto minioUploadDto = new MinioUploadDto
            {
                FileName = fileName,
                Url = $"{AppSettings.MinIO.EndPoint}/{AppSettings.MinIO.BucketName}/{objectName}",
            };
            return minioUploadDto;
        }

        public async Task<IList<MinioUploadDto>> Upload(ICollection<IFormFile> files)
        {
            IList<MinioUploadDto> minioUploadDtos = new List<MinioUploadDto>();
            MinioClient minioClient = new MinioClient(AppSettings.MinIO.EndPoint, AppSettings.MinIO.AccessKey, AppSettings.MinIO.SecretKey);
            bool isExist = await minioClient.BucketExistsAsync(AppSettings.MinIO.BucketName);
            if (!isExist)
            {
                minioClient.MakeBucketAsync(AppSettings.MinIO.BucketName);
                //minioClient.SetPolicyAsync(AppSettings.MinIO.BucketName, "*.*", PolicyType.WRITE_ONLY);
            }
            foreach (var file in files)
            {
                var fileName = file.Name;
                string objectName = $"{Clock.Now.ToString("yyyyMMdd")}/fileName";
                minioClient.PutObjectAsync(AppSettings.MinIO.BucketName, objectName, fileName, file.ContentType);
                MinioUploadDto minioUploadDto = new MinioUploadDto
                {
                    FileName = fileName,
                    Url = $"{AppSettings.MinIO.EndPoint}/{AppSettings.MinIO.BucketName}/{objectName}",
                };
                minioUploadDtos.Add(minioUploadDto);
            }
           
            return minioUploadDtos;
        }
    }
}
