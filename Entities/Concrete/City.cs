
using Core6.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    [Table("Cities")]
  public class City: IEntity
    {
        public int cityId { get; set; }
        public string cityName { get; set; }
    }
}
