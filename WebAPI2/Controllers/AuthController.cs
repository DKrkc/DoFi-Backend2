using Business.Abstract;
using Business.Constants;
using Business.Mernis;
using Core6.Entities.Concrete;
using Core6.Utilities.Security.JWT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WebAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;
        private IUserCheckService _userCheckService;

        public AuthController(IAuthService authService,IUserCheckService usercheckService)
        {
            _authService = authService;
            _userCheckService=usercheckService;
        }

        [HttpPost("login")]
        public ActionResult Login(UserLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("register")]
        public ActionResult Register(UserRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.nationalityId);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }
            var mailExists=_authService.MailExists(userForRegisterDto.mail);
            if (!userExists.Success)
            {
                return BadRequest(mailExists.Message);
            }
            //var userCheck = _userCheckService.CheckIfRealPerson(userForRegisterDto);
            //if (!userCheck)
            //{
            //    return BadRequest(Messages.WrongInfos);
            //}
            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.password);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

    }
}
