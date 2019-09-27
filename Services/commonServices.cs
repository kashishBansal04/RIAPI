using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RevInfotech.Context;
using RevInfotech.Models;
using Microsoft.AspNetCore.Http.Extensions;


namespace RevInfotech.Services
{
    public class commonServices : IcommonServices
    {
      
        private readonly IConfiguration _configuration;
        private readonly RevinfotechContext _context;
        public commonServices(IConfiguration configuration, RevinfotechContext revinfotechContext)
        {
            _configuration = configuration;          
            _context = revinfotechContext;
        }


        #region State OPerations
        public (JsonResult result, bool Succeeded) InsertState(State state)
        {
            try
            {
                var states = _context.StateEntitys.Where(p => p.StateName == state.StateName);
                if(states == null)
                {
                    var entity = new StateEntity
                    {
                        StateName = state.StateName,
                        StatusID = state.StatusID,
                        StateCode = state.StateCode,
                    };
                    _context.StateEntitys.Add(entity);
                    if (_context.SaveChanges() == 1)
                    {
                        return (new JsonResult("State added successfully."), true);
                    }
                    else
                    {
                        return (new JsonResult("Enter the correct values."), false);
                    }
                }
                else
                {
                    return (new JsonResult("The state already exist"),false);
                }
                
            }
            catch(Exception ex)
            {
                return (new JsonResult("Some server error occured. Please try again!!"), false);
            }
        }
        public (JsonResult result, bool Succeeded) GetState()
        {
            try
            {
                var states = _context.StateEntitys.Where(p => p.StatusID == true).ToList();
                if(states.Count>0)
                {

                    return (new JsonResult(states), true);
                }
                else
                {
                    return (new JsonResult(""), false);
                }
            }
            catch (Exception Ex)
            {
                return (new JsonResult(""), false);
            }
        }

        public (JsonResult result, bool Succeeded) GetStatebyID(Guid id)
        {
            try
            {
                var states = _context.StateEntitys.Where(p => p.StateID == id);
                if (states != null)
                {

                    return (new JsonResult(states), true);
                }
                else
                {
                    return (new JsonResult("No result found"), false);
                }
            }
            catch (Exception Ex)
            {
                return (new JsonResult("Some server error occured"), false);
            }
        }
        public (JsonResult result, bool Succeeded) DeleteState(Guid id)
        {
            try
            {
                StateEntity states = _context.StateEntitys.Find(id);
                    if(states == null)
                {
                    return (new JsonResult("State Not Found."), true);
                }
                states.StatusID = false;
                _context.SaveChanges();
                return (new JsonResult("State Deleted Successfully."), true);
            }
            catch(Exception ex)
            {
                return (new JsonResult("Some server error occured"), false);
            }
        }
        public (JsonResult result, bool Succeeded) UpdateState(UpdateState state)
        {
            try
            {
                StateEntity states = _context.StateEntitys.FirstOrDefault(p => p.StateID == state.StateID);

                _context.Entry(states).CurrentValues.SetValues(state);

                if (_context.SaveChanges() == 1)
                {
                    return (new JsonResult("State updated successfully."), true);
                }
                else
                {
                    return (new JsonResult("Enter the correct values."), false);
                }
            }
            catch(Exception ex)
            {
                return (new JsonResult("Some server error occured. Please try again!!"), false);
            }
        }

        #endregion

        #region City Operation
        public (JsonResult result, bool Succeeded) InsertCity(City city)
        {
            try
            {
                var citys = _context.CityEntitys.Where(p => p.CityName == city.CityName);

                if (citys == null)
                {
                    var entity = new CityEntity
                    {
                        CityName = city.CityName,
                        StatusID = city.StatusID,
                        CityCode = city.CityCode,
                        PinCode = city.PinCode,
                        StateID = city.StateID,
                    };
                    _context.CityEntitys.Add(entity);
                    if (_context.SaveChanges() == 1)
                    {
                        return (new JsonResult("City added successfully."), true);
                    }
                    else
                    {
                        return (new JsonResult("Enter the correct values."), false);
                    }
                }
                else
                {
                    return (new JsonResult("City Already exist."), false);
                }


            }
            catch (Exception ex)
            {
                return (new JsonResult("Some server error occured. Please try again!!"), false);
            }
        }
        public (JsonResult result, bool Succeeded) GetCity()
        {
            try
            {
                var city = _context.CityEntitys.Where(p => p.StatusID == true).ToList();
                if (city.Count > 0)
                {

                    return (new JsonResult(city), true);
                }
                else
                {
                    return (new JsonResult(""), false);
                }
            }
            catch (Exception Ex)
            {
                return (new JsonResult(""), false);
            }
        }

