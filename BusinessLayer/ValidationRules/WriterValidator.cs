using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x=>x.WriterName).NotEmpty().WithMessage("Yazar Adı Soyadı alanı boş geçilemez");
            RuleFor(x=>x.WriterMail).NotEmpty().WithMessage("Mail adresi boş geçilemez");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre boş geçilemez");            
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen iki karakter giriş yapınız");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Lütfen en fazla elli karakterlik veri girişi yapın");
            RuleFor(x => x.WriterPassword).Must(PasswordContain).WithMessage("Şifreniz en az bir büyük harf,bir küçük harf ve 1 rakamdan oluşmalıdır!");

            RuleFor(x => x).Custom((x, context) =>
            {
                if (x.WriterPassword != x.WriterPassword2)
                {
                    context.AddFailure(nameof(x.WriterPassword), "Girilen şifreler aynı değildir, tekrar kontrol ediniz!");
                }
            });

        }

        private bool PasswordContain(string sifre)
        {
            try
            {
                Regex regex = new Regex(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[0-9])[A-Za-z\d]");
                return regex.IsMatch(sifre);
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
