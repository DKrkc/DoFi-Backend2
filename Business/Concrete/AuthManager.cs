using Business.Abstract;
using Business.Constants;
using Business.Mernis;
using Core6.Business;
using Core6.Entities.Concrete;
using Core6.Results;
using Core6.Utilities.Security.Hashing;
using Core6.Utilities.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {

        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<User> Register(UserRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                mail = userForRegisterDto.mail,
                firstName = userForRegisterDto.firstName,
                lastName = userForRegisterDto.lastName,
                passwordHash = passwordHash,
                passwordSalt = passwordSalt,
                birthOfDate = userForRegisterDto.birthOfDate,  
                nationalityId=userForRegisterDto.nationalityId,
                
            };
            _userService.AddUser(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IDataResult<User> Login(UserLoginDto userForLoginDto)
        {
            var userToCheck = _userService.FindByMail(userForLoginDto.mail).Data;
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.password, userToCheck.passwordHash, userToCheck.passwordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }

        public IResult UserExists(string nationalityId)
        {
            if (_userService.FindByNationalityId(nationalityId).Data != null)
            {
                return new ErrorResult(Messages.AccountExist);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.UserRegistered);
        }

        public IResult MailExists(string mail)
        {
            if (_userService.FindByMail(mail).Data != null)
            {
                return new ErrorResult(Messages.MailExists);
            }
            return new SuccessResult();
        }
    }




}