        public (JsonResult result, bool Succeeded) GetCitybyID(Guid id)
        {
            try
            {
                var city = _context.CityEntitys.Where(p => p.CityID == id);
                if (city != null)
                {

                    return (new JsonResult(city), true);
                }
                else
                {
                    return (new JsonResult("No record found."), false);
                }
            }
            catch (Exception Ex)
            {
                return (new JsonResult("Some server error occured."), false);
            }
        }
        public (JsonResult result, bool Succeeded) DeleteCity(Guid id)
        {
            try
            {
                CityEntity city = _context.CityEntitys.Find(id);
                if (city == null)
                {
                    return (new JsonResult("City Not Found."), true);
                }
                city.StatusID = false;
                _context.SaveChanges();
                return (new JsonResult("City Deleted Successfully."), true);
            }
            catch (Exception ex)
            {
                return (new JsonResult("Some server error occured"), false);
            }
        }

        public (JsonResult result, bool Succeeded) UpdateCity(Updatecity city)
        {
            try
            {
                CityEntity citys = _context.CityEntitys.FirstOrDefault(p => p.CityID == city.CityID);

                _context.Entry(citys).CurrentValues.SetValues(city);

                if (_context.SaveChanges() == 1)
                {
                    return (new JsonResult("City updated successfully."), true);
                }
                else
                {
                    return (new JsonResult("Enter the correct values."), false);
                }
            }
            catch (Exception ex)
            {
                return (new JsonResult("Some server error occured. Please try again!!"), false);
            }
        }
        #endregion

        #region Category
        public (JsonResult result, bool Succeeded) InsertCategory(Categorys category)
        {
            try
            {
                var entity = new CategoryEntity
                {
                    Category = category.Category,
                    StatusID = category.StatusID,
                    
                };
                _context.CategoryEntitys.Add(entity);
                if (_context.SaveChanges() == 1)
                {
                    return (new JsonResult("Category added successfully."), true);
                }
                else
                {
                    return (new JsonResult("Enter the correct values."), false);
                }

            }
            catch (Exception ex)
            {
                return (new JsonResult("Some server error occured. Please try again!!"), false);
            }
        }
        public (JsonResult result, bool Succeeded) GetCategory()
        {
            try
            {
                var Category = _context.CategoryEntitys.Where(p => p.StatusID == true).ToList();
                if (Category.Count > 0)
                {

                    return (new JsonResult(Category), true);
                }
                else
                {
                    return (new JsonResult("No data found"), false);
                }
            }
            catch (Exception Ex)
            {
                return (new JsonResult("Some server error occured. Please try again!!"), false);
            }
        }

        public (JsonResult result, bool Succeeded) GetCategorybyID(Guid id)
        {
            try
            {
                var Category = _context.CategoryEntitys.Where(p => p.CategoryID == id);
                if (Category != null)
                {

                    return (new JsonResult(Category), true);
                }
                else
                {
                    return (new JsonResult("No record found."), false);
                }
            }
            catch (Exception Ex)
            {
                return (new JsonResult("Some server error occured."), false);
            }
        }
        public (JsonResult result, bool Succeeded) DeleteCategory(Guid id)
        {
            try
            {
                CategoryEntity category = _context.CategoryEntitys.Find(id);
                if (category == null)
                {
                    return (new JsonResult("Category Not Found."), true);
                }
              
                category.StatusID=false;
                _context.SaveChanges();
                return (new JsonResult("Category Deleted Successfully."), true);
            }
            catch (Exception ex)
            {
                return (new JsonResult("Some server error occured"), false);
            }
        }

