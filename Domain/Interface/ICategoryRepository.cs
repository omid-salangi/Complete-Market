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
        IEnumerable<Category> GetAllCategories();
        IEnumerable<ShowCategorySideBarViewModel> GetCategorySideBar();
        void AddCategory(string name, string description);
        void DeleteCategory(int id);
        void EditCategory(int id, string name, string description);
        IEnumerable<ShowProductsByCategoryViewModel> ShowProductsByCategory(int id);


    }
}
