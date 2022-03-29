using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.Mernis;
using Business.ValidationRules.FluentValidation;
using Core6.Business;
using Core6.Entities.Concrete;

using Core6.Results;
using Core6.Utilities.Aspects.Autofac.Validation;
using Core6.Utilities.Security.Hashing;
using Core6.Utilities.Security.JWT;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {

        IUserDal _userDal;
      

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
          
       

        }

       

        [ValidationAspect(typeof(UserValidator))]
        public IResult AddUser(User user)
        {

           
            _userDal.Add(user);
            return new SuccessResult();
        }

        public IResult ChangeMail(string oldMail,string newMail)
        {
            var userToCheck = FindByMail(oldMail).Data;
            userToCheck.mail = newMail;
            _userDal.UpDate(userToCheck);
            return new SuccessResult(Messages.MailChanged);
        }

        public IResult ChangePassword(string mail,string oldPassword, string newPassword)
        {
          
            byte[] passwordHash, passwordSalt;
            var userToCheck = FindByMail(mail).Data;
            if (!HashingHelper.VerifyPasswordHash(oldPassword, userToCheck.passwordHash, userToCheck.passwordSalt))
            {
                return new ErrorResult(Messages.PasswordError);
            }
            HashingHelper.CreatePasswordHash(newPassword, out passwordHash, out passwordSalt);
            userToCheck.passwordHash = passwordHash;
            userToCheck.passwordSalt = passwordSalt;
            _userDal.UpDate(userToCheck);
            return new SuccessResult(Messages.PasswordChanged);
        }

        public IResult DeleteUser(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult();
        }


        
        public IDataResult<User> FindById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(x=>x.userId == userId));
        }

        public IDataResult<User> FindByMail(string mail)
        {
            return new SuccessDataResult<User>((_userDal.Get(x => x.mail== mail)));
        }

        public IDataResult<User> FindByNationalityId(string nationalityId)
        {
            return new SuccessDataResult<User>(_userDal.Get(x => x.nationalityId == nationalityId));
        }


        //[SecuredOperation("admin")]
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public IResult UpdateUser(User user)
        {
            _userDal.UpDate(user);
            return new SuccessResult();
        }


      

    }
}
