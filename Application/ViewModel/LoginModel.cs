using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Application.ViewModel
{
    public class LoginModel
    {
        [Required , Display(Name = "ایمیل")]
        public string username { get; set; }
        [Required,Display(Name = "رمز عبور")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Display(Name = "مرا بخاطر بسپار")]
        public bool rememberme { get; set; }

        public string  ReturnUrl { get; set; } // for google login
        public IList<AuthenticationScheme> ExternalLogins { get; set; }
    }
}
