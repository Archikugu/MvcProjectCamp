using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules {
    public class MessageValidator:AbstractValidator<Message> {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı Adresi Boş Geçilemez");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konuyu Boş Geçilemez").MaximumLength(50).WithMessage("Maksimum 100 karakter giriniz"); ;
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesajı Boş Geçilemez").MaximumLength(50).WithMessage("Maksimum 100 karakter giriniz");
        }
    }
}
