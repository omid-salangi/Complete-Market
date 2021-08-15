using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using Domain.Interface;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class OrderRepository:IOrderRepository
    {
        private AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> GetCurrentOrder(string userid)
        {
           Order temp =await _context.Orders.Where(o => o.UserId == userid && o.IsFinally == false)
                .FirstOrDefaultAsync();
           if (temp == null)
           {
               Order newtemp = new Order()
               {
                   DateTime = DateTime.Now,
                   IsFinally = false,
                   UserId = userid
               };
               await _context.Orders.AddAsync(newtemp);
               _context.SaveChanges();
               return newtemp.Id;
           }
           else
           {
               return temp.Id;
           }

           
        }

        public async Task AddOrder(string userid)
        {
            Order newtemp = new Order()
            {
                DateTime = DateTime.Now,
                IsFinally = false,
                UserId = userid
            };
            await _context.Orders.AddAsync(newtemp);
            _context.SaveChanges();
        }

        public async Task DeleteOrder(int orderid)
        {
            Order temp = await _context.Orders.Where(o => o.Id == orderid).FirstOrDefaultAsync();
            if (temp == null)
            {
                return;
            }
            else
            {
                _context.Orders.Remove(temp);
                _context.SaveChanges();
            }

        }

        public async Task AddOrderDetail(string userid,int orderid, int count,int productid)
        {
            Order temp = await _context.Orders.FindAsync(orderid);
            if (temp==null)
            {
                await AddOrder(userid);
                AddOrderDetail(userid, orderid, count, productid);
            }
            else
            {
                OrderDetail orderDetailtemp = new OrderDetail()
                {
                    OrderId = orderid,
                    count = count,
                    ProductId = productid
                };
                await _context.OrderDetails.AddAsync(orderDetailtemp);
                _context.SaveChanges();
            }

        }

        public async Task deleteOrderDetail(int orderdetail)
        {
            OrderDetail temp = await _context.OrderDetails.FindAsync(orderdetail);
            _context.OrderDetails.Remove(temp);
            _context.SaveChanges();
        }

        public async Task changeCountOfOrderDetail(int orderdetail, int count)
        {
            OrderDetail temp =await _context.OrderDetails.FindAsync(orderdetail);
            temp.count = count;
            _context.SaveChanges();
        }
    }
}
