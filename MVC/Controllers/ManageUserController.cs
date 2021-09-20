using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Application.ViewModel;

namespace MVC.Controllers
{
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
        public async Task<IActionResult> RemoveUserFromRole(AddUserToRoleViewModel model)
        {
            if (model == null)
            {
                return NotFound();
            }
            var user = await _userManager.GetUserIdentity(model.UserId);
            if (user == null)
            {
                return NotFound();
            }
            var requestRoles = model.UserRoles.Where(r => r.IsSelected)
                .Select(u => u.RoleName)
                .ToList();
            var result = await _userManager.AddUserToRole(user, requestRoles);

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