        public (JsonResult result, bool Succeeded) UpdateCategory(UpdateCategory updateCategory)
        {
            try
            {
                CategoryEntity category = _context.CategoryEntitys.FirstOrDefault(p => p.CategoryID == updateCategory.CategoryID);

                _context.Entry(category).CurrentValues.SetValues(updateCategory);

                if (_context.SaveChanges() == 1)
                {
                    return (new JsonResult("Category updated successfully."), true);
                }
                else
                {
                    return (new JsonResult("Enter the correct values."), false);
                }
            }
            catch (Exception ex)
            {
                return (new JsonResult("Some server error occured. Please try again!!"), false);
            }
        }
        #endregion

        #region Blog Operation
        public (JsonResult result, bool Succeeded) InsertBlog(Blog blog)
        {
            try
            {

                string str = blog.RouteName;
                var routename = str.Replace(' ', '-');
                var entity = new BlogEntity
                {
                    MetaTitle = blog.MetaTitle,
                    MetaKeyword = blog.MetaKeyword,
                    MetaDescription = blog.MetaDescription,
                    Author = blog.Author,
                    CategoryID = blog.CategoryID,
                    BlogHeading = blog.BlogHeading,
                    StatusID = blog.StatusID,
                    RouteName = routename
                };
                _context.BlogEntitys.Add(entity);
                if (_context.SaveChanges() == 1)
                {
                    return (new JsonResult("Blog added successfully."), true);
                }
                else
                {
                    return (new JsonResult("Enter the correct values."), false);
                }

            }
            catch (Exception ex)
            {
                return (new JsonResult("Some server error occured. Please try again!!"), false);
            }
        }
        public (JsonResult result, bool Succeeded) GetBlog(string city, string domainName)
        {
            
            try
            {
                //SqlConnection con = new SqlConnection("Data Source=DESKTOP-93VT2SJ;Initial Catalog=Revinfotech04;Integrated Security=true;");
                ////SqlCommand cmd = new SqlCommand("city",con);

                //SqlCommand cmd = new SqlCommand("select cityname from cities where cityname = '" + city + "'", con);

                //con.Open();
                //string name = Convert.ToString(cmd.ExecuteScalar());

                var citys = _context.CityEntitys.Where(p => p.CityName == city).ToList();
                var state = _context.StateEntitys.Where(p => p.StateName == city).ToList();
                if (citys.Count > 0|| state.Count > 0)
                {
                    var blog = _context.BlogEntitys.Where(p => p.StatusID == true).ToList();
                    if (blog.Count > 0)
                    {
                        List<BlogEntity> blogEntities = new List<BlogEntity>();
                        foreach (var blogs in blog)
                        {
                            if (blogs.MetaTitle.IndexOf("#city#") > 0)
                            {
                                blogs.MetaTitle = blogs.MetaTitle.Replace("#city#", city);
                            }
                            if (blogs.MetaKeyword.IndexOf("#city#") > 0)
                            {
                                blogs.MetaKeyword = blogs.MetaKeyword.Replace("#city#", city);
                            }
                            if (blogs.MetaDescription.IndexOf("#city#") > 0)
                            {
                                blogs.MetaDescription = blogs.MetaDescription.Replace("#city#", city);
                            }
                            if (blogs.BlogHeading.IndexOf("#city#") > 0)
                            {
                                blogs.BlogHeading = blogs.BlogHeading.Replace("#city#", city);
                            }
                            if (blogs.RouteName.IndexOf("#city#") > 0)
                            {
                                //blogs.RouteName = blogs.RouteName.Replace("#city#", city);
                                blogs.RouteName = domainName + "/" + city + "/" + blogs.RouteName.Replace("#city#", city);
                            }
                            blogEntities.Add(blogs);
                        }
                        return (new JsonResult(blogEntities), true);
                    }
                    else
                    {
                        return (new JsonResult("No data found"), false);
                    }
                }
                else
                {
                    return (new JsonResult("Enter a correct city name"), false);
                }
            }
            catch (Exception Ex)
            {
                return (new JsonResult("Some server error occured. Please try again!!"), false);
            }
        }

