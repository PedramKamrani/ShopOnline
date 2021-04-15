using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorService.Services.IService;
using Microsoft.AspNetCore.Mvc;

namespace StorPedramBackend.Areas.User.Controllers
{
    [Area("User")]
    public class ProfileController : Controller
    {
        private IFavoriteService _favoriteService;
        public ProfileController(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult FProduct()
        {
            int userid = int.Parse(User.FindFirst("userid").Value);
            return View(_favoriteService.ProductFavoriteUser(userid));
        }
        [HttpPost]
        public IActionResult RemoveFavorite(int id)
        {
            int userid = int.Parse(User.FindFirst("userid").Value);
            if (_favoriteService.ChekEcxistFavorite(userid, id))
            {

            }
            return View();
        }
    }
}
