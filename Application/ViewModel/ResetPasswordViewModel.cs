using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
    public class ResetPasswordViewModel
    {
        public string username { get; set; }
        public string token { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(50)]
        [MinLength(8)]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        public string NewPassword { get; set; }
        [Compare("NewPassword",ErrorMessage = "تکرار رمز عبور صحیح نمی باشد.")]
        [DataType(DataType.Password)]
        [Display(Name = "تکرار رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        public string RePassword { get; set; }
       
    }
}