        public (JsonResult result, bool Succeeded) GetBlogbyID(Guid id, string city, string domainName)
        {
            try
            {
                var cname = _context.CityEntitys.Where(p => p.CityName == city).FirstOrDefault();
                var sname = _context.StateEntitys.Where(p => p.StateName == city).FirstOrDefault();
                if(cname != null || sname!=null)
                {   
                    var blog = _context.BlogEntitys.Where(p => p.BlogID == id).FirstOrDefault();
                    
                    if (blog != null)
                    {
                        var desc = _context.BlogDescriptions.Where(p => p.BlogID == id).ToList();
                        var image = _context.BlogImages.Where(p => p.BlogID == id).ToList();

                        if (blog.MetaTitle.IndexOf("#city#") > 0)
                        {
                            blog.MetaTitle = blog.MetaTitle.Replace("#city#", city);
                        }
                        if (blog.MetaKeyword.IndexOf("#city#") > 0)
                        {
                            blog.MetaKeyword = blog.MetaKeyword.Replace("#city#", city);
                        }
                        if (blog.MetaDescription.IndexOf("#city#") > 0)
                        {
                            blog.MetaDescription = blog.MetaDescription.Replace("#city#", city);
                        }
                        if (blog.BlogHeading.IndexOf("#city#") > 0)
                        {
                            blog.BlogHeading = blog.BlogHeading.Replace("#city#", city);
                        }
                        if (blog.RouteName.IndexOf("#city#") > 0)
                        {
                            //blog.RouteName = blog.RouteName.Replace("#city#", city);
                            blog.RouteName = domainName + "/" + city + "/" + blog.RouteName.Replace("#city#", city);
                        }

                        BlogById blogById = new BlogById();
                        blogById.metakeyword = blog.MetaKeyword;
                        blogById.metadescription = blog.MetaDescription;
                        blogById.BlogHeading = blog.BlogHeading;
                        blogById.metatitle = blog.MetaTitle;
                        blogById.Author = blog.Author;
                        blogById.RouteName = blog.RouteName;
                        List<string> bdesc = new List<string>();
                        foreach (var iurl in desc)
                        {
                            bdesc.Add(iurl.Description);
                        }
                        List<string> bimage = new List<string>();
                        foreach (var bimg in image)
                        {
                            bimage.Add(bimg.ImageURL);
                        }
                        blogById.Description = bdesc;
                        blogById.Images = bimage;
                        
                        return (new JsonResult(blogById), true);
                    }
                    else
                    {
                        return (new JsonResult("City not selected correctly"), true);
                    }
                }
                else
                {
                    return (new JsonResult("City not selected correctly."), false);
                }
            }
            catch (Exception Ex)
             {
                return (new JsonResult("Some server error occured."), false);
            }
        }
        public (JsonResult result, bool Succeeded) DeleteBlog(Guid id)
        {
            try
            {
                BlogEntity blog = _context.BlogEntitys.Find(id);
                if (blog == null)
                {
                    return (new JsonResult("Blog Not Found."), true);
                }

                blog.StatusID = false;
                _context.SaveChanges();
                return (new JsonResult("Blog Deleted Successfully."), true);
            }
            catch (Exception ex)
            {
                return (new JsonResult("Some server error occured"), false);
            }
        }

