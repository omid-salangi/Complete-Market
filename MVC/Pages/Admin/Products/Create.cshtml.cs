using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Application.Services;
using Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Data.Context;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace MVC.Pages.Admin.Products
{
    
    [Authorize(Roles = "Admin,Owner")]
    public class CreateModel : PageModel
    {
        private readonly IProductServices _product;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IImageServices _image;

        public CreateModel(IProductServices product,IWebHostEnvironment hostEnvironment,IImageServices image)
        {
            _product = product;
            _hostEnvironment = hostEnvironment;
            _image = image;
        }

        public async Task<IActionResult> OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CreateProductViewModel Product { get; set; }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync()
        {
            
            if (!ModelState.IsValid)
            {
                return Page();
            }
            string wwwRootPath = _hostEnvironment.WebRootPath;
            
            if ((Product.ImageFile) != null)
            {
                 string extension = Path.GetExtension(Product.ImageFile.FileName);
                 if (Product.ImageFile.Length >= 1024000)
                 {
                     ModelState.AddModelError("", "حداکثر اندازه عکس باید 1 مگابایت باشد.");
                     return Page();
                 }
                 else if (extension == ".gif" || extension == ".jpg" || extension == ".png")
                 {
                     Product = await _image.SaveImage(Product, wwwRootPath, extension);
                     _product.CreateProduct(Product);
                 }
                 else
                 {
                     ModelState.AddModelError("", "برای اپلود عکس فقط از فرمت های png , jpg و gif استفاه کنید.");
                     return Page();
                 }
            }
            else if(Product.ImageFile == null)
            {
                Product = await _image.SaveImageNoPicture(Product);
                await _product.CreateProduct(Product);
            }
            
        
            return RedirectToPage("./Index");
        }
    }
}
