using CorService.Services.IService;
using DataLayer.Context;
using DataLayer.Entites.OrderProuduct;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataLayer.Entites.User;
using DataLayer.Entites.Cart;
using Microsoft.AspNetCore.Http;

namespace CorService.Services.Order
{
   public class Cartservice:ICartService
    {
        DigikalaContext _context;
        public Cartservice(DigikalaContext context)
        {
            _context = context;
        }

        #region Order
        public bool FindOpenOrder(OrderProuducts orderid, int id)
        {
            var res = _context.DetailesOrders
                 .SingleOrDefault(o => o.Ordeid == orderid.OrderProuductsid && o.ProductId == id);
            if (res == null)
                return false;
            return true;
        }
        public int AddOrder(int userid)
        {
            OrderProuducts order = new OrderProuducts()
            {
                creatDate=DateTime.Now,
                IsFainally=false,
                UserId=userid
            };
            _context.Add(order);
            _context.SaveChanges();
            return order.OrderProuductsid;
        }
        public bool AddOrderDetaile(int orderid,int productid)
        {
            int id = _context.Products.Find(productid).ProductId;
          DetailesOrder detailes= new DetailesOrder()
            {
                Ordeid = orderid,
                count = 1,
                Price = _context.Products.Find(id).Weight,
                ProductId = id
            };
            _context.Add(detailes);
           int res= _context.SaveChanges();
            if (res > 0)
                return true;
            return false;
        }
        public void UpdateSumOrder(int orderId)
        {
            var order = _context.OrderProuducts.Find(orderId);
            order.Sum = _context.DetailesOrders.Where(o => o.Ordeid == order.OrderProuductsid).Sum(d => d.Price * d.count);
            _context.Update(order);
            _context.SaveChanges();
        }
        public OrderProuducts ShowOrderProuducts(int userid)
        {
            OrderProuducts Sum =_context.OrderProuducts.Where(o=>o.UserId==userid&&o.IsFainally==false).Select(o=>new OrderProuducts { Sum=o.Sum}).SingleOrDefault();
            return Sum;
        }
        public List<OrderProuducts> getAllorderforAdmin()
        {
            return _context.OrderProuducts.Where(o=>o.IsFainally==true).ToList();
        }
        
        #endregion
    }
}
