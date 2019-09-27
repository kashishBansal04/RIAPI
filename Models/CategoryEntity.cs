using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RevInfotech.Models
{
    public class CategoryEntity
    {
        [Key]
        public Guid CategoryID { get; set; }
        
        public string Category { get; set; }
        
        public bool StatusID { get; set; }
        
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public List<BlogEntity> BlogEntitys { get; set; }
    }
}
