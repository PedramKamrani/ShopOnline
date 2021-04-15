using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorService.Services.IService;
using Microsoft.AspNetCore.Mvc;

namespace StorPedramBackend.Areas.User.Controllers
{
    public class UserController : Controller
    {
        private IUserService _UserService;
        public UserController(IUserService UserService)
        {
            _UserService = UserService;
        }
        [Area("Admin")]
        public IActionResult RoleList()
        {
            return View(_UserService.ShowUsers());
        }
    }
}