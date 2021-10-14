using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Application.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace MVC.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class APIController : ControllerBase
    {
        private readonly IOrderServices _order;
        private readonly IProductServices _product;

        public APIController(IOrderServices order, IProductServices product)
        {
            _order = order;
            _product = product;
        }

        [Authorize]
        [HttpPost("AddToCart")]
        public async Task<string> AddToCart([FromBody] AddToCartModel model)
        {
          
            var ret = new JsonModel();
            if (model==null || model.productid == 0)
            {
                ret.Message = "مشکلی رخ داده است.";
                ret.Res = false;
                return JsonConvert.SerializeObject(ret);
            }
            else if (model.count<= 0)
            {
                ret.Message = "تعداد کالا حداقل باید 1 عدد باشد.";
                ret.Res = false;
                return JsonConvert.SerializeObject(ret);
            }
            else if ((await _product.IsProductEnough(model.productid,model.count))==false)
            {
                ret.Message = "تعداد کالا به اندازه نیاز شما موجود نیست.";
                ret.Res = false;
                return JsonConvert.SerializeObject(ret);
            }
            //if (come == null)
            //{
            //    ret.Message = "مشکلی رخ داده است.";
            //    ret.Res = false;
            //    return JsonConvert.SerializeObject(ret);
            //}
            //AddToCartModel model = JsonConvert.DeserializeObject<AddToCartModel>(come);

            var res = await _order.AddToCart(User.Identity.Name, model.productid, model.count);
           
            if (res == true)
            {
                ret.Message = "با موفقیت به سبد خرید افزوده شد.";
                ret.Res = true;
            }
            else
            {
                ret.Message = "مشکلی رخ داده است.";
                ret.Res = false;
            }

            return JsonConvert.SerializeObject(ret);

        }
    }
}
