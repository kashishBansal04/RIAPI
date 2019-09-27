using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevInfotech.Models
{
    public class BlogById
    {
        public string metatitle{ get; set; }
        public string metakeyword { get; set; }
        public string metadescription { get; set; }
        public string BlogHeading { get; set; }
        public string Author { get; set; }
        public string RouteName { get; set; }
        public List<string> Description { get; set; }
        public List<string> Images { get; set; }
    }
}
