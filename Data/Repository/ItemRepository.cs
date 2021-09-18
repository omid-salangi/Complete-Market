using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using Domain.Interface;
using Domain.Models;

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
            return _context.Items.Where(i => i.ProductId == productid).FirstOrDefault();
        }
    }
}
