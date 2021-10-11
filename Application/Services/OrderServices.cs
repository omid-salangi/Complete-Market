using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interface;
using Domain.Interface;
using Domain.Models;

namespace Application.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly IOrderRepository _order;
        private readonly IItemRepository _item;

        public OrderServices(IOrderRepository order, IItemRepository item)
        {
            _order = order;
            _item = item;
        }
        public async Task<bool> AddToCart(string userid, int productid, int count)
        {
            try
            {
                int or = await _order.GetCurrentOrder(userid);
                OrderDetail od = new OrderDetail()
                {
                    ProductId = productid,
                    count = count,
                    Price = (decimal) (count*((await _item.GetDetail(productid).Result.Price))
                };
            }
            catch (Exception e)
            {
                
            }
            
        }
    }
}
