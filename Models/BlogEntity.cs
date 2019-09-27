using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RevInfotech.Models
{
    public class BlogEntity
    {
        [Key]
        public Guid BlogID { get; set; }
        
        public string MetaTitle { get; set; }
        
        public string MetaKeyword { get; set; }
        
        public string MetaDescription { get; set; }
        public string Author { get; set; }
        public Guid CategoryID { get; set; }
        public string BlogHeading { get; set; }
        public bool StatusID { get; set; }
        public string RouteName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public CategoryEntity CategoryEntitys { get; set; }
        public List<BlogDescription> BlogDescriptions { get; set; }
        public List<BlogImage> BlogImages { get; set; }
    }
}
