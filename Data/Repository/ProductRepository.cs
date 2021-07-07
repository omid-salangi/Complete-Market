using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interface;
using Domain.Models;

namespace Data.Repository
{
   public class ProductRepository:IProductRepository
    {
        public Task<IEnumerable<Product>> GetallProducts()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProduct(int productid)
        {
            throw new NotImplementedException();
        }

        public Task ChangeProduct(int id, string productname, string imgurl, string shortdescription, string longdescription,
            int countitem, double price)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public Task AddProduct(string productname, string imgurl, string shortdescription, string longdescription, int countitem,
            double price)
        {
            throw new NotImplementedException();
        }

        public Task<int> MeanOfRating(int product)
        {
            throw new NotImplementedException();
        }
    }
}
