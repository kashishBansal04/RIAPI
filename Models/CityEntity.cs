using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RevInfotech.Models
{
    public class CityEntity
    {
        [Key]
        public Guid CityID { get; set; }
        public string CityName { get; set; }
        public bool StatusID { get; set; }
        public string CityCode { get; set; }
        public string PinCode { get; set; }
        public Guid StateID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public StateEntity stateEntitys { get; set; }
    }
}
