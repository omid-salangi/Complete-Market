using System.Collections.Generic;
using System.Threading.Tasks;
using Application.ViewModel;
using Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Application.Interface
{
    public interface IUserManagerServices
    {
        Task<IList<IndexUserNameViewModel>> GetAllUsers();
        Task<EditUserViewModel> GetUser(string id);
        Task<IdentityResult> EditUser(EditUserViewModel model);
        Task<IdentityResult> AddUserToRole(AddUserToRoleViewModel model);
        Task<bool> IsInRole(IdentityUserChange user, string role);
        Task<IdentityUserChange> GetUserIdentity(string id);
        Task<AddUserToRoleViewModel> GetRemoveUserFromRole(string id);
        Task<IdentityResult> RemoveUserFromRole(AddUserToRoleViewModel model);
        Task<IdentityResult> DeleteUser(string id);
        Task<AddOrRemoveClaimViewModel> GetAddUserToClaim(string id);
        Task<IdentityResult> PostAddUserToClaim(AddOrRemoveClaimViewModel model);
        Task<AddOrRemoveClaimViewModel> GetRemoveUserFromClaim(string id);
        Task<IdentityResult> PostRemoveUserFromclaim(AddOrRemoveClaimViewModel model);
        Task<string> GetUserIdByUserName(string username);
        Task<IdentityResult> ChangePassword(string username, string currentpass, string newpass);
        Task<IdentityUserChange> GetUserByEmail(string email);
        Task<IdentityResult> ResetPassword(string username, string token,string newpass);
        Task<bool> IsResetPasswordTokenValid(string username, string token);
    }
}