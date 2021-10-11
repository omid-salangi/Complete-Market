using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Application.Interface;
using Application.ViewModel;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class UserManagerServices : IUserManagerServices
    {
        private readonly UserManager<IdentityUserChange> _userManager;
        private readonly IRoleManagerServices _roleManager;

        public UserManagerServices(UserManager<IdentityUserChange> userManager,IRoleManagerServices roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
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
                Email = n.Email,
                PhoneNumber = n.PhoneNumber
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

        public async Task<AddUserToRoleViewModel> GetRemoveUserFromRole(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            var roles = await _roleManager.GetAllRoles();
            var model = new AddUserToRoleViewModel() { UserId = id };

            foreach (var role in roles)
            {
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    model.UserRoles.Add(new UserRolesViewModel()
                    {
                        RoleName = role.Name
                    });
                }
            }

            return model;
        }

        public async Task<IdentityResult> RemoveUserFromRole(AddUserToRoleViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
            {
                return IdentityResult.Failed();
            }

            var requestRoles = model.UserRoles.Where(r => r.IsSelected)
                .Select(u => u.RoleName)
                .ToList();
            return await _userManager.RemoveFromRolesAsync(user, requestRoles);
        }

        public async Task<IdentityResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user==null)
            {
                return IdentityResult.Failed();
            }

            return await _userManager.DeleteAsync(user);

        }

        public async Task<AddOrRemoveClaimViewModel> GetAddUserToClaim(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return new AddOrRemoveClaimViewModel()
                {
                    UserId = null
                };
            }
            var allClaim = ClaimStore.AllClaims;
            var userClaims = await _userManager.GetClaimsAsync(user);
            var validClaims =
                allClaim.Where(c => userClaims.All(x => x.Type != c.Type)) // it will return claims that arent selected
                    .Select(c => new ClaimViewModel(c.Type)).ToList();

            return new AddOrRemoveClaimViewModel(id, validClaims);

        }
        
        public async Task<IdentityResult> PostAddUserToClaim(AddOrRemoveClaimViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
            {
                return IdentityResult.Failed();
            }

            var requestClaims = model.UserClaim.Where(r => r.IsSelected)
                .Select(u => new Claim(u.ClaimType, true.ToString())).ToList();
            return await _userManager.AddClaimsAsync(user, requestClaims);


        }

        public async Task<AddOrRemoveClaimViewModel> GetRemoveUserFromClaim(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return new AddOrRemoveClaimViewModel()
                {
                    UserId = null
                };
            }

            var userClaims = await _userManager.GetClaimsAsync(user);
            var validClaims =
                userClaims.Select(c => new ClaimViewModel(c.Type)).ToList();

            return new AddOrRemoveClaimViewModel(id, validClaims);
        }

        public async Task<IdentityResult> PostRemoveUserFromclaim(AddOrRemoveClaimViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
            {
                return IdentityResult.Failed();
            }
            var requestClaims =
                model.UserClaim.Where(r => r.IsSelected)
                    .Select(u => new Claim(u.ClaimType, true.ToString())).ToList();
            return await _userManager.RemoveClaimsAsync(user, requestClaims);
        }

        public async Task<string> GetUserIdByUserName(string username)
        {
            return  await   _userManager.Users.Where(n => n.UserName == username).Select(n => n.Id).FirstOrDefaultAsync();
        }
    }
}
