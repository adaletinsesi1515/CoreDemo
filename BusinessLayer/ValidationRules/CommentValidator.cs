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
            RuleFor(x => x.CommentUserName).NotEmpty().WithMessage("Yorumcu Adı alanı boş geçilemez");
            RuleFor(x => x.CommentTitle).NotEmpty().WithMessage("Yorum başlığı boş geçilemez");
            RuleFor(x => x.CommentTitle).MinimumLength(5).WithMessage("Yorum başlığı en az 5 karakter olmalıdır");
            RuleFor(x => x.CommentContent).MinimumLength(5).WithMessage("Lütfen yoruma en az 5 karakter giriş yapınız");
            RuleFor(x => x.CommentContent).MaximumLength(50).WithMessage("Lütfen en fazla elli karakterlik veri girişi yapın");

        }

    }
}
