using FluentValidation;
using NewExcite.Dto.Dtos.AppUserDtos;
using NewExcite.Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewExcite.Business.ValidationRules.AppUserValidationRules
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Ad alanı boş geçilemez");
            RuleFor(x => x.UserName).MaximumLength(25).WithMessage("Ad 25 karakterden fazla olamaz.");
            RuleFor(x => x.Email).EmailAddress().Matches(@"^[^@\s]+@[^@\s]+\.[cC][oO][mM]$").WithMessage("Email adresi geçersiz.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanı boş geçilemez.");
            RuleFor(x => x.Password).MinimumLength(6).WithMessage("Şifre 6 karakterden az olamaz.");
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Şifreler uyuşmuyor.");


        }
    }
}
