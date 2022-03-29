using Core6.Utilities.Mail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailsController : ControllerBase
    {
        IMailService _mail;
        public MailsController(IMailService mail)
        {
            _mail = mail;

        }

        [HttpPost("send")]
        public ActionResult SendMail(EmailMessage emailMessage)
        {
            _mail.Send(emailMessage);
            
           return Ok("Mail gonderildi");
            


        }
    }
}
