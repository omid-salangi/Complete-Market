using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
   public interface IOrderRepository
   {
       int GetCurrentOrder(string userid);
       void AddOrder(string userid);
       void DeleteOrder(int orderid);
       void AddOrderDetail(int orderid, int count);
       void deleteOrderDetail(int orderdetail);
       void changeCountOfOrderDetail(int orderdetail, int count);

   }

}
