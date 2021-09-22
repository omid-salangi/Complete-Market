using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Application.ViewModel;
using Domain.Interface;
using Microsoft.AspNetCore.Authorization;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductServices _product;

        public HomeController(ILogger<HomeController> logger,ICategoryRepository repository,IProductServices product)
        {
            _logger = logger;
            _product = product;
        }

        public async Task<IActionResult> Index(int pageid=1)
        {
            ViewBag.pageid = pageid;
            if (pageid/12 ==0)
            {
                ViewBag.pagecount = pageid / 12;
            }
            else
            {
                ViewBag.pagecount = (pageid / 12) + 1;
            }

            if (pageid > ViewBag.pagecount)
            {
                return NotFound();
            }

            var model = await _product.GetProductsByPaging(pageid);
            return View(model);
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
