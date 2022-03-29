using Core6.Results;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface ICommentService
    {
        IResult Add(Comment comment);

        IResult Update(Comment comment);
        IResult Delete(Comment comment);
        IDataResult<List<Comment>> FindByWhoPostedId(int userId);

        IDataResult<List<CommentDetailsDto>> GetByUserId(int userId);
        IDataResult<Comment> GetCommentById(int commentId);
       
    }
}
