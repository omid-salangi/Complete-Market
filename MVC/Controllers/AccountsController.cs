using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

            var model = new LoginModel()
            {
                ReturnUrl  = returnUrl,
                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };

                ViewData["returnUrl"] = returnUrl;  // for return to main page after login and we continue this Procedures in post login
            return View(model);
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

            model.ReturnUrl = returnUrl; // important
            model.ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

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
        [HttpPost]
        public async Task<IActionResult> ExternalLogin(string provider, string returnUrl) // if name of form and input of one input ofthis action are same value of submit button will be pass to that input   this will be happen in post and from a form
        {
            var redirectUrl = Url.Action("ExternalLoginCallBack", "Accounts",
                new { ReturnUrl = returnUrl });

            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);// connect to google
            return new ChallengeResult(provider, properties);
        }
        public async Task<IActionResult> ExternalLoginCallBack(string returnUrl = null, string remoteError = null) // google response will call this action
        {
            returnUrl =
                (returnUrl != null && Url.IsLocalUrl(returnUrl)) ? returnUrl : Url.Content("~/");

            var loginViewModel = new LoginModel()
            {
                ReturnUrl = returnUrl,
                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };

            if (remoteError != null)
            {
                ModelState.AddModelError("", $"Error : {remoteError}");
                return View("Login", loginViewModel);
            }

            var externalLoginInfo = await _signInManager.GetExternalLoginInfoAsync(); // get data from google
            if (externalLoginInfo == null)
            {
                ModelState.AddModelError("ErrorLoadingExternalLoginInfo", $"مشکلی پیش آمد");
                return View("Login", loginViewModel);
            }

            var signInResult = await _signInManager.ExternalLoginSignInAsync(externalLoginInfo.LoginProvider,
                externalLoginInfo.ProviderKey, false, true);

            if (signInResult.Succeeded)
            {
                return Redirect(returnUrl);
            }

            var email = externalLoginInfo.Principal.FindFirstValue(ClaimTypes.Email); // if user is new  this code will be runed.

            if (email != null)
            {
                var user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    var userName = email;//.Split('@')[0]; if we want use before @ in email address instead of username
                    user = new IdentityUserChange()
                    {
                        UserName = (userName.Length <= 10 ? userName : userName.Substring(0, 10)),
                        Email = email,
                        EmailConfirmed = true
                    };

                    await _userManager.CreateAsync(user);
                }

                await _userManager.AddLoginAsync(user, externalLoginInfo);
                await _signInManager.SignInAsync(user, false);

                return Redirect(returnUrl);
            }

            ViewBag.ErrorTitle = "لطفا با بخش پشتیبانی تماس بگیرید";
            ViewBag.ErrorMessage = $"دریافت کرد {externalLoginInfo.LoginProvider} نمیتوان اطلاعاتی از";
            return View();
        }
    }
}
