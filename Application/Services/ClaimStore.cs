using System.Collections.Generic;
using System.Security.Claims;

namespace Application.Services
{
    public static class ClaimStore
    {
        public static List<Claim> AllClaims = new List<Claim>()
        {
            new  Claim(ClaimTypeStore.IsEmailConfirmed,true.ToString()),
         
    };
    }

    public static class ClaimTypeStore
    {
        public const string IsEmailConfirmed = "IsEmailConfirmed";
     
    }
}
