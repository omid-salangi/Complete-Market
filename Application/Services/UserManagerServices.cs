using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interface;
using Application.ViewModel;
using Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Application.Services
{
    public class UserManagerServices : IUserManagerServices
    {
        private readonly UserManager<IdentityUserChange> _userManager;

        public UserManagerServices(UserManager<IdentityUserChange> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> AddUserToRole(AddUserToRoleViewModel model)
        {
            var user = await GetUserIdentity(model.UserId);
            if (user == null)
            {
                return IdentityResult.Failed();
            }

            var requestRoles = model.UserRoles.Where(r => r.IsSelected)
                .Select(u => u.RoleName)
                .ToList();
            return await _userManager.AddToRolesAsync(user, requestRoles);
        }

        public async Task<IdentityResult> EditUser(EditUserViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;
            user.UserName = model.UserName;
           return await _userManager.UpdateAsync(user);
        }

        public async Task<IList<IndexUserNameViewModel>> GetAllUsers()
        {
            var models = _userManager.Users.Select(n => new IndexUserNameViewModel()
            {
                UserName = n.UserName,
                Id = n.Id,
                Email = n.Email
            }).ToList();
            return models;
        }

        public async Task<EditUserViewModel> GetUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return new EditUserViewModel()
            {
                UserName = user.UserName,
                Email = user.Email,
                Id = user.Id,
                PhoneNumber = user.PhoneNumber
            };

        }

        public async Task<IdentityUserChange> GetUserIdentity(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task<bool> IsInRole(IdentityUserChange user, string role)
        {
            return await _userManager.IsInRoleAsync(user, role);
        }

    }
}
