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
using Microsoft.AspNetCore.Hosting;

namespace MVC.Pages.Admin.Products
{
    public class CreateModel : PageModel
    {
        private readonly IProductServices _product;
        private readonly IWebHostEnvironment _hostEnvironment;

        public CreateModel(IProductServices product,IWebHostEnvironment hostEnvironment)
        {
            _product = product;
            _hostEnvironment = hostEnvironment;
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
            string fileName = Path.GetFileNameWithoutExtension(Product.ImageFile.FileName);
            string extension = Path.GetExtension(Product.ImageFile.FileName);
            if (Product.ImageFile.Length >= 1024000)
            {
                ModelState.AddModelError("","حداکثر اندازه عکس باید 1 مگابایت باشد.");
                return Page();
            }
            if (extension ==".gif" || extension ==".jgp" || extension==".png")
            {
                Product.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/img/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await Product.ImageFile.CopyToAsync(fileStream);
                }

                _product.CreateProduct(Product);
                Url.Content(path);
            }
            else 
            {
                ModelState.AddModelError("","برای اپلود عکس فقط از فرمت های png , jpg و gif استفاه کنید.");
                return Page();
            }
        
            return RedirectToPage("./Index");
        }
    }
}
