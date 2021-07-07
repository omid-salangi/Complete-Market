using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.ViewModel;
using Domain.Interface;
using Domain.Models;

namespace Data.Repository
{
   public class CategoryRepository :ICategoryRepository
  {
      public async Task<IEnumerable<Category>> GetAllCategories()
      {
          throw new System.NotImplementedException();
      }

      public async Task<IEnumerable<ShowCategorySideBarViewModel>>  GetCategorySideBar()
      {
          throw new System.NotImplementedException();
      }

      public async Task AddCategory(string name, string description)
      {
          
      }

      public async Task DeleteCategory(int id)
      {
          throw new System.NotImplementedException();
      }

      public async Task EditCategory(int id, string name, string description)
      {
          throw new System.NotImplementedException();
      }

      public async Task<IEnumerable<ShowProductsByCategoryViewModel>> ShowProductsByCategory(int id)
      {
          throw new System.NotImplementedException();
      }
  } 
}
