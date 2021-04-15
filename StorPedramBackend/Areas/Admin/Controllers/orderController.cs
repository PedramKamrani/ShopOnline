using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorService.Services.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StorPedramBackend.Areas.Admin.Controllers
{
    public class orderController : Controller
    {
        private ICartService _cartService;
        public orderController(ICartService cartService)
        {
            _cartService = cartService;
        }
        [Area("Admin")]
        [Authorize]
        public IActionResult orderList()
        {
            return View(_cartService.getAllorderforAdmin());
        }
    }
}
