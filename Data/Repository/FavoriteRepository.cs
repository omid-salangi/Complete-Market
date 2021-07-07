using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interface;
using Domain.Models;

namespace Data.Repository
{
    public class FavoriteRepository:IFavoriteListRepository
    {
        public async Task<IEnumerable<FavoriteList>> GetAllFavorites(string userid)
        {
            throw new NotImplementedException();
        }

        public async Task<FavoriteList> GetOneFavorite(int productid)
        {
            throw new NotImplementedException();
        }

        public async Task AddFavorite(string user, int productid)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteFavorite(int Favoriteid)
        {
            throw new NotImplementedException();
        }
    }
}
