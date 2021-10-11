using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Application.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft;
using Newtonsoft.Json;

namespace MVC.Controllers
{
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly IOrderServices _order;

        public APIController(IOrderServices order)
        {
            _order = order;
        }
        [HttpPost]
        public async Task<JsonResult> AddtoCart(int productid,int count)
        {
           var res= await _order.AddToCart(User.Identity.Name, productid, count);
           var ret = new JsonModel();
           if (res ==true)
           {
               ret.Message = "با موفقیت به سبد خرید افزوده شد.";
               ret.Res = true;
           }
           else
           {
               ret.Message = "مشکلی رخ داده است.";
               ret.Res = false;
           }

           return new JsonResult(ret);

        }
    }
}
