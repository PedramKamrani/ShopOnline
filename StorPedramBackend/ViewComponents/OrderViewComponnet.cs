using CorService.Services.IService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorPedramBackend.ViewComponents
{
    public class OrderViewComponnet:ViewComponent
    {
        ICartService _CartService;
        public OrderViewComponnet(ICartService CartService)
        {
            _CartService = CartService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userid =int.Parse(UserClaimsPrincipal.FindFirst("userid").Value);
            return await Task.FromResult(View("_showOrder", _CartService.ShowOrderProuducts(userid)));
        }
    }
}
