using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
