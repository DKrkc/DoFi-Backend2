using Business.Constants;
using Core6.Entities.Concrete;
using Core6.Results;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
           

            RuleFor(p => p.birthOfDate).NotEmpty();
            RuleFor(p => p.mail).NotEmpty();
            RuleFor(p => p.nationalityId).NotEmpty();
            RuleFor(p => p.lastName).NotEmpty();
            RuleFor(p => p.firstName).NotEmpty();
           RuleFor(p => p.nationalityId).Length(11);
        




            //RuleFor(p => p.firstName).Must(StartWith);

        }

        //private bool StartWith(string arg)
        //{
        //    //buraya knedi methodunu da olusturabiliyorsun.
        //    return arg.StartsWith("a");
        //}

      
    }
}
