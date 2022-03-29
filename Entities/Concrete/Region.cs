

using Core6.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    [Table("Regions")]
  public  class Region:IEntity
    {
        public int regionId { get; set; }
        public string regionName { get; set; }
        public int cityId { get; set; }
    }
}
