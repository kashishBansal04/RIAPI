using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RevInfotech.Models
{
    public class UserCodeCardEntity
    {
        [Key, Column(Order = 0)]
        public int CodeId { get; set; }

        [Key, Column(Order = 1)]
        public string AccountNo { get; set; }

        public string Code { get; set; }
    }
}
