using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Application.ViewModel;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Newtonsoft;


namespace MVC.Controllers
{
    public class AccountsController : Controller
    {
        private readonly UserManager<IdentityUserChange> _userManager;
        private readonly SignInManager<IdentityUserChange> _signInManager;
        private readonly IMessageSender _messagesender;
        public AccountsController(UserManager<IdentityUserChange> userManager , SignInManager<IdentityUserChange> signInManager,
            IMessageSender messageSender)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _messagesender = messageSender;
        }
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("index","Home");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }

            
            IdentityUserChange newuser = new IdentityUserChange()
            {
                UserName = register.Email.ToLower(),
                Email = register.Email
            };
          var result =  await  _userManager.CreateAsync(newuser, register.Password);
          if (result.Succeeded)
          {
              var emailConfirmationToken =
                  await _userManager.GenerateEmailConfirmationTokenAsync(newuser);
              var emailMessage =
                  Url.Action("ConfirmEmail", "Accounts",
                      new { username = newuser.UserName, token = emailConfirmationToken },
                      Request.Scheme);
              await _messagesender.SendEmailAsync(register.Email, "Email confirmation", emailMessage);

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
        public async Task<IActionResult> Login(string returnUrl=null)
        { if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("index","Home");
            }

            ViewData["returnUrl"] = returnUrl;  // for return to main page after login and we continue this Procedures in post login
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model,string returnUrl= null)
        {
            ViewData["returnUrl"] = returnUrl; ///we set it again because if page refreshes return url will be deleted
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("index", "Home");
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }

          var res= await _signInManager.PasswordSignInAsync(model.username, model.password, model.rememberme, true);

          if (res.Succeeded)
          {
              if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl) /* for security */ )
              {
                  return Redirect(returnUrl);
                  
              }
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
        [HttpPost]
        [ValidateAntiForgeryToken] // check for logout from our site
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index", "Home");
        } 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            IdentityUserChange user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json("ایمیل مورد نظر موجود می باشد.");
            }
        }
        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userName,string token)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(token))
                return NotFound();
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null) return NotFound();
            var result = await _userManager.ConfirmEmailAsync(user, token);

            return Content(result.Succeeded ? "Email Confirmed" : "Email Not Confirmed");
        }
    }
}
