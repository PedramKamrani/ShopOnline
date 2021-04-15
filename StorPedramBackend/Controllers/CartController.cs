using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorService.Services.IService;
using DataLayer.Entites.Cart;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StorPedramBackend.Controllers
{
    public class CartController : Controller
    {
        private ICartService _CartService;
        public CartController(ICartService CartService)
        {
            _CartService = CartService;
        }
        public IActionResult Index()
        {
            return View();
        }
       
    }
}