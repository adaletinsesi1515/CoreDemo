using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator <Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adını boş geçemezsiniz");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategori açıklamasını boş geçemezsiniz");
            RuleFor(x => x.CategoryName).MinimumLength(5).WithMessage("Kategori adı minimum 5 karakter olmalıdır");
            RuleFor(x => x.CategoryName).MaximumLength(50).WithMessage("Kategori adı maximum 50 karakter olmalıdır");
            RuleFor(x => x.CategoryDescription).MinimumLength(10).WithMessage("Kategori açıklamasını minimum 10 karakter olmalıdır");
            RuleFor(x => x.CategoryDescription).MaximumLength(500).WithMessage("Kategori açıklamasını maximum 500 karakter olmalıdır");
        }
    }
}
