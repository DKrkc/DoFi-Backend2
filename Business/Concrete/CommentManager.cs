using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core6.Results;
using Core6.Utilities.Aspects.Autofac.Validation;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        [ValidationAspect(typeof(CommentValidator))]
        public IResult Add(Comment comment)
        {
            _commentDal.Add(comment);
            return new SuccessResult();
        }

        public IResult Delete(Comment comment)
        {
           _commentDal.Delete(comment);
            return new SuccessResult();
        }

        public IDataResult<List<Comment>> FindByWhoPostedId(int userId)
        {
            return new SuccessDataResult<List<Comment>>(_commentDal.GetAll(x => x.whopostedId == userId));
        }

        public IDataResult<List<CommentDetailsDto>> GetByUserId(int userId)
        {
            var list = _commentDal.GetByUserId(userId);
            var newList = list.OrderByDescending(x => x.date).ToList();

           return new SuccessDataResult<List<CommentDetailsDto>>(newList);
        }

        public IDataResult<Comment> GetCommentById(int commentId)
        {
            return new SuccessDataResult<Comment>(_commentDal.Get(x => x.commentId == commentId));
        }

        public IResult Update(Comment comment)
        {
          _commentDal.UpDate(comment);
            return new SuccessResult();
        }





        private IResult CheckDate(DateTime date)
        {
            if (date < DateTime.Now)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
