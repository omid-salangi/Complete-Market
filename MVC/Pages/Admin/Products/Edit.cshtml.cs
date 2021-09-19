using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data.Context;
using Domain.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace MVC.Pages.Admin.Products
{
    public class EditModel : PageModel
    {
        private readonly IProductServices _product;
        private readonly IImageServices _image;
        private readonly IWebHostEnvironment _hostEnvironment;

        public EditModel(IProductServices product,IImageServices image,IWebHostEnvironment hostEnvironment)
        {
            _image = image;
            _product = product;
            _hostEnvironment = hostEnvironment;
        }

        [BindProperty]
        public CreateProductViewModel Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductViewModel temp = await _product.GetProductDetail(id.Value);
            Product = new CreateProductViewModel()
            {
                Name = temp.Name,
                ShortDescription = temp.ShortDescription,
                LongDescription = temp.LongDescription,
                quantityInStock = temp.quantityinstock,
                Price = temp.Price,
                ProductId = temp.ProductId,
                ImageUrl = temp.ImgUrl,
                ImageName = temp.ImgUrl.Split('/').LastOrDefault()
            };

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            
            string extension = null;
            string wwwRootPath = _hostEnvironment.WebRootPath;
            if (Product.ImageFile.Length != null )
            {
                extension = Path.GetExtension(Product.ImageFile.FileName);
            }
            
            if (Product.ImageFile.Length == null)
            {
                await _product.Edit(Product);
                return RedirectToPage("./Index");
            }
             if (Product.ImageFile.Length >= 1024000)
            {
                ModelState.AddModelError("", "حداکثر اندازه عکس باید 1 مگابایت باشد.");
                return Page();
            }
             if (extension == ".gif" || extension == ".jpg" || extension == ".png")
            {
                _image.Delete(Product.ImageName, wwwRootPath);
                Product = await _image.SaveImage(Product, wwwRootPath, extension);
                await _product.Edit(Product);
                return RedirectToPage("./Index");
            }
            else
            {
                ModelState.AddModelError("", "برای اپلود عکس فقط از فرمت های png , jpg و gif استفاه کنید.");
                return Page();
            }

        }

        //private bool ProductExists(int id)
        //{
        //    return _context.Products.Any(e => e.Id == id);
        //}
    }
}
