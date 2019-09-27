using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RevInfotech.Context;
using RevInfotech.Models;

namespace RevInfotech.Services
{
    public class UserServices : IUserServices
    {
        private UserManager<UserEntity> _usermanager;
        private SignInManager<UserEntity> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly RevinfotechContext _context;
        public UserServices(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager, RevinfotechContext revinfotechContext, IConfiguration configuration)
        {
            _usermanager = userManager;
            _signInManager = signInManager;
            _context = revinfotechContext;
            _configuration = configuration;
        }

        #region //Old code
        //public (JsonResult result, bool Succeeded) CreateUserAsync(UserModel userModel)
        //{
        //    string username = GetRandomUserName(userModel.FullName);
        //    var user = new User
        //    {
        //        AccountNo = userModel.FullName + "-" + DateTime.Now.ToString("yyyyMMddHHmmssfff"),
        //        Sponsor = userModel.Sponsor,
        //        Email = userModel.EmailID,
        //        UserName = username,
        //        FullName = userModel.FullName,
        //        //FullName = form.FirstName + (!String.IsNullOrEmpty(form.LastName) ? " " + form.LastName : ""),
        //        ContactNo = userModel.ContactNo,
        //        Active = false,
        //        CreatedAt = DateTimeOffset.UtcNow,
        //        Country = userModel.Country,
        //        RegistrationDate = DateTime.Now,
        //        ProfileCompleted = true,
        //        AutoPay = true,
        //    };
        //    try
        //    {
        //        var result = _usermanager.CreateAsync(user, userModel.Password).GetAwaiter().GetResult();
        //        if(result.Succeeded)
        //        {
        //            return (new JsonResult("Registration Successfully"), true);
        //        }
        //        return (new JsonResult("Some error occured"), false);
        //    }
        //    catch (Exception ex)
        //    {
        //        return (new JsonResult("Some server error occured. Please try again!!"), false);
        //    }
        //}
        #endregion
        public (JsonResult result, bool Succeeded) SignIn(Credentials Credentials)
        {
            try
            {
                var role = string.Empty;
                UserEntity userDetail;

                
                if (Credentials.UserName.Contains("@"))
                {
                    userDetail = _usermanager.FindByEmailAsync(Credentials.UserName).GetAwaiter().GetResult();
                }
                else
                {

                    var userDetails = _context.Users.Where(s => s.UserName == Credentials.UserName).FirstOrDefault();
                    userDetail = _usermanager.FindByEmailAsync(userDetails.Email).GetAwaiter().GetResult();
                }

                if (userDetail != null)
                {
                    if (userDetail.UserName.Length > 0)
                    {
                        if (userDetail.IsBlocked)
                        {
                            return (new JsonResult("Your account has been blocked ! Please contact your administrator."), false);
                        }

                        var result = _signInManager.PasswordSignInAsync(userDetail.UserName, Credentials.Password, false, false).GetAwaiter().GetResult();
                        

                        if (result.RequiresTwoFactor)
                        {
                            return (new JsonResult(new Dictionary<string, object>
                        {
                            { "G2Ftoken", Encrypt(userDetail.AccountNo) },
                            { "Twofactor", result.RequiresTwoFactor }
                        }), result.RequiresTwoFactor);
                        }

                        if (result.IsLockedOut)
                        {
                            return (new JsonResult("Your account has been Lock ! Please try again after Sometime."), false);
                        }

                        if (result.Succeeded)
                        {
                            var user = _usermanager.FindByNameAsync(userDetail.UserName).GetAwaiter().GetResult();

                            if (user.Active)
                            {
                                if (user.TwoFactorEnabled)
                                {
                                    return (new JsonResult(new Dictionary<string, object>
                                    {
                                            { "G2Ftoken", Encrypt(userDetail.AccountNo) },
                                            { "Twofactor", result.RequiresTwoFactor }
                                    }), result.RequiresTwoFactor);
                                }
                                var Token = GenerateToken(user);
                                
                                return (Token, result.Succeeded);
                            }
                            else
                                return (new JsonResult("Please activate your account"), false);
                        }
                        return (new JsonResult("Authentication failed!! Please check credentials.") { StatusCode = 401 }, result.Succeeded);
                    }
                    return (new JsonResult("Authentication failed!! Please check credentials.") { StatusCode = 401 }, false);
                }
                return (new JsonResult("User doesn't exist.") { StatusCode = 400 }, false);
            }
            catch (Exception Ex)
            {
                
                return (new JsonResult("Authentication failed!! Please check credentials."), false);
            }
        }

