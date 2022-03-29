using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core6.Entities.Concrete
{

    [Table("Users")]
    public class User : IEntity
    {

        [Key]
        public int userId { get; set; }
        public string mail { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string nationalityId { get; set; }
        public DateTime birthOfDate { get; set; }
        public byte[] passwordSalt { get; set; }
        public byte[] passwordHash { get; set; }

      //  public string role { get; set; }







    }
}
