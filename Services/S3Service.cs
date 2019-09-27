using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Amazon.S3.Util;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net;

namespace RevInfotech.Services
{
    public class S3Service : IS3Service
    {
        private static IAmazonS3 _client;
        
        private readonly IHostingEnvironment _env;

        public S3Service(IAmazonS3 client, IHostingEnvironment env)
        {
            _client = client;//new AmazonS3Client("AKIAJOZ675Z5E4B2UIQA", "ViySTT0/or7AQyoyT06KoYLrQwEVUxFrQCVwdam+", RegionEndpoint.USEast2);
                             // _client =new AmazonS3Client("AKIAJOZ675Z5E4B2UIQA", "ViySTT0/or7AQyoyT06KoYLrQwEVUxFrQCVwdam+", RegionEndpoint.USEast2);
           
            _env = env;
        }

        public (JsonResult result, bool Succeeded, string Error) CreatBucket(string bucketName)
        {
            try
            {

                if (AmazonS3Util.DoesS3BucketExistV2Async(_client, bucketName).GetAwaiter().GetResult() == false)
                {
                    var putBucketRequest = new PutBucketRequest
                    {
                        BucketName = bucketName,
                        UseClientRegion = true
                    };
                    var response = _client.PutBucketAsync(putBucketRequest).GetAwaiter().GetResult();
                    if (response.HttpStatusCode == HttpStatusCode.OK)
                    {
                        return (new JsonResult("Bucket created successfully."), true, "");
                    }
                    else
                    {
                        return (new JsonResult("Bucket creation failed."), false, "Bucket creation failed.");
                    }
                }
                else
                {
                    return (new JsonResult("Bucket already exist."), false, "Bucket already exist.");
                }
            }
            catch (Exception ex)
            {
               
                return (new JsonResult("Bucket creation failed."), false, "Bucket creation failed.");
            }
        }

        public (JsonResult result, bool Succeeded, string Error) UploadFile(string bucketName, string base64String, string Path, S3CannedACL s3CannedACL)
        {
            try
            {
                if (AmazonS3Util.DoesS3BucketExistV2Async(_client, bucketName).GetAwaiter().GetResult())
                {
                    PutObjectRequest folderRequest = new PutObjectRequest();
                    var fileTransferUtility = new TransferUtility(_client);
                    byte[] bytes = Convert.FromBase64String(base64String);
                    var fileToUpload = new MemoryStream(bytes);
                    TransferUtilityUploadRequest request = new TransferUtilityUploadRequest();
                    request.BucketName = bucketName;
                    request.CannedACL = s3CannedACL.Value;
                    request.InputStream = fileToUpload;
                    request.Key = Path;
                    fileTransferUtility.Upload(request);
                    return (new JsonResult("File uploaded successfully."), true, "");
                }
                else
                {
                    return (new JsonResult("Bucket not exist."), false, "Bucket not exist.");
                }
            }
            catch (Exception ex)
            {
               
                return (new JsonResult("File upload failed."), false, "File upload failed.");
            }
        }

    }
}