        public (JsonResult result, bool Succeeded) CreateUserAsync(UserModel form)
        {
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    String accountNo = null;
                    int Count = _usermanager.Users.Count() + 1;
                    long ticketid = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmssf"));
                    if (!string.IsNullOrEmpty(form.Sponsor))
                    {
                        if (!_usermanager.Users.Where(u => u.UserName == form.Sponsor).Any())
                        {
                            return (new JsonResult("Cannot find the sponsor."), false);
                        }
                    }
                    #region UserCreation
                    if (form.FullName.Contains(" "))
                    {
                        var commands = form.FullName.Split(' ', 2);
                        accountNo = commands[0] + "-" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    }
                    else
                    {
                        accountNo = form.FullName + "-" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    }
                    string username = GetRandomUserName(form.FullName);

                    var entity = new UserEntity
                    {
                        AccountNo = accountNo,
                        Sponsor = form.Sponsor,
                        Email = form.EmailID,
                        UserName = username,
                        FullName = form.FullName,
                        //FullName = form.FirstName + (!String.IsNullOrEmpty(form.LastName) ? " " + form.LastName : ""),
                        ContactNo = form.ContactNo,
                        Active = true,
                        CreatedAt = DateTimeOffset.UtcNow,
                        Country = form.Country,
                        RegistrationDate = DateTime.Now,
                        ProfileCompleted = true,
                        AutoPay = true,
                        

                    };

                    Claim[] claims = new Claim[]
                   {
                    new Claim(ClaimTypes.NameIdentifier, entity.UserName),
                    new Claim(JwtRegisteredClaimNames.Sub, entity.UserName)

                   };

                    var result = _usermanager.CreateAsync(entity, form.Password).GetAwaiter().GetResult();

                    if (!result.Succeeded)
                    {
                        var firstError = result.Errors.FirstOrDefault()?.Description;

                        return (new JsonResult(firstError), result.Succeeded);

                    }
                    else
                    {
                        _usermanager.AddToRoleAsync(entity, "user").Wait();
                        _usermanager.AddClaimsAsync(entity, claims).Wait();
                        _usermanager.UpdateAsync(entity).Wait();
                        _context.SaveChanges();
                    }
                    
                    dbContextTransaction.Commit();
                    return (new JsonResult("User Created Successfully."), result.Succeeded);
                    #endregion
                }


                catch (Exception Ex)
                {
                    dbContextTransaction.Rollback();
                   
                    return (new JsonResult("Some server error occured. Please try again!!"), false);
                }
            }
        }
        private string GetRandomUserName(string Name)
        {
            string name = Regex.Replace(Name, @"\s", "") + new Random().Next(1000, 9999).ToString();
            while (_context.Users.Where(s => s.UserName == name).Count() > 0)
            {
                GetRandomUserName(name);
            }
            return name.ToLower();
        }

        public string Encrypt(string inputText)
        {
            try
            {
                string encryptionkey = _configuration.GetSection("Encryption:Key").Value;
                byte[] keybytes = Encoding.ASCII.GetBytes(encryptionkey.Length.ToString());
                RijndaelManaged rijndaelCipher = new RijndaelManaged();
                byte[] plainText = Encoding.Unicode.GetBytes(inputText);
                PasswordDeriveBytes pwdbytes = new PasswordDeriveBytes(encryptionkey, keybytes);
                using (ICryptoTransform encryptrans = rijndaelCipher.CreateEncryptor(pwdbytes.GetBytes(32), pwdbytes.GetBytes(16)))
                {
                    using (MemoryStream mstrm = new MemoryStream())
                    {
                        using (CryptoStream cryptstm = new CryptoStream(mstrm, encryptrans, CryptoStreamMode.Write))
                        {
                            cryptstm.Write(plainText, 0, plainText.Length);
                            cryptstm.Close();
                            return Convert.ToBase64String(mstrm.ToArray());
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                
                return Ex.Message;
            }
        }

        private JsonResult GenerateToken(UserEntity user)
        {

            var now = DateTime.UtcNow;


            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(now).ToUniversalTime().ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64)
            };
            var secretKey = _configuration.GetSection("TokenAuthentication:SecretKey").Value;
            var issuer = _configuration.GetSection("TokenAuthentication:Issuer").Value;
            var audience = _configuration.GetSection("TokenAuthentication:Audience").Value;
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
            // Create the JWT and write it to a string
            var jwt = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                notBefore: now,
                expires: now.Add(TimeSpan.FromMinutes(120)),
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);



            var response = new JsonResult(new Dictionary<string, object>
            {
                { "access_token" , encodedJwt },
                { "expires_in" , (int) TimeSpan.FromMinutes(200).TotalSeconds },
                {"user_name",user.UserName },
                {"emailId",user.Email },
                {"fullName",user.FullName },
                {"AccountNo",user.AccountNo },
                {"TwoFactor",user.TwoFactorEnabled }
            });

            return response;

        }

        
    }
}
