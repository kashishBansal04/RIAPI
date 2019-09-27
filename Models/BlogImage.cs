using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RevInfotech.Models
{
    public class BlogImage
    {
        [Key]
        public Guid ID { get; set; }
        public Guid  BlogID { get; set; }
        public string ImageURL { get; set; }
        public bool StatusID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public BlogEntity BlogEntitys { get; set; }
    }
}
