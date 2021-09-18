using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interface
{
   public interface IItemRepository
   {
       Task<Item> GetDetail(int productid);
   }
}
