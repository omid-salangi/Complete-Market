﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
    public class AddRoleViewModel
    {
        [Display(Name = "نام مقام")]
        [Required(ErrorMessage = "نام مقام را وارد کنید.")]
        public string Name { get; set; }

        public string Id { get; set; }
    }
}
