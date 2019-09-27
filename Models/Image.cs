using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RevInfotech.Models
{
    public class Image
    {
        public Guid BlogID { get; set; }
        [Required]
        public string ImageURL { get; set; }
        [Required]
        public bool StatusID { get; set; }
    }
}
