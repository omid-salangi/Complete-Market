using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using Domain.Interface;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class FavoriteRepository:IFavoriteListRepository
    {
        private AppDbContext _context;

        public FavoriteRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<FavoriteList>> GetAllFavorites(string userid)
        {
            IEnumerable<FavoriteList> list =  _context.FavoriteLists.Where(f => f.IdentityUserChange.Id == userid);
            return list;
        }

       

        public async Task AddFavorite(string user, int productid)
        {
            bool res = await _context.FavoriteLists.AnyAsync(f => f.IdentityUserChange.Id == user);
            if (res == true)
            {
                FavoriteList temp = await _context.FavoriteLists.Where(f => f.IdentityUserChange.Id == user).FirstAsync();
                if ( await _context.FavoriteToProducts.AnyAsync(f => f.FavoriteListId == temp.Id && f.ProductId == productid))
                {
                    return;
                }
                FavoriteToProduct ftemp = new FavoriteToProduct()
                {
                    ProductId = productid,
                    FavoriteListId = temp.Id
                };
                _context.FavoriteToProducts.Add(ftemp);
                await _context.SaveChangesAsync();

            }
            else
            {
                IdentityUserChange itemp = await _context.Users.FindAsync(user);
                FavoriteList newftemp= new FavoriteList()
                {
                    IdentityUserChange = itemp
                };
                _context.FavoriteLists.AddAsync(newftemp);
                await _context.SaveChangesAsync();

                     FavoriteToProduct ftemp = new FavoriteToProduct()
                {
                    ProductId = productid,
                    FavoriteListId = newftemp.Id
                };
                _context.FavoriteToProducts.Add(ftemp);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteFavorite(string user ,int productid)
        {
           FavoriteList temp= await _context.FavoriteLists.Where(f => f.IdentityUserChange.Id == user).FirstAsync();
           if (await _context.FavoriteToProducts.AnyAsync(P=> P.FavoriteListId==temp.Id && P.ProductId == productid))
           {
               FavoriteToProduct ftemp = await _context.FavoriteToProducts
                   .Where(f => f.FavoriteListId == temp.Id && f.ProductId == productid).FirstAsync();
               _context.FavoriteToProducts.Remove(ftemp);
               await _context.SaveChangesAsync();
           }
           else
           {
               return;
           }
        }
    }
}
