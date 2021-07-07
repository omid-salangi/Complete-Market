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
        IEnumerable<Product> GetallProducts();
        Product GetProduct(int productid);
        void ChangeProduct(int id, string productname, string imgurl, string shortdescription, string longdescription,int countitem,double price);
        void DeleteProduct(int productId);
        void AddProduct(string productname, string imgurl, string shortdescription, string longdescription,int countitem,double price);
        int MeanOfRating(int product);


    }
}
