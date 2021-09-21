using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Data.Context;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;

namespace MVC.Pages.Admin.Products
{
    //[Authorize(Roles = "Admin,Owner")]
    public class IndexModel : PageModel
    {
        private readonly IProductServices _product;

        public IndexModel(IProductServices product)
        {
            _product = product;
        }

        public IList<ProductViewModel> Product { get;set; }

        public async Task OnGetAsync()
        {
            Product = await _product.GetProducts();
        }
    }
}
