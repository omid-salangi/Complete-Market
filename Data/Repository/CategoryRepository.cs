using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.ViewModel;
using Data.Context;
using Domain.Interface;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Data.Repository
{
   public class CategoryRepository :ICategoryRepository
   {
       private AppDbContext _context;

       public CategoryRepository(AppDbContext context)
       {
           _context = context;
       }

      public async Task<IEnumerable<Category>> GetAllCategories()
      {
          return _context.Categories;
      }

   

      public async Task AddCategory(string name, string description)
      {
          Category temp = new Category()
          {
              Name = name,
              Description = description
          };
          _context.Categories.Add(temp);
          await _context.SaveChangesAsync();
      }

      public async Task DeleteCategory(int id)
      {
          Category temp = await _context.Categories.FindAsync(id);
          _context.Categories.Remove(temp);
          await  _context.SaveChangesAsync();


      }

      public async Task EditCategory(int id, string name, string description)
      {
          Category temp = await _context.Categories.FindAsync(id);
          temp.Name = name;
          temp.Description = description;
          await _context.SaveChangesAsync();
      }

      public async Task<Category> GetCategory(int id)
      {
          Category category =  await _context.Categories.FindAsync(id);
          return category;
      }
   } 
}
