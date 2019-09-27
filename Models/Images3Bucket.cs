using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RevInfotech.Models
{
    public class Images3Bucket
    {
        [Required]
        public string Imagebase64 { get; set; }
        [Required]
        public string ImageName { get; set; }
    }
}
