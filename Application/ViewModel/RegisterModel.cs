using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(250)]
        [EmailAddress]
        [Display(Name ="ایمیل")]
        public string Email { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        [Display(Name = "تکرار رمز ورود")]
        public string RePassword { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "شماره تلفن")]
        public string phonenumber { get; set; }

    }
}
