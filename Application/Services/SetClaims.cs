using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization;

namespace Application.Services
{
     public class SetClaims
    {
        public static void SetClaim(IServiceCollection services)
        {
            services.AddAuthorization(option =>
            {
                option.AddPolicy("ProductListPolicy",policy=> // ProductlistPolicy is a name that you select 
                {
                    policy.RequireClaim(ClaimTypeStore.ProductList);
                });
            });
        }
    }
}
