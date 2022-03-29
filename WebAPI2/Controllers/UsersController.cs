using Business.Abstract;
using Core6.Entities.Concrete;

using Entities.Concrete;
using Entities.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;
      
        public UsersController(IUserService userService)
        {
            _userService = userService;
          
        }

        [HttpGet("getall")]
  
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("getByUserid")]
        public IActionResult GetByUserId(int userId)
        {
            var result = _userService.FindById(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("add")]
        public IActionResult Add(User user)
        {
            var result = _userService.AddUser(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


     

        [HttpDelete("delete")]
        public IActionResult Delete(int userId)
        {
            User user = _userService.FindById(userId).Data;
            var result = _userService.DeleteUser(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("upDatePassword")]
        public IActionResult ChangeUserPassword(ChangePasswordDto changePasswordDto)
        {
            var result = _userService.ChangePassword(changePasswordDto.mail, changePasswordDto.oldPassword, changePasswordDto.newPAssword);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpPost("upDateMail")]
        public IActionResult ChangeMail(ChangeMailDto changeMailDto)
        {
            var result = _userService.ChangeMail(changeMailDto.oldMail,changeMailDto.newMail);
            
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }



    }
}
