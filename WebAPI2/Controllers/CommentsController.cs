using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {


        ICommentService _commentservice;

        public CommentsController(ICommentService commentservice)
        {
            _commentservice = commentservice;
        }




        [HttpPost("add")]
        public IActionResult Add(Comment comment)
        {
            var comments = _commentservice.FindByWhoPostedId(comment.whopostedId).Data;
            if (comments != null)
            {
                foreach (var item in comments)
                {
                    if (item.whotakenId == comment.whotakenId)
                    {
                        return BadRequest("Sadece bir kez yorum yapma hakkiniz var.Dilerseniz onceki yorumunuzu guncelleyebilirsiniz.");
                    }
                }
            }

            var result = _commentservice.Add(comment);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpPost("update")]
        public IActionResult Update(Comment comment)
        {
           
          var result = _commentservice.Update(comment);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var deletedComment = _commentservice.GetCommentById(id).Data;
            if (deletedComment == null)
            {
                return BadRequest("Yorum zaten silindi");
            }
            var result = _commentservice.Delete(deletedComment);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getCommentDetailsByUserId")]
        public IActionResult GetByUserId(int userId)
        {
            var result = _commentservice.GetByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getCommentById")]
        public IActionResult GetCommentById(int id)
        {
            var result = _commentservice.GetCommentById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
