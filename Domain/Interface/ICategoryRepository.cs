using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel;
using Domain.Models;

namespace Domain.Interface
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<IEnumerable<ShowCategorySideBarViewModel>> GetCategorySideBar();
        Task AddCategory(string name, string description);
        Task DeleteCategory(int id);
        Task EditCategory(int id, string name, string description);
        Task<IEnumerable<ShowProductsByCategoryViewModel>>  ShowProductsByCategory(int id);


    }
}
