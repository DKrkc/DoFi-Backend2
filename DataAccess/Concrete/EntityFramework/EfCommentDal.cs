using Core6.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCommentDal : EfEntityRepositoryBase<Comment, DogWalkerContext>, ICommentDal
    {
        public List<CommentDetailsDto> GetByUserId(int userId)
        {
            using (DogWalkerContext context= new DogWalkerContext())
            {
                var result = from c in context.Comments
                            join u in context.Users
                            on c.whopostedId equals u.userId
        
                             where c.whotakenId == userId
                        

                             select new CommentDetailsDto
                             {
                                 id=c.commentId,
                                 isReported=c.isReported,
                                 whopostedId=u.userId,
                                 username = u.firstName+" "+u.lastName,
                                 commentText = c.commentText,
                                 date = c.date,
                             };
                return result.ToList();
            }
        }

       
    }
}
