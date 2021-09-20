using System.Collections.Generic;

namespace Application.ViewModel
{

    public class AddUserToRoleViewModel
    {
        public AddUserToRoleViewModel() // we used this because if this list will be null error will occur
        {
            UserRoles = new List<UserRolesViewModel>();
        }

        public string UserId { get; set; }

        public List<UserRolesViewModel> UserRoles { get; set; }
    }

   public class UserRolesViewModel
    {
        public string RoleName { get; set; }
        public bool IsSelected { get; set; }
    }
    
}
