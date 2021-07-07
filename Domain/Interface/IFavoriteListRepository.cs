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
        IEnumerable<FavoriteList> GetAllFavorites(string userid);
        FavoriteList GetOneFavorite(int productid);
        void AddFavorite(string user, int productid);
        void DeleteFavorite(int Favoriteid);


    }
}
