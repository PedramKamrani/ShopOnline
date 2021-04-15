using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorService.ExtinsionMethod;
using CorService.Security;
using CorService.Services.IService;
using DataLayer.Entites.MainMenu;
using Microsoft.AspNetCore.Mvc;
using static CorService.ViewModels.MainMenu.MainMenuViewModel;

namespace StorPedramBackend.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ModulesController : Controller
    {
        private IMainMenuService _MainMenuService;
        public ModulesController(IMainMenuService MainMenuService)
        {
            _MainMenuService = MainMenuService;
        }
        #region MainMenu
        public IActionResult CreateMenu()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateMenu(CreateMenuViewModel mainmenu)
        {
            if (!ModelState.IsValid)
                return View(mainmenu);
            MainMenu parentmenu = new MainMenu
            {
                MenuTitle = mainmenu.ParentMenuTitle,
                Link = mainmenu.ParentMenuLink,
                Sort =int.Parse(mainmenu.ParentSort),
            };
            int parentid = _MainMenuService.AddParentMenu(parentmenu);
            if (parentid <= 0)
                return View(mainmenu);
            if (mainmenu.SubMenuList != null && mainmenu.SubMenuList.Count > 0)
            {
        
                mainmenu.SubMenuList = mainmenu.SubMenuList.Where(s => s.IsHidden == false).ToList();

                List<MainMenu> sublist = new List<MainMenu>();
                foreach (var item in mainmenu.SubMenuList)
                {
                    string imgname = "";
                    if (item.Image != null)
                    {
                        if (ImgeSecurity.ImageValitor(item.Image))
                        {
                            imgname = item.Image.SaveImage("", "wwwroot/img/menu");
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "لطفا یک فایل درست انتحاب کنید");
                            return View(mainmenu);
                        }
                    }

                    sublist.Add(new MainMenu
                    {
                        Link = item.SubMenuLink,
                        MenuTitle = item.SubMenuTitle,
                        Sort = item.SubMenuSort,
                        Type = (byte)item.Type,
                        ImageName = imgname,
                        ParentId = parentid
                    });

                }
                var res = _MainMenuService.AddsubMenu(sublist);
                TempData["res"] = res ? "success" : "faild";
                return RedirectToAction("MenuList");
            }


            TempData["res"] = "success";
            return RedirectToAction("MenuList");
        }
        public IActionResult MenuList()
        {
            return View(_MainMenuService.GetMenuListForAdmin());
        }
        [HttpPost]
        public IActionResult DeleteMenu(int id)
        {
            MainMenu mainMenu = _MainMenuService.GetParentMenu(id);
            if (mainMenu == null)
            {
                TempData["res"]="Faild";
                return RedirectToAction("MenuList");
            }
            bool res = _MainMenuService.DeleteMenu(mainMenu);
            TempData["res"] = res ? "success" :"Faild";
            return RedirectToAction("MenuList");
        }
        #endregion
    }
}