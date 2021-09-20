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

    }
}