using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RevInfotech.Models
{
    public class UpdateBlogDesc
    {
        public Guid BlogDescriptionID { get; set; }
        [Required]
        public Guid BlogID { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool StatusID { get; set; }
    }
}
