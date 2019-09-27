using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RevInfotech.Models
{
    public class Updatecity
    {
        public Guid CityID { get; set; }
        [Required]
        public string CityName { get; set; }
        [Required]
        public bool StatusID { get; set; }
        public string CityCode { get; set; }
        public string PinCode { get; set; }
        [Required]
        public Guid StateID { get; set; }
    }
}
