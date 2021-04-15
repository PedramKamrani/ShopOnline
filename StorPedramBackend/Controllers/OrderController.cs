using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorService.Services.IService;
using CorService.ViewModels.Order;
using DataLayer.Context;
using DataLayer.Entites.Cart;
using DataLayer.Entites.OrderProuduct;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZarinpalSandbox;

namespace StorPedramBackend.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private ICartService _CartService;
        private IUserService _UserService;
        DigikalaContext _context;
        public OrderController(ICartService CartService, DigikalaContext context, IUserService UserService)
        {
            _CartService = CartService;
            _UserService = UserService;
            _context = context;
        }
        public IActionResult Index()
        {
            var userid = int.Parse(User.FindFirst("userid").Value);

            OrderProuducts order = _context.OrderProuducts.SingleOrDefault(o => o.UserId == userid && o.IsFainally == false);
            List<ShowOrder> _list = new List<ShowOrder>();
            if (order != null)
            {
                var detal = _context.DetailesOrders.Where(o => o.Ordeid == order.OrderProuductsid).ToList();
                foreach(var item in detal)
                {
                   var product= _context.Products.Find(item.ProductId);
                    _list.Add(new ShowOrder
                    {
                        Count=item.count,
                        Price=item.Price,
                        ProductName=product.FaTitle,
                        OrderDetailId=item.DetailesOrderId,
                        Sum=item.Price*item.count,
                        IsFainaly=order.IsFainally
                    });
                }
            }
            return View(_list);
        }
        
        public IActionResult Delete(int id)
        {
            var det = _context.DetailesOrders.Find(id);
            _context.Remove(det);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Command(int id,string command)
        {

            var det = _context.DetailesOrders.Find(id);
            switch (command)
            {
                case "up":
                    {
                        det.count += 1;
                        _context.Update(det);
                        break;
                    }
                case "down":
                    {
                        det.count -= 1;
                        if (det.count == 0)
                        {
                            _context.DetailesOrders.Remove(det);
                        }
                        else
                        {
                            _context.Update(det);
                        }
                        break;
                    }
            }

            _context.SaveChanges();
            _CartService.UpdateSumOrder(det.Ordeid);
            return RedirectToAction("Index");
        }


        public IActionResult AddToCart(int id)
        {
            var userid = int.Parse(User.FindFirst("userid").Value);
            
            OrderProuducts order = _context.OrderProuducts.SingleOrDefault(o => o.UserId == userid&&o.IsFainally==false);
            if (order == null)
            {
                int orderid=_CartService.AddOrder(userid);
               bool res= _CartService.AddOrderDetaile(orderid, id);
                if (true)
                    _CartService.UpdateSumOrder(orderid);
                return Redirect("/Product/ProductDetail");
            }
            else
            {
                
                var res = _context.DetailesOrders
                 .SingleOrDefault(o => o.Ordeid == order.OrderProuductsid && o.ProductId == id);
                if (res !=null)
                {
                    res.count += 1;
                    _context.SaveChanges();
                    _CartService.UpdateSumOrder(order.OrderProuductsid);
                    
                }
                else
                {
                    _CartService.AddOrderDetaile(order.OrderProuductsid, id);
                    _context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }

        public IActionResult Payment()
        {
            var order = _context.OrderProuducts.SingleOrDefault(o => o.IsFainally == false);
            if (order == null)
            {
                return NotFound();
            }
            var userid = int.Parse(User.FindFirst("userid").Value);
            var user=_UserService.FindUserById(userid);
            var payments = new Payment(order.Sum);
            var res = payments.PaymentRequest($"پرداخت{order.OrderProuductsid}", "https://localhost:44397/Order/OnlinePayment/"+ order.OrderProuductsid, "", user.Phone);
            if (res.Result.Status==100)
            {
                return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + res.Result.Authority);
            }
            else
            {
              return  BadRequest();
            }


        }
        public IActionResult OnlinePayment(int id)
        {
            if(HttpContext.Request.Query["status"]!=""&&
                HttpContext.Request.Query["status"].ToString().ToLower() =="ok"&&
                HttpContext.Request.Query["Authority"] != "")
            {
                string aturity = HttpContext.Request.Query["Authority"].ToString();
                var order = _context.OrderProuducts.Find(id);
                var payment = new Payment(order.Sum);
                var res = payment.Verification(aturity).Result;
                if (res.Status==100)
                {
                    order.IsFainally = true;
                    _context.Update(order);
                    _context.SaveChanges();
                    ViewBag.code =res.RefId;
                    return View();
                }
            }
            return View();
        }
    }
}