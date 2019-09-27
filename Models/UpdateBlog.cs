using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevInfotech.Models
{
    public class UpdateBlog
    {
        public Guid BlogID { get; set; }

        public string MetaTitle { get; set; }

        public string MetaKeyword { get; set; }

        public string MetaDescription { get; set; }
        public string Author { get; set; }
        public Guid CategoryID { get; set; }
        public string BlogHeading { get; set; }
        public bool StatusID { get; set; }
        public string RouteName { get; set; }
    }
}
