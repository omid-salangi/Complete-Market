using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class FavoriteToProduct
    {
        public int ProductId { get; set; }
        public int FavoriteListId { get; set; }

        public Product Products { get; set; }
        public FavoriteList FavoriteLists { get; set; }    
    }
}
