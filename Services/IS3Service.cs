using Amazon.S3;
using Microsoft.AspNetCore.Mvc;

namespace RevInfotech.Services
{
    public interface IS3Service
    {
        (JsonResult result, bool Succeeded, string Error) CreatBucket(string bucketName);
        (JsonResult result, bool Succeeded, string Error) UploadFile(string bucketName, string base64String, string Path, S3CannedACL s3CannedACL);
    }
}