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
        private readonly SignInManager<IdentityUserChange> _signInManager;
        public AccountsController(UserManager<IdentityUserChange> userManager , SignInManager<IdentityUserChange> signInManager)
        {
            _signInManager = signInManager;
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
           return RedirectToAction("SuccessRegister");
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
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

          var res= await _signInManager.PasswordSignInAsync(model.username, model.password, model.rememberme, true);

          if (res.Succeeded)
          {
              return RedirectToAction("index", "Home");
          }

          if (res.IsLockedOut)
          {
              ViewData["errormessage"] =
                  "شما بیشتر از 5 بار رمز را اشتباه وارد کردید و اکانت شما قفل شده است  پنج دقیقه دگیر تلاش کنید.";
              return View(model);
          }
          ModelState.AddModelError("","نام کاربری یا رمز عبور اشتباست.");
          return View();
        }
    }
}
