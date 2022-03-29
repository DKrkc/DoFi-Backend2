

using Core6.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Image :IEntity
    {

        public int imageId { get; set; }
        public int userId { get; set; }
        public string url { get; set; }
        public DateTime date { get; set; }
        public string publicId { get; set; }
        public bool isMain { get; set; }
        public string description { get; set; }
       
    }
}
