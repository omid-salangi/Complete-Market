using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
   public class AddOrRemoveClaimViewModel
    {
        public AddOrRemoveClaimViewModel() // for probable error
        {
            UserClaim = new List<ClaimViewModel>();
        }

        public AddOrRemoveClaimViewModel(string userId, IList<ClaimViewModel> userClaim)
        {
            UserId = userId;
            UserClaim = userClaim;
        }
        public string UserId { get; set; }
        public IList<ClaimViewModel> UserClaim { get; set; }
    }

   public class ClaimViewModel
   {
       public ClaimViewModel()
       {
           
       }
       public ClaimViewModel(string claimType)
       {
           ClaimType = claimType;
       }
       public string ClaimType { get; set; }
       public bool IsSelected { get; set; }
   }
}
