﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
   public interface IOrderRepository
   {
       Task<int> GetCurrentOrder(string userid);
       Task AddOrder(string userid);
       Task DeleteOrder(int orderid);
       Task AddOrderDetail(string userid,int orderid, int count,int productid);
       Task deleteOrderDetail(int orderdetail);
       Task changeCountOfOrderDetail(int orderdetail, int count);

   }

}
