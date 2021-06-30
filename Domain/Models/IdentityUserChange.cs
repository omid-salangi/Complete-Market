using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Domain.Models
{
    public class IdentityUserChange : IdentityUser
    {

        //relations
        public ICollection<Comments> Comments { get; set; }
    }
}
