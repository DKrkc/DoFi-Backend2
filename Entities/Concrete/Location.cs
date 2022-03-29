


using Core6.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    [Table("Locations")]
   public class Location: IEntity
    {
        public int locationId { get; set; }
      
        public int cityId { get; set; }
        public int regionId { get; set; }
    }
}
