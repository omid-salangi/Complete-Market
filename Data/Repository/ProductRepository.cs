using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using Domain.Interface;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
   public class ProductRepository : IProductRepository
   {
       private AppDbContext _context;

       public ProductRepository(AppDbContext context)
       {
           _context = context;
       }
        public async Task<IList<Product>> GetallProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProduct(int productid)
        {
            return await _context.Products.FirstOrDefaultAsync(m => m.Id == productid);
        }

        public async Task ChangeProduct(int id, string productname, string imgurl, string shortdescription, string longdescription,
            int countitem, decimal price,string imgname)
        {
            Product temp = await _context.Products.FindAsync(id);
            if (temp != null)
            {
                temp.Name = productname;
                temp.ImgUrl = imgurl;
                temp.ImgName = imgname;
                temp.ShortDescription = shortdescription;
                temp.LongDescription = longdescription;
                temp.Item.QuantityInStock = countitem;
                temp.Item.Price = price;
                _context.SaveChanges();
            }
        }

        public async Task DeleteProduct(int productId)
        {
            Product pro = await _context.Products.FindAsync(productId);
            if (pro !=null)
            {
                _context.Products.Remove(pro);
                _context.SaveChanges();
            }
            
        }

        public async Task AddProduct(string productname, string imgurl, string shortdescription, string longdescription, int countitem,
            decimal price,string imgname)
        {
            Product pro = new Product()
            {
                Name = productname,
                ImgUrl = imgurl,
                ShortDescription = shortdescription,
                LongDescription = longdescription,
                ImgName = imgname
            };
            await _context.Products.AddAsync(pro);
            _context.SaveChanges();
            Item item = new Item()
            {
                QuantityInStock = countitem,
                Price = price,
                ProductId = pro.Id
            };
            await _context.Items.AddAsync(item);
            _context.SaveChanges();
            
        }

        public async Task<IList<Product>> GetForIndex(int pageid)
        {
            int skip = (pageid - 1) * 12;
            return _context.Products.OrderBy(n => n.Id).Skip(skip).Take(12).ToList();
        }

        public async Task<int> CountOfProducs()
        {
            return _context.Products.Count();
        }

        public async Task AddViewCount(int productid)
        {
            Product temp = await _context.Products.FindAsync(productid);
            temp.VisitCount += 1;
            await _context.SaveChangesAsync();
        }
    }
}
