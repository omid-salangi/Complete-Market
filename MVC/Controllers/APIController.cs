using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft;
namespace MVC.Controllers
{
    [ApiController]
    public class APIController : ControllerBase
    { 
        private readonly 

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<JsonResult> AddtoCart(string productid,int count)
        {
            
        }
    }
}
