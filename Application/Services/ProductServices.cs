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
       private readonly IItemRepository _item;
       public ProductServices(IProductRepository product,IItemRepository item)
        {
            _product = product;
            _item = item;
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
                    ProductId = n.Id,
                    quantityinstock = (await _item.GetDetail(n.Id)).QuantityInStock,
                    Price = (await _item.GetDetail(n.Id)).Price
                };
                model.Add(temp);
            }

            return model;
        }

        public async Task CreateProduct(CreateProductViewModel model)
        {
           await _product.AddProduct(model.Name, model.ImageUrl, model.ShortDescription, model.LongDescription,
                model.quantityInStock, model.Price, model.ImageName);
        }

        public async Task DeleteProduct(int productid)
        {
          await  _product.DeleteProduct(productid);
          await _item.DeleteItem(productid);
        }

        public async Task<ProductViewModel> GetProductDetail(int productid)
        {
            Product temp = await _product.GetProduct(productid);
            Item itemp = await _item.GetDetail(productid);
            ProductViewModel model = new ProductViewModel()
            {
                Name = temp.Name,
                ShortDescription = temp.ShortDescription,
                LongDescription = temp.LongDescription,
                BuyCount = temp.BuyCount,
                VisitCount = temp.VisitCount,
                ImgUrl = temp.ImgUrl,
                quantityinstock = itemp.QuantityInStock,
                Price = itemp.Price
            };
            return model;
        }

        public async Task Edit(CreateProductViewModel model)
        {
           await _product.ChangeProduct(model.ProductId, model.Name, model.ImageUrl, model.ShortDescription,
                model.LongDescription, model.quantityInStock, model.Price, model.ImageName);
        }
   }
}
