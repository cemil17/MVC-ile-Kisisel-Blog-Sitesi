using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog başlığı boş geçilemez");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Blog içeriği boş geçilemez");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Blog resmi boş geçilemez");

            RuleFor(x => x.BlogTitle).MinimumLength(3).WithMessage("En az 3 karakterlik veri girişi yapın");
            RuleFor(x => x.BlogTitle).MaximumLength(100).WithMessage("En fazla 100 karakterlik veri girişi yapın");
            RuleFor(x => x.Content).MinimumLength(3).WithMessage("En az 3 karakterlik veri girişi yapın");

        }
    }
}
