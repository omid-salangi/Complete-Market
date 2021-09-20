using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interface;
using Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Application.Services
{
   public class RoleManagerServices:IRoleManagerServices
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleManagerServices(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<IdentityResult> Addrole(string name)
        {
            var role = new IdentityRole(name);
            return  await _roleManager.CreateAsync(role);
            
        }

        public async Task DeleteRole(string id)
        {
           var role= await _roleManager.FindByIdAsync(id);
           if (role == null) return;
           await _roleManager.DeleteAsync(role);
        }

        public async Task<IdentityRole> GetRole(string id)
        {

             return await _roleManager.FindByIdAsync(id);

        }

        public async Task<IList<IdentityRole>> GetAllRoles()
        {
            return _roleManager.Roles.ToList();
        }

        public async Task<IdentityResult> EditRole(string id, string name)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                role.Name = name; 
                return await _roleManager.UpdateAsync(role);
            }

            return new IdentityResult();
        }

       
    }
}
