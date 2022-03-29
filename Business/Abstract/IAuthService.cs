using Core6.Entities.Concrete;
using Core6.Results;
using Core6.Utilities.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserLoginDto userForLoginDto);
        IResult UserExists(string nationalityId);
        IResult MailExists(string mail);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
