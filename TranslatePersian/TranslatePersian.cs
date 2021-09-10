using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslatePersian
{
    public class TranslatePersian : IdentityErrorDescriber
    {
        public override IdentityError DuplicateEmail(string email)
            => new IdentityError() // lambda
            {
                Code = nameof(DuplicateEmail),
                Description = $"ایمیل {email}قبلا استفاده شده است."
            };

        public override IdentityError InvalidEmail(string email)
        {
            return new IdentityError()
            {
                Code = nameof(InvalidEmail),
                Description = $"ایمیل وارد شده معتبر نمی باشد."
            };
        }

        public override IdentityError PasswordTooShort(int length)
            => /*return*/new IdentityError()
            {
                Code = nameof(PasswordTooShort),
                Description = "حداقل 8 کاراکتر وارد کنید."
            };

        public override IdentityError PasswordMismatch()
        {
            return new IdentityError()
            {
                Code = nameof(PasswordMismatch),
                Description = "تکرار رمز عبور مطابق نمی باشد."
            };
        }

        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError()
            {
                Code = nameof(DuplicateUserName),
                Description = $"این ایمیل {userName} قبلا استفاده شده است."
            };
        }
    }
}

