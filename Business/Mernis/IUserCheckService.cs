using Core6.Entities.Concrete;
using Core6.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mernis
{
   public interface IUserCheckService
    {
        bool CheckIfRealPerson(UserRegisterDto userRegisterDto);
    }
}