        public (JsonResult result, bool Succeeded) UpdateBlog(UpdateBlog updateBlog)
        {
            try
            {
                BlogEntity blog = _context.BlogEntitys.FirstOrDefault(p => p.CategoryID == updateBlog.CategoryID);

                _context.Entry(blog).CurrentValues.SetValues(updateBlog);

                if (_context.SaveChanges() == 1)
                {
                    return (new JsonResult("Blog updated successfully."), true);
                }
                else
                {
                    return (new JsonResult("Enter the correct values."), false);
                }
            }
            catch (Exception ex)
            {
                return (new JsonResult("Some server error occured. Please try again!!"), false);
            }
        }
        public (JsonResult result, bool Succeeded) GetBlogByCategory(Guid categoryid, string city, string domainName)
        {
            var cityname = _context.CityEntitys.Where(p => p.CityName == city).FirstOrDefault();
            try
            {
                if (cityname != null)
                {
                    
                    var blog = _context.BlogEntitys.Where(p => p.CategoryID == categoryid).ToList();

                    if (blog != null)
                    {
                        BlogById blogById = new BlogById();
                        foreach (var bloglist in blog)
                        {
                        Guid blgid =  bloglist.BlogID;
                        
                            var desc = _context.BlogDescriptions.Where(p => p.BlogID == blgid).ToList();
                            var image = _context.BlogImages.Where(p => p.BlogID == blgid).ToList();

                            if (bloglist.MetaTitle.IndexOf("#city#") > 0)
                            {
                                bloglist.MetaTitle = bloglist.MetaTitle.Replace("#city#", city);
                            }
                            if (bloglist.MetaKeyword.IndexOf("#city#") > 0)
                            {
                                bloglist.MetaKeyword = bloglist.MetaKeyword.Replace("#city#", city);
                            }
                            if (bloglist.MetaDescription.IndexOf("#city#") > 0)
                            {
                                bloglist.MetaDescription = bloglist.MetaDescription.Replace("#city#", city);
                            }
                            if (bloglist.BlogHeading.IndexOf("#city#") > 0)
                            {
                                bloglist.BlogHeading = bloglist.BlogHeading.Replace("#city#", city);
                            }
                            if (bloglist.RouteName.IndexOf("#city#") > 0)
                            {
                                //blog.RouteName = blog.RouteName.Replace("#city#", city);
                                bloglist.RouteName = domainName + "/" + city + "/" + bloglist.RouteName.Replace("#city#", city);
                            }

                            
                            blogById.metakeyword = bloglist.MetaKeyword;
                            blogById.metadescription = bloglist.MetaDescription;
                            blogById.BlogHeading = bloglist.BlogHeading;
                            blogById.metatitle = bloglist.MetaTitle;
                            blogById.Author = bloglist.Author;
                            blogById.RouteName = bloglist.RouteName;
                            List<string> bdesc = new List<string>();
                            foreach (var iurl in desc)
                            {
                                bdesc.Add(iurl.Description);
                            }
                            List<string> bimage = new List<string>();
                            foreach (var bimg in image)
                            {
                                bimage.Add(bimg.ImageURL);
                            }
                            blogById.Description = bdesc;
                            blogById.Images = bimage;

                            
                        }
                        return (new JsonResult(blogById), true);
                    }
                    else
                    {
                        return (new JsonResult("City not selected correctly"), true);
                    }
                }
                else
                {
                    return (new JsonResult("No record found."), false);
                }
            }
            catch (Exception Ex)
            {
                return (new JsonResult("Some server error occured."), false);
            }
        }

        #endregion

        #region Blog Description Operation
        public (JsonResult result, bool Succeeded) InsertBlogDesc(BlogDesc blogdesc)
        {
            try
            {
                var entity = new BlogDescription
                {
                    BlogID = blogdesc.BlogID,
                    Description = blogdesc.Description,
                    StatusID = blogdesc.StatusID
                };
                _context.BlogDescriptions.Add(entity);
                if (_context.SaveChanges() == 1)
                {
                    return (new JsonResult("Blog Description added successfully."), true);
                }
                else
                {
                    return (new JsonResult("Enter the correct values."), false);
                }

            }
            catch (Exception ex)
            {
                return (new JsonResult("Some server error occured. Please try again!!"), false);
            }
        }
        public (JsonResult result, bool Succeeded) GetBlogDesc()
        {
            try
            {
                var blogdesc = _context.BlogDescriptions.Where(p => p.StatusID == true).ToList();
                if (blogdesc.Count > 0)
                {

                    return (new JsonResult(blogdesc), true);
                }
                else
                {
                    return (new JsonResult("No data found"), false);
                }
            }
            catch (Exception Ex)
            {
                return (new JsonResult("Some server error occured. Please try again!!"), false);
            }
        }

        public (JsonResult result, bool Succeeded) GetBlogDescbyID(Guid id)
        {
            try
            {
                var blogdesc = _context.BlogDescriptions.Where(p => p.BlogDescriptionID == id);
                if (blogdesc != null)
                {

                    return (new JsonResult(blogdesc), true);
                }
                else
                {
                    return (new JsonResult("No record found."), false);
                }
            }
            catch (Exception Ex)
            {
                return (new JsonResult("Some server error occured."), false);
            }
        }
        public (JsonResult result, bool Succeeded) DeleteBlogDesc(Guid id)
        {
            try
            {
                BlogDescription blogdesc = _context.BlogDescriptions.Find(id);
                if (blogdesc == null)
                {
                    return (new JsonResult("Blog Description Not Found."), true);
                }

                blogdesc.StatusID = false;
                _context.SaveChanges();
                return (new JsonResult("Blog Description Deleted Successfully."), true);
            }
            catch (Exception ex)
            {
                return (new JsonResult("Some server error occured"), false);
            }
        }

