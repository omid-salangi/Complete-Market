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
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _context;

        public ItemRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Item> GetDetail(int productid)
        {
            Item temp=await _context.Items.Where(i => i.ProductId == productid).FirstOrDefaultAsync();
            return temp;
        }

        public async Task DeleteItem(int productid)
        {
            var item = await _context.Items.Where(i => i.ProductId == productid).FirstOrDefaultAsync();
            if (item != null)
            {
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
            }
            
        }
    }
}
