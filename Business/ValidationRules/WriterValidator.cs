using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules {
    public class WriterValidator : AbstractValidator<Writer> {
        public WriterValidator() {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adını Boş Geçemezsiniz");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazar Adını Boş Geçemezsiniz");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Yazar Başlığını Boş Geçemezsiniz");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapınız");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter girişi yapınız");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkında Boş Geçemezsiniz");
            RuleFor(x => x.WriterAbout).MaximumLength(200).WithMessage("Lütfen en fazla 100 karakter girişi yapınız");
            RuleFor(x => x.WriterAbout).Must(x => x != null && x.ToUpper().Contains("A")).WithMessage("Hakkında kısmında en az bir 'a' harfi içermelidir.");
        }
    }
}
