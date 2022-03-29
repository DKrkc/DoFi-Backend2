using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
  public class ChangePasswordDto
    {
        public string mail { get; set; }
        public string oldPassword { get; set; }
        public string newPAssword { get; set; }
    }
}
