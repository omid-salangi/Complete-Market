using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Application.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MVC.Controllers
{
    [Authorize(Roles = "Owner")]
    public class ManageRoleController : Controller
    {
        private readonly IRoleManagerServices _roleManager;

        public ManageRoleController(IRoleManagerServices roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            var roles=await _roleManager.GetAllRoles();
            return View(roles);
        }
        [HttpGet]
        public async Task<IActionResult> AddRole()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Addrole(AddRoleViewModel model)
        {
            //if (string.IsNullOrEmpty(model.Name))
            //{
            //    return NotFound();
            //}
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _roleManager.Addrole(model.Name);
            if (result.Succeeded) return RedirectToAction("Index");

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRole(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }
              await _roleManager.DeleteRole(id);
              return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var role = await _roleManager.GetRole(id);
            if (role == null)
            {
                return NotFound();
            }
            AddRoleViewModel temp = new AddRoleViewModel()
            {
                Name = role.Name,
                Id = role.Id
            };
            return View(temp);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRole(AddRoleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _roleManager.EditRole(model.Id,model.Name);
            
            if (result.Succeeded) return RedirectToAction("Index");

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }
    }
    
}
