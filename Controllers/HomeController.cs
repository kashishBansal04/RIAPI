using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Amazon.S3;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RevInfotech.Context;
using RevInfotech.Models;
using RevInfotech.Services;

namespace RevInfotech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
         private IConfiguration _configuration;
        private IHostingEnvironment _Env;
        private readonly IcommonServices _commonServices;
        private readonly RevinfotechContext _context;
        private readonly IS3Service _s3Service;
        private readonly String s3BucketPath;
        private readonly String s3BucketName;
        public HomeController(IcommonServices commonServices, IConfiguration configuration, IHostingEnvironment envrnmt, RevinfotechContext revinfotechContext, IS3Service s3Service)
        {
            _context = revinfotechContext;
            _configuration = configuration;
            _commonServices = commonServices;
            _Env = envrnmt;
            _s3Service = s3Service;
            s3BucketPath = _configuration.GetSection("AWSPath:URL").Value.ToString();
            s3BucketName = _configuration.GetSection("AWSPath:bucketName").Value.ToString();
        }
        #region // STATE OPERATIONS
        [HttpPost("InsertState")]
        public IActionResult InsertState(State state)
        {
            if (!ModelState.IsValid) return BadRequest("Enter the correct values");
            var (result, succeeded) = _commonServices.InsertState(state);
            if (succeeded) return Ok(result);
            return BadRequest(result);
                       
        }
        [Authorize]
        [HttpGet("GetState")]
        public IActionResult GetState()
        {
            var (result, succeeded) = _commonServices.GetState();
            if (succeeded) return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("GetStatebyID")]
        public IActionResult GetStatebyID(Guid id)
        {
            var (result, succeeded) = _commonServices.GetStatebyID(id);
            if (succeeded) return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("DeleteState")]
        public IActionResult DeleteState(Guid id)
        {
            var (result, succeeded) = _commonServices.DeleteState(id);
            if (succeeded) return Ok(result);
            return BadRequest(result);
        }
        [HttpPut("UpdateState")]
        public IActionResult UpdateState(UpdateState state)
        {
            if (!ModelState.IsValid) return BadRequest("Enter the correct values");
            var (result, succeeded) = _commonServices.UpdateState(state);
            if (succeeded) return Ok(result);
            return BadRequest(result);
        }
        #endregion

        #region // CITY OPERATIONS

        [HttpPost("InsertCity")]
        public IActionResult InsertCity(City city)
        {
            if (!ModelState.IsValid) return BadRequest("Enter the correct values");
            var (result, succeeded) = _commonServices.InsertCity(city);
            if (succeeded) return Ok(result);
            return BadRequest(result);

        }
        [HttpGet("GetCity")]
        public IActionResult GetCity()
        {
            var (result, succeeded) = _commonServices.GetCity();
            if (succeeded) return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("GetCitybyID")]
        public IActionResult GetCitybyID(Guid id)
        {
            var (result, succeeded) = _commonServices.GetCitybyID(id);
            if (succeeded) return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("DeleteCity")]
        public IActionResult DeleteCity(Guid id)
        {
            var (result, succeeded) = _commonServices.DeleteCity(id);
            if (succeeded) return Ok(result);
            return BadRequest(result);
        }
        [HttpPut("UpdateCity")]
        public IActionResult UpdateCity(Updatecity city)
        {
            if (!ModelState.IsValid) return BadRequest("Enter the correct values");
            var (result, succeeded) = _commonServices.UpdateCity(city);
            if (succeeded) return Ok(result);
            return BadRequest(result);
        }
        #endregion

        #region // CATEGORY OPERATIONS

        [HttpPost("InsertCategory")]
        public IActionResult InsertCategory(Categorys categorys)
        {
            if (!ModelState.IsValid) return BadRequest("Enter the correct values");
            var (result, succeeded) = _commonServices.InsertCategory(categorys);
            if (succeeded) return Ok(result);
            return BadRequest(result);

        }
        [HttpGet("GetCategory")]
        public IActionResult GetCategory()
        {
            var (result, succeeded) = _commonServices.GetCategory();
            if (succeeded) return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("GetCategorybyID")]
        public IActionResult GetCategorybyID(Guid id)
        {
            var (result, succeeded) = _commonServices.GetCategorybyID(id);
            if (succeeded) return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("DeleteCategory")]
        public IActionResult DeleteCategory(Guid id)
        {
            var (result, succeeded) = _commonServices.DeleteCategory(id);
            if (succeeded) return Ok(result);
            return BadRequest(result);
        }
        [HttpPut("UpdateCategory")]
        public IActionResult UpdateCategory(UpdateCategory updateCategory)
        {
            if (!ModelState.IsValid) return BadRequest("Enter the correct values");
            var (result, succeeded) = _commonServices.UpdateCategory(updateCategory);
            if (succeeded) return Ok(result);
            return BadRequest(result);
        }
        #endregion

        #region // BLOG OPERATIONS

        [HttpPost("InsertBlog")]
        public IActionResult InsertBlog(Blog blog)
        {
            if (!ModelState.IsValid) return BadRequest("Enter the correct values");
            var (result, succeeded) = _commonServices.InsertBlog(blog);
            if (succeeded) return Ok(result);
            return BadRequest(result);

        }
        [HttpGet("GetBlog")]
        public IActionResult GetBlog(string city)
        {
            string domainName = HttpContext.Request.Host.Value;
            var (result, succeeded) = _commonServices.GetBlog(city,domainName);
            if (succeeded) return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("GetBlogbyID")]
        public IActionResult GetBlogbyID(Guid id,string city)
        {
            string domainName = HttpContext.Request.Host.Value;
            var (result, succeeded) = _commonServices.GetBlogbyID(id, city, domainName);
            if (succeeded) return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("DeleteBlog")]
        public IActionResult DeleteBlog(Guid id)
        {
            var (result, succeeded) = _commonServices.DeleteBlog(id);
            if (succeeded) return Ok(result);
            return BadRequest(result);
        }
        [HttpPut("UpdateBlog")]
        public IActionResult UpdateBlog(UpdateBlog updateblog)
        {
            if (!ModelState.IsValid) return BadRequest("Enter the correct values");
            var (result, succeeded) = _commonServices.UpdateBlog(updateblog);
            if (succeeded) return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("GetBlogByCategory")]
        public IActionResult GetBlogByCategory(Guid categoryid, string city)
        {
            string domainName = HttpContext.Request.Host.Value;
            var (result, succeeded) = _commonServices.GetBlogByCategory(categoryid, city, domainName);
            if (succeeded) return Ok(result);
            return BadRequest(result);
        }
        #endregion

        #region // BLOG DESCRIPTION OPERATIONS
        [HttpPost("InsertBlogDesc")]
        public IActionResult InsertBlogDesc(BlogDesc blogdesc)
        {
            if (!ModelState.IsValid) return BadRequest("Enter the correct values");
            var (result, succeeded) = _commonServices.InsertBlogDesc(blogdesc);
            if (succeeded) return Ok(result);
            return BadRequest(result);

        }
        [HttpGet("GetBlogDesc")]
        public IActionResult GetBlogDesc()
        {
            var (result, succeeded) = _commonServices.GetBlogDesc();
            if (succeeded) return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("GetBlogDescbyID")]
        public IActionResult GetBlogDescbyID(Guid id)
        {
            var (result, succeeded) = _commonServices.GetBlogDescbyID(id);
            if (succeeded) return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("DeleteBlogDesc")]
        public IActionResult DeleteBlogDesc(Guid id)
        {
            var (result, succeeded) = _commonServices.DeleteBlogDesc(id);
            if (succeeded) return Ok(result);
            return BadRequest(result);
        }
        [HttpPut("UpdateBlogDesc")]
        public IActionResult UpdateBlogDesc(UpdateBlogDesc updateBlogDesc)
        {
            if (!ModelState.IsValid) return BadRequest("Enter the correct values");
            var (result, succeeded) = _commonServices.UpdateBlogDesc(updateBlogDesc);
            if (succeeded) return Ok(result);
            return BadRequest(result);
        }
        #endregion
        #region //Blog Image
        [HttpPost("InsertBlogImage")]
        public IActionResult InsertBlogImage(Image image)
        {
            if (!ModelState.IsValid) return BadRequest("Enter the correct values");
            var (result, succeeded) = _commonServices.InsertBlogImage(image);
            if (succeeded) return Ok(result);
            return BadRequest(result);

        }
        [HttpPost("Images")]
        public IActionResult Images(Images3Bucket images3Bucket)
        {

            var Images = _s3Service.UploadFile(s3BucketName,images3Bucket.Imagebase64,images3Bucket.ImageName, S3CannedACL.PublicRead);
            if (Images.Succeeded)
            {
                String imagePath = s3BucketPath + s3BucketName + "/" + images3Bucket.ImageName;
                var ImageURL = imagePath;
                return Ok(ImageURL);
            }
            return BadRequest("Some server error occured");

        }
        [HttpGet("GetBlogImage")]
        public IActionResult GetBlogImage()
        {
            var (result, succeeded) = _commonServices.GetBlogImage();
            if (succeeded) return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("GetBlogImagebyID")]
        public IActionResult GetBlogImagebyID(Guid id)
        {
            var (result, succeeded) = _commonServices.GetBlogImagebyID(id);
            if (succeeded) return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("DeleteBlogImage")]
        public IActionResult DeleteBlogImage(Guid id)
        {
            var (result, succeeded) = _commonServices.DeleteBlogImage(id);
            if (succeeded) return Ok(result);
            return BadRequest(result);
        }
        [HttpPut("UpdateBlogImage")]
        public IActionResult UpdateBlogImage(UpdatelogImage updatelogImage)
        {
            if (!ModelState.IsValid) return BadRequest("Enter the correct values");
            var (result, succeeded) = _commonServices.UpdateBlogImage(updatelogImage);
            if (succeeded) return Ok(result);
            return BadRequest(result);
        }
#endregion
    }
}