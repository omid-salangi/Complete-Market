﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace Application.ViewModel
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(250)]
        [EmailAddress]
        [Display(Name = "ایمیل")] 
        [Remote("IsEmailInUse","Accounts",AdditionalFields = "__RequestVerificationToken", HttpMethod = "POST")]
        public string Email { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(50)]
        [MinLength(8)]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(50)]
        [MinLength(8)]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password",ErrorMessage = "تکرار رمز عبور صحیح نمی باشد.")]
        [Display(Name = "تکرار رمز ورود")]
        public string RePassword { get; set; }

    }
}
