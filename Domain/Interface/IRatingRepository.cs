using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
   public interface IRatingRepository
   {
       Task AddRatingToaProduct(string user, int productid,int rating);
       Task ChangeRatingOfaProduct(string user, int productid, int rating);

   }
}
