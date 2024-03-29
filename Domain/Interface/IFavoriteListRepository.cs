﻿using System;
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
        Task AddFavorite(string user, int productid);
        Task DeleteFavorite(string user, int productid);


    }
}
