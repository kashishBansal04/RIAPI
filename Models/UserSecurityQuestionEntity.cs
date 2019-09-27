using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RevInfotech.Models
{
    public class UserSecurityQuestionEntity
    {
        [Key, Column(Order = 0)]
        public int QuestionId { get; set; }
        [Key, Column(Order = 1)]
        public string AccountId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
