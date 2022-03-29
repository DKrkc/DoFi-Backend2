using Core6.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core6.Utilities.Security.JWT
{
    public  interface ITokenHelper
    {

        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
