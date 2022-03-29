
using Core6.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{

    [Table("Employers")]
    public class Employer : Core6.Entities.Concrete.User
    {
    }
}
