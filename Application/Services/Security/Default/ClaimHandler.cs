using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Application.Services.Security.Default
{
   public class ClaimHandler:AuthorizationHandler<ClaimRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ClaimRequirement requirement)
        {
            var claim = context.User.Claims.Where(c => c.Type == requirement.ClaimType).FirstOrDefault();
            if (claim != null )
            {
                if (claim.Value==true.ToString())
                {
                    context.Succeed(requirement);
                    return Task.CompletedTask;
                }
               return Task.CompletedTask;
            }
            else
            {
                context.Fail();
                return Task.CompletedTask;
            }
        }
    }
}
