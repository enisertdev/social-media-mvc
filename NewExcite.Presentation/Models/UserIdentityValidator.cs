using Microsoft.AspNetCore.Identity;

namespace NewExcite.Presentation.Models
{
    public class UserIdentityValidator : IdentityErrorDescriber
    {
        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresNonAlphanumeric",
                Description = "Şifre en az 1 sembol içermelidir."
            };
        }
        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresDigit",
                Description = "Şifre en az 1 sayı içermelidir"
            };
        }
        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError() 
            {
                Code = "PasswordRequiresUpper",
                Description = "Şifre en az 1 büyük harf içermelidir."
            };
        }
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError()
            {
                Code = "PasswordTooShort",
                Description = $"Şifre en az {length} karakter olmalıdır."
            };
        }
        public override IdentityError InvalidUserName(string? userName)
        {
            return new IdentityError()
            {
                Code = "InvalidUsername",
                Description = $"Kullanıcı adı({userName}) sadece harfler ve sayılar içerebilir."
            };
        }
        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError()
            {
                Code = "DuplicatedUserName",
                Description = $" {userName} zaten alınmış."
            };
        }
        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError()
            {
                Code = "DuplicateEmail",
                Description = $"Bu e-mail adresi zaten kayıtlı."
            };
        }
    }
}
