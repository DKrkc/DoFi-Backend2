using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core6.Entities.Concrete
{
    public class UserLoginDto : IDto
    {

        public string mail { get; set; }

        public string password { get; set; }
    }
}
