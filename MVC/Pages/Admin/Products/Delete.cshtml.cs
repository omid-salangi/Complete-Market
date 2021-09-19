using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using Application.Interface;
using Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Data.Context;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;

namespace MVC.Pages.Admin.Products
{ 
    public class DeleteModel : PageModel
    {
        private readonly IProductServices _product;
        private readonly IImageServices _image;
        private readonly IWebHostEnvironment _hostEnvironment;

        public DeleteModel(IProductServices product,IImageServices image,IWebHostEnvironment hostEnvironment)
        {
            _product = product;
            _image = image;
            _hostEnvironment = hostEnvironment;
        }
       

        [BindProperty] 
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product =await _product.GetProductDetail(id.Value);
            await _image.Delete(Product.ImgUrl.Replace('\\', '/').Split('/').LastOrDefault(),
                _hostEnvironment.WebRootPath);
            await _product.DeleteProduct(id.Value);

            
            return RedirectToPage("./Index");
        }
    }
}