        public (JsonResult result, bool Succeeded) UpdateBlogDesc(UpdateBlogDesc updateBlogDesc)
        {
            try
            {
                BlogDescription blogdesc = _context.BlogDescriptions.FirstOrDefault(p => p.BlogDescriptionID == updateBlogDesc.BlogDescriptionID);

                _context.Entry(blogdesc).CurrentValues.SetValues(updateBlogDesc);

                if (_context.SaveChanges() == 1)
                {
                    return (new JsonResult("Blog Description updated successfully."), true);
                }
                else
                {
                    return (new JsonResult("Enter the correct values."), false);
                }
            }
            catch (Exception ex)
            {
                return (new JsonResult("Some server error occured. Please try again!!"), false);
            }
        }
        #endregion

        #region Blog Image Operation
        public (JsonResult result, bool Succeeded) InsertBlogImage(Image image)
        {
            try
            {
                var entity = new BlogImage
                {
                    BlogID = image.BlogID,
                    ImageURL = image.ImageURL,
                    StatusID = image.StatusID
                };
                _context.BlogImages.Add(entity);
                if (_context.SaveChanges() == 1)
                {
                    return (new JsonResult("Blog Image added successfully."), true);
                }
                else
                {
                    return (new JsonResult("Enter the correct values."), false);
                }

            }
            catch (Exception ex)
            {
                return (new JsonResult("Some server error occured. Please try again!!"), false);
            }
        }
        public (JsonResult result, bool Succeeded) GetBlogImage()
        {
            try
            {
                var blogImg = _context.BlogImages.Where(p => p.StatusID == true).ToList();
                if (blogImg.Count > 0)
                {

                    return (new JsonResult(blogImg), true);
                }
                else
                {
                    return (new JsonResult("No data found"), false);
                }
            }
            catch (Exception Ex)
            {
                return (new JsonResult("Some server error occured. Please try again!!"), false);
            }
        }

        public (JsonResult result, bool Succeeded) GetBlogImagebyID(Guid id)
        {
            try
            {
                var blogImg = _context.BlogImages.Where(p => p.ID == id);
                if (blogImg != null)
                {

                    return (new JsonResult(blogImg), true);
                }
                else
                {
                    return (new JsonResult("No record found."), false);
                }
            }
            catch (Exception Ex)
            {
                return (new JsonResult("Some server error occured."), false);
            }
        }
        public (JsonResult result, bool Succeeded) DeleteBlogImage(Guid id)
        {
            try
            {
                BlogImage blogImg = _context.BlogImages.Find(id);
                if (blogImg == null)
                {
                    return (new JsonResult("Blog Description Not Found."), true);
                }

                blogImg.StatusID = false;
                _context.SaveChanges();
                return (new JsonResult("Blog Description Deleted Successfully."), true);
            }
            catch (Exception ex)
            {
                return (new JsonResult("Some server error occured"), false);
            }
        }

        public (JsonResult result, bool Succeeded) UpdateBlogImage(UpdatelogImage updatelogImage)
        {
            try
            {
                BlogImage blogImg = _context.BlogImages.FirstOrDefault(p => p.ImageURL == updatelogImage.ImageURL);

                _context.Entry(blogImg).CurrentValues.SetValues(updatelogImage);

                if (_context.SaveChanges() == 1)
                {
                    return (new JsonResult("Blog Description updated successfully."), true);
                }
                else
                {
                    return (new JsonResult("Enter the correct values."), false);
                }
            }
            catch (Exception ex)
            {
                return (new JsonResult("Some server error occured. Please try again!!"), false);
            }
        }


        #endregion

        


        //public string GenerateRandomName(int length)
        //{
        //    Random r = new Random();
        //    string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
        //    string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
        //    string Name = "";
        //    Name += consonants[r.Next(consonants.Length)].ToUpper();
        //    Name += vowels[r.Next(vowels.Length)];
        //    int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
        //    while (b < length)
        //    {
        //        Name += consonants[r.Next(consonants.Length)];
        //        b++;
        //        Name += vowels[r.Next(vowels.Length)];
        //        b++;
        //    }
        //    return Name;
        //}

        
    }
}
