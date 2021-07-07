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
        public Task<IEnumerable<FavoriteList>> GetAllFavorites(string userid)
        {
            throw new NotImplementedException();
        }

        public Task<FavoriteList> GetOneFavorite(int productid)
        {
            throw new NotImplementedException();
        }

        public Task AddFavorite(string user, int productid)
        {
            throw new NotImplementedException();
        }

        public Task DeleteFavorite(int Favoriteid)
        {
            throw new NotImplementedException();
        }
    }
}
