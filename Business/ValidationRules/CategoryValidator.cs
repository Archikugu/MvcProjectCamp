﻿using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules {
    public class CategoryValidator : AbstractValidator<Category> {
        public CategoryValidator() {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adını Boş Geçemezsiniz");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapınız");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Lütfen en fazla 20 karakter girişi yapınız");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklamayı Boş Geçemezsiniz");
            RuleFor(x => x.CategoryDescription).MaximumLength(200).WithMessage("Lütfen en fazla 200 karakter girişi yapınız");
        }
    }
}
