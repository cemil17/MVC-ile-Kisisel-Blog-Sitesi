using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.AuthorAbout).NotEmpty().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.ShortAbout).NotEmpty().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.AuthorTitle).NotEmpty().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Bu alan boş geçilemez");

            RuleFor(x => x.Name).MinimumLength(2).WithMessage("En az 2 karakterlik veri girişi yapın");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("En fazla 50 karakterlik veri girişi yapın");

            RuleFor(x => x.Mail).MinimumLength(5).WithMessage("En az 5 karakterlik veri girişi yapın");
            RuleFor(x => x.Mail).MaximumLength(50).WithMessage("En fazla 50 karakterlik veri girişi yapın");

            RuleFor(x => x.AuthorAbout).MinimumLength(2).WithMessage("En az 2 karakterlik veri girişi yapın");
            RuleFor(x => x.AuthorAbout).MaximumLength(500).WithMessage("En fazla 500 karakterlik veri girişi yapın");

            RuleFor(x => x.ShortAbout).MinimumLength(2).WithMessage("En az 2 karakterlik veri girişi yapın");
            RuleFor(x => x.ShortAbout).MaximumLength(100).WithMessage("En fazla 100 karakterlik veri girişi yapın");

            RuleFor(x => x.AuthorTitle).MinimumLength(2).WithMessage("En az 2 karakterlik veri girişi yapın");
            RuleFor(x => x.AuthorTitle).MaximumLength(50).WithMessage("En fazla 50 karakterlik veri girişi yapın"); 
            
            RuleFor(x => x.Password).MaximumLength(20).WithMessage("En fazla 20 karakterlik veri girişi yapın");

            RuleFor(x => x.ShortAbout).MaximumLength(100).WithMessage("En fazla 100 karakterlik veri girişi yapın");
            


        }
    }
}
