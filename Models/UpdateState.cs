using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RevInfotech.Models
{
    public class UpdateState
    {
        public Guid StateID { get; set; }
        [Required]
        public string StateName { get; set; }
        [Required]
        public bool StatusID { get; set; }
        public string StateCode { get; set; }
    }
}
