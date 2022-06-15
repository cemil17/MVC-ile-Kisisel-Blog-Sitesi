using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Bu alan boş geçilemez");


            RuleFor(x => x.Name).MinimumLength(2).WithMessage("En az 2 karakterlik veri girişi yapın");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("En fazla 50 karakterlik veri girişi yapın");

            RuleFor(x => x.Surname).MinimumLength(3).WithMessage("En az 3 karakterlik veri girişi yapın");
            RuleFor(x => x.Surname).MaximumLength(50).WithMessage("En fazla 50 karakterlik veri girişi yapın");

            RuleFor(x => x.Mail).MinimumLength(3).WithMessage("En az 3 karakterlik veri girişi yapın");
            RuleFor(x => x.Mail).MaximumLength(50).WithMessage("En fazla 50 karakterlik veri girişi yapın");
            RuleFor(x => x.Mail).EmailAddress().WithMessage("Geçerli bir mail adresi girin");

            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("En az 3 karakterlik veri girişi yapın");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("En fazla 50 karakterlik veri girişi yapın");


        }
    }
}
