using Microsoft.AspNetCore.Mvc;
using RevInfotech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevInfotech.Services
{
    public interface IcommonServices
    {
        (JsonResult result, bool Succeeded) InsertState(State state);
        (JsonResult result, bool Succeeded) GetState();
        (JsonResult result, bool Succeeded) GetStatebyID(Guid id);
        (JsonResult result, bool Succeeded) DeleteState(Guid id);
        (JsonResult result, bool Succeeded) UpdateState(UpdateState state);
        (JsonResult result, bool Succeeded) InsertCity(City city);
        (JsonResult result, bool Succeeded) GetCity();
        (JsonResult result, bool Succeeded) GetCitybyID(Guid id);
        (JsonResult result, bool Succeeded) DeleteCity(Guid id);
        (JsonResult result, bool Succeeded) UpdateCity(Updatecity city);
        (JsonResult result, bool Succeeded) InsertCategory(Categorys category);
        (JsonResult result, bool Succeeded) GetCategory();
        (JsonResult result, bool Succeeded) GetCategorybyID(Guid id);
        (JsonResult result, bool Succeeded) DeleteCategory(Guid id);
        (JsonResult result, bool Succeeded) UpdateCategory(UpdateCategory updateCategory);
        (JsonResult result, bool Succeeded) InsertBlog(Blog blog);
        (JsonResult result, bool Succeeded) GetBlog(string city, string domainName);
        (JsonResult result, bool Succeeded) GetBlogbyID(Guid id, string city, string domainName);
        (JsonResult result, bool Succeeded) DeleteBlog(Guid id);
        (JsonResult result, bool Succeeded) UpdateBlog(UpdateBlog updateBlog);
        (JsonResult result, bool Succeeded) GetBlogByCategory(Guid categoryid, string city, string domainName);
        //(JsonResult result, bool Succeeded) GetBlogByCity(string city);
        (JsonResult result, bool Succeeded) InsertBlogDesc(BlogDesc blogdesc);
        (JsonResult result, bool Succeeded) GetBlogDesc();
        (JsonResult result, bool Succeeded) GetBlogDescbyID(Guid id);
        (JsonResult result, bool Succeeded) DeleteBlogDesc(Guid id);
        (JsonResult result, bool Succeeded) UpdateBlogDesc(UpdateBlogDesc updateBlogDesc);
        (JsonResult result, bool Succeeded) InsertBlogImage(Image image);
        (JsonResult result, bool Succeeded) GetBlogImage();
        (JsonResult result, bool Succeeded) GetBlogImagebyID(Guid id);
        (JsonResult result, bool Succeeded) DeleteBlogImage(Guid id);
        (JsonResult result, bool Succeeded) UpdateBlogImage(UpdatelogImage updatelogImage);
        //string GenerateRandomName(int length);
    }
}
