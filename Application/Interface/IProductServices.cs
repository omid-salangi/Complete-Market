using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel;
using Domain.Models;

namespace Application.Interface
{
    public interface IProductServices
    {
        Task<IList<ProductViewModel>> GetProducts();
        Task CreateProduct(CreateProductViewModel model);
        Task DeleteProduct(int productid);
        Task<ProductViewModel> GetProductDetail(int productid);
        Task Edit(CreateProductViewModel model);
        Task<IList<ProductIndexViewModel>> GetProductsByPaging(int pageid);
        Task<int> CountOfProduct();
        Task addviewcount(int productid);
        Task<bool> IsProductEnough(int productid, int count);

    }
}
