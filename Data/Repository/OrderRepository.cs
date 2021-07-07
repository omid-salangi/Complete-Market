using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interface;

namespace Data.Repository
{
    public class OrderRepository:IOrderRepository
    {
        public Task<int> GetCurrentOrder(string userid)
        {
            throw new NotImplementedException();
        }

        public Task AddOrder(string userid)
        {
            throw new NotImplementedException();
        }

        public Task DeleteOrder(int orderid)
        {
            throw new NotImplementedException();
        }

        public Task AddOrderDetail(int orderid, int count)
        {
            throw new NotImplementedException();
        }

        public Task deleteOrderDetail(int orderdetail)
        {
            throw new NotImplementedException();
        }

        public Task changeCountOfOrderDetail(int orderdetail, int count)
        {
            throw new NotImplementedException();
        }
    }
}
