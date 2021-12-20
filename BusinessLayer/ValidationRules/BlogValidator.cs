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
            RuleFor(x => x.BlogTitle).MinimumLength(5).WithMessage("Blog başlığı minimum 5 karakter olmalıdır");
            RuleFor(x => x.BlogTitle).MaximumLength(150).WithMessage("Blog başlığı maximum 150 karakter olabilir");

            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog içeriği boş geçilemez");
            RuleFor(x => x.BlogContent).MinimumLength(5).WithMessage("Blog içeriği minimum 5 karakter olmalıdır");
            RuleFor(x => x.BlogContent).MaximumLength(1500).WithMessage("Blog içeriği maximum 1000 karakter olabilir");

        }
    }
}
