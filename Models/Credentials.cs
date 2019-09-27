using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RevInfotech.Models
{
    public class Credentials
    {
        [Required]
        //[EmailAddress]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Required]
        //[StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public string MacAddress { get; set; }
        public string IpAddress { get; set; }
        public string Browser { get; set; }
        public bool Active { get; set; }
        public string UserAgent { get; set; }
        public string Location { get; set; }
    }
}
