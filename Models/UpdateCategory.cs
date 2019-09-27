using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RevInfotech.Models
{
    public class UpdateCategory
    {
        public Guid CategoryID { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public bool StatusID { get; set; }
    }
}
