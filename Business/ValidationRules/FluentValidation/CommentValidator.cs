using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
   public class CommentValidator : AbstractValidator<Comment>
    {

        public CommentValidator()
        {
            RuleFor(c=>c.commentText).NotEmpty();
            RuleFor(c => c.commentText).MinimumLength(10);
        }
    }
}
