using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CommentValidator : AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Adınızı boş geçemezsiniz !!!");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Geçerli bir mail adresi girin");
            RuleFor(x => x.CommentText).NotEmpty().WithMessage("Bu alanı boş geçemezsiniz");

            RuleFor(x => x.UserName).MinimumLength(2).WithMessage("En az 2 karakterlik veri giriniz !!!");
            RuleFor(x => x.UserName).MaximumLength(50).WithMessage("En fazla 50 karakterlik veri giriniz !!!");

            RuleFor(x => x.Mail).MinimumLength(5).WithMessage("En az 5 karakterlik veri giriniz !!!");
            RuleFor(x => x.Mail).MaximumLength(50).WithMessage("En fazla 50 karakterlik veri giriniz !!!");
            RuleFor(x => x.Mail).EmailAddress().WithMessage("Geçerli bir mail adresi girin");

            RuleFor(x => x.CommentText).MinimumLength(2).WithMessage("En az 2 karakterlik veri giriniz !!!");
            RuleFor(x => x.CommentText).MaximumLength(250).WithMessage("En fazla 250 karakterlik veri giriniz !!!");
        }
    }
}
