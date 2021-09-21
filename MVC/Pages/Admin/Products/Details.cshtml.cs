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
using Microsoft.CodeAnalysis.CSharp;

namespace MVC.Pages.Admin.Products
{
    [Authorize(Roles = "Admin,Owner")]
    public class DetailsModel : PageModel
    {
        private readonly IProductServices _product;

        public DetailsModel(IProductServices product)
        {
            _product=product;
        }
        
        public ProductViewModel Product { get; set; }
        
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _product.GetProductDetail(id.Value);
          

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
