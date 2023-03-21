﻿using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules {
    public class ContactValidator : AbstractValidator<Contact> {
        public ContactValidator() {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail Adresi Boş Geçilemez");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Adı Boş Geçilemez");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("En az 3 karakter giriniz");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("En fazla 50 karakter giriniz");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adı Boş Geçilemez");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("En az 3 karakter giriniz");
        }
    }
}
