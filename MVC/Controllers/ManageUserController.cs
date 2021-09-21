using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.Interface;
using Application.Services;
using Application.ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace MVC.Controllers
{
    //[Authorize(Roles = "Admin,Owner")]
    public class ManageUserController : Controller
    {
        private readonly IUserManagerServices _userManager;
        private readonly IRoleManagerServices _roleManager;

        public ManageUserController(IUserManagerServices userManager, IRoleManagerServices roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        [HttpGet]
        [Authorize(Policy = "ProductListPolicy")]
        public async Task<IActionResult> Index()
        {
            IList<IndexUserNameViewModel> model =await _userManager.GetAllUsers();
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var user = await _userManager.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
           var res= await _userManager.EditUser(model);
           if (res.Succeeded)
           {
               return RedirectToAction("Index");
           }
           else
           {
               foreach (var error in res.Errors)
               {
                   ModelState.AddModelError("", error.Description);
               }

               return View(model);
           }

        }
        [HttpGet]
        public async Task<IActionResult> AddUserToRole(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var user = await _userManager.GetUserIdentity(id);
            if (user == null)
            {
                return NotFound();
            }
            var roles = await _roleManager.GetAllRoles();
            var model = new AddUserToRoleViewModel() { UserId = id };

            foreach (var role in roles)
            {
                if (!await _userManager.IsInRole(user, role.Name))
                {
                    model.UserRoles.Add(new UserRolesViewModel()
                    {
                        RoleName = role.Name
                    });
                }
            }

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUserToRole(AddUserToRoleViewModel model)
        {
            if (model == null) 
            {
               return NotFound();
            }
            
            var result = await _userManager.AddUserToRole(model);

            if (result.Succeeded)
            {
                return RedirectToAction("index");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> RemoveUserFromRole(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

           var model=await _userManager.GetRemoveUserFromRole(id);
           return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveUserFromRole(AddUserToRoleViewModel model)
        {
            if (model == null)
            {
                return NotFound();
            }
           var result = await _userManager.RemoveUserFromRole(model);

            if (result.Succeeded) return RedirectToAction("index");

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

           var res= await _userManager.DeleteUser(id);
           return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> AddUserToClaim(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var res = await _userManager.GetAddUserToClaim(id);
            if (res.UserId==null)
            {
                return NotFound();
            }
            return View(res);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUserToClaim(AddOrRemoveClaimViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var res = await _userManager.PostAddUserToClaim(model);
            if (res.Succeeded)
            {
                return RedirectToAction("Index");
            }

            foreach (var r in res.Errors)
            {
                ModelState.AddModelError("",r.Description);
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> RemoveUserFromClaim(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var model = await _userManager.GetRemoveUserFromClaim(id);
            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveUserFromClaim(AddOrRemoveClaimViewModel model)
        {
            if (model == null)
            {
                return NotFound();
            }

            var result = await _userManager.PostRemoveUserFromclaim(model);

            if (result.Succeeded)
            {
                return RedirectToAction("index");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }
    }
}
