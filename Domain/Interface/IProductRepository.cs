using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interface
{
    public interface IProductRepository
    {
        Task<IList<Product>> GetallProducts();
        Task<Product> GetProduct(int productid);
        Task ChangeProduct(int id, string productname, string imgurl, string shortdescription, string longdescription,int countitem,decimal price, string imgname);
        Task DeleteProduct(int productId);
        Task AddProduct(string productname, string imgurl, string shortdescription, string longdescription,int countitem,decimal price,string imgname);
        Task<IList<Product>> GetForIndex(int pageid);
        Task<int> CountOfProducs();
        Task AddViewCount(int productid);
    }
}
