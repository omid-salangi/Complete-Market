using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interface
{
    public interface IFavoriteListRepository
    {
        Task<IEnumerable<FavoriteList>> GetAllFavorites(string userid);
        Task<FavoriteList> GetOneFavorite(int productid);
        Task AddFavorite(string user, int productid);
        Task DeleteFavorite(int Favoriteid);


    }
}
