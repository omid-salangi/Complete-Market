using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
    public class EditUserViewModel
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "نام کاربری را وارد کنید.")]
        public string UserName { get; set; }
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "ایمیل را وارد کنید.")]
        public string Email { get; set; }
        [Display(Name = " شماره تلفن همراه")]
        [Required(ErrorMessage = "شماره تلفن همراه را وارد کنید.")]
        public string  PhoneNumber { get; set; }

        public string Id { get; set; }
    }
}
