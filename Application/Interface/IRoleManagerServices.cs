using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Application.Interface
{
    public interface IRoleManagerServices
    {
        Task<IdentityResult> Addrole(string name);
        Task<IList<IdentityRole>> GetAllRoles();
        Task DeleteRole(string id);
        Task<IdentityRole> GetRole(string id);
        Task<IdentityResult> EditRole(string id, string name);
        
    }
}