using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interface;
using Application.ViewModel;
using Domain.Interface;
using Domain.Models;
namespace Application.Services
{
   public class ProductServices :IProductServices
   {
       private readonly IProductRepository _product;
        public ProductServices(IProductRepository product)
        {
            _product = product;
        }
        public async Task<IList<ProductViewModel>> GetProducts()
        {
            IList<Product> pros = await _product.GetallProducts();
            IList<ProductViewModel> model = new List<ProductViewModel>();
            foreach (var n in pros)
            {
                ProductViewModel temp = new ProductViewModel()
                {
                    Name = n.Name,
                    ShortDescription = n.ShortDescription,
                    LongDescription = n.LongDescription,
                    ImgUrl = n.ImgUrl,
                    BuyCount = n.BuyCount,
                    VisitCount = n.VisitCount,
                    ProductId = n.Id
                };
                model.Add(temp);
            }

            return model;
        }

        public Task CreateProduct(CreateProductViewModel model)
        {
            return Task.CompletedTask;
        }
   }
}
