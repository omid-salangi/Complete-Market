using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interface;

namespace Data.Repository
{
     public class RatingRepository:IRatingRepository
    {
        public Task AddRatingToaProduct(string user, int productid, int rating)
        {
            throw new NotImplementedException();
        }

        public Task ChangeRatingOfaProduct(string user, int productid, int rating)
        {
            throw new NotImplementedException();
        }
    }
}
