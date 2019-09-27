using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RevInfotech.Models
{
    public class StateEntity
    {
        [Key]
        public Guid StateID { get; set; }
        public string StateName { get; set; }
        public bool StatusID { get; set; }
        public string StateCode { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public List<CityEntity> Cityentitys { get; set; }
    }
}
