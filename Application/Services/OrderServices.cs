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
        private readonly IUserManagerServices _user;

        public OrderServices(IOrderRepository order, IItemRepository item, IUserManagerServices user)
        {
            _order = order;
            _item = item;
            _user = user;
        }
        public async Task<bool> AddToCart(string username, int productid, int count)
        {
            string userid = await _user.GetUserIdByUserName(username);
            try
            {
                int or = await _order.GetCurrentOrder(userid);
                var itm = await _item.GetDetail(productid);
                if (itm == null)
                {
                    return false;
                }
                else if (itm.QuantityInStock >= count)
                {
                    await _order.AddOrderDetail(userid, or, count, productid);
                    return true;
                }

                return false;

            }
            catch (Exception e)
            {
                return false;
            }
            
        }
    }
}
