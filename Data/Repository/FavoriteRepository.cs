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
                if ( await _context.FavoriteToProducts.AnyAsync(f => f.FavoriteListId == temp.FavoriteListId && f.ProductId == productid))
                {
                    return;
                }
                FavoriteToProduct ftemp = new FavoriteToProduct()
                {
                    ProductId = productid,
                    FavoriteListId = temp.FavoriteListId
                };
                _context.FavoriteToProducts.Add(ftemp);
                 _context.SaveChanges();

            }
            else
            {
                IdentityUserChange itemp = await _context.Users.FindAsync(user);
                FavoriteList newftemp= new FavoriteList()
                {
                    IdentityUserChange = itemp
                };
                _context.FavoriteLists.AddAsync(newftemp);
                 _context.SaveChanges();

                     FavoriteToProduct ftemp = new FavoriteToProduct()
                {
                    ProductId = productid,
                    FavoriteListId = newftemp.FavoriteListId
                };
                _context.FavoriteToProducts.Add(ftemp);
                 _context.SaveChanges();
            }
        }

        public async Task DeleteFavorite(string user ,int productid)
        {
           FavoriteList temp= await _context.FavoriteLists.Where(f => f.IdentityUserChange.Id == user).FirstAsync();
           if (await _context.FavoriteToProducts.AnyAsync(P=> P.FavoriteListId==temp.FavoriteListId && P.ProductId == productid))
           {
               FavoriteToProduct ftemp = await _context.FavoriteToProducts
                   .Where(f => f.FavoriteListId == temp.FavoriteListId && f.ProductId == productid).FirstAsync();
               _context.FavoriteToProducts.Remove(ftemp);
               _context.SaveChanges();
           }
           else
           {
               return;
           }
        }

        public async Task<int> AddList()
        {
            FavoriteList favorite = new FavoriteList()
            {
                Count = 0
            };
            _context.FavoriteLists.Add(favorite);
            _context.SaveChanges();
            return favorite.FavoriteListId;
        }

    }
}
