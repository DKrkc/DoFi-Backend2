using Core6.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
   public class AppliedAd:IEntity
    {

        public int id { get; set; }
        public int adId { get; set; }
        public int jobSeekerId { get; set; }

    }
}
