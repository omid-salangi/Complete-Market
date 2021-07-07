using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
   public interface IRatingRepository
   {
       void AddRatingToaProduct(string user, int productid,int rating);
       void ChangeRatingOfaProduct(string user, int productid, int rating);

   }
}
