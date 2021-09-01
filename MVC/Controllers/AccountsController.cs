using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.ViewModel;
using Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace MVC.Controllers
{
    public class AccountsController : Controller
    {
        private readonly UserManager<IdentityUserChange> _userManager;
        public AccountsController(UserManager<IdentityUserChange> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }

            IdentityUserChange newuser = new IdentityUserChange()
            {
                UserName = register.Email.ToLower(),
                Email = register.Email,
                EmailConfirmed = true
            };
          var result =  await  _userManager.CreateAsync(newuser, register.Password);
          if (result.Succeeded)
          {
              RedirectToAction("SuccessRegister","Accounts");
          }

          foreach (var error in result.Errors)
          {
              ModelState.AddModelError("",error.Description);
          }

          return View(register);
        }

        public async Task<IActionResult> SuccessRegister()
        {
            return View();
        }
    }
}
