﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Application.Services
{
    public class ClaimRequirement : IAuthorizationRequirement
    {
        public ClaimRequirement(string claimType, string claimValue)
        {
            ClaimType = claimType;
            ClaimValue = claimValue;
        }
        public string ClaimType { get; }
        public string ClaimValue { get; set; }
    }
}
