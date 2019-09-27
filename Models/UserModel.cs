using Microsoft.AspNetCore.DataProtection;
using RevInfotech.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RevInfotech.Models
{
    public class UserModel
    {
        [Required]
        [Display(Name = "emailID", Description = "Email")]
        [EmailAddress]
        public string EmailID { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(20)]
        [Display(Name = "password", Description = "Password")]
        [Secret]
        public string Password { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(20)]
        [Display(Name = "confirmPassword", Description = "Confirm password")]
        [Secret]
        public string ConfirmPassword { get; set; }


        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        [Display(Name = "fullname", Description = "Full Name")]
        public string FullName { get; set; }

       
        [Display(Name = "userName", Description = "User Name")]
        public string UserName { get; set; }

        [MinLength(1)]
        [MaxLength(100)]
        [Display(Name = "country", Description = "Country")]
        public string Country { get; set; }

       
        public string ContactNo { get; set; }

        [Display(Name = "sponsor", Description = "Sponsor")]
        public string Sponsor { get; set; }

        [Display(Name = "location", Description = "Location")]
        public string Location { get; set; }

        [Display(Name = "macAddress", Description = "MacAddress")]
        public string MacAddress { get; set; }

        [Display(Name = "ipAddress", Description = "IpAddress")]
        public string IpAddress { get; set; }

        [Display(Name = "browser", Description = "Browser")]
        public string Browser { get; set; }

        [Display(Name = "userAgent", Description = "UserAgent")]
        public string UserAgent { get; set; }

    }
}
