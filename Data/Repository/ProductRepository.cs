using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using Domain.Interface;
using Domain.Models;

namespace Data.Repository
{
   public class ProductRepository:IProductRepository
   {
       private AppDbContext _context;

       public ProductRepository(AppDbContext context)
       {
           _context = context;
       }
        public async Task<IEnumerable<Product>> GetallProducts()
        {
            return _context.Products;
        }

        public async Task<Product> GetProduct(int productid)
        {
            return await _context.Products.FindAsync(productid);
        }

        public async Task ChangeProduct(int id, string productname, string imgurl, string shortdescription, string longdescription,
            int countitem, double price)
        {
            Product temp = await _context.Products.FindAsync(id);
            temp.Name = productname;
            temp.ImgUrl = imgurl;
            temp.ShortDescription = shortdescription;
            temp.LongDescription = longdescription;
            temp.Item.QuantityInStock = countitem;
            temp.Item.Price = price;
            _context.SaveChanges();
        }

        public async Task DeleteProduct(int productId)
        {
            Product pro = await _context.Products.FindAsync(productId);
            _context.Products.Remove(pro);
            _context.SaveChanges();
        }

        public async Task AddProduct(string productname, string imgurl, string shortdescription, string longdescription, int countitem,
            double price)
        {
            Product pro = new Product()
            {
                Name = productname,
                ImgUrl = imgurl,
                ShortDescription = shortdescription,
                LongDescription = longdescription,
            };
            await _context.Products.AddAsync(pro);
            _context.SaveChanges();
            Item item = new Item()
            {
                QuantityInStock = countitem,
                Price = price
            };
            await _context.Items.AddAsync(item);
            _context.SaveChanges();
            pro.ItemId = item.Id;
            _context.SaveChanges();
        }

      
    }
}
