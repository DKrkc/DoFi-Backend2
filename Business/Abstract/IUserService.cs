
using Core6.Entities.Concrete;
using Core6.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IResult AddUser(User user);
        IResult UpdateUser(User user);
        IResult ChangePassword(string mail,string oldPassword, string newPassword);
        IResult ChangeMail(string oldMail,string newMail);
        IDataResult<User> FindById(int userId);

        IDataResult<User> FindByMail(string mail);
        IDataResult<User> FindByNationalityId(string nationalityId);
        IResult DeleteUser(User user);

        List<OperationClaim> GetClaims(User user);

    




    }
}
