using CorService.Services.IService;
using DataLayer.Context;
using DataLayer.Entites.MainMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static CorService.ViewModels.MainMenu.MainMenuViewModel;

namespace CorService.Services.MainService
{
  public class MainMenuService:IMainMenuService
    {
        DigikalaContext _Context;
        public MainMenuService(DigikalaContext Context)
        {
            _Context = Context;
        }
        public int AddParentMenu(MainMenu menu) 
        {
            _Context.Add(menu);
            _Context.SaveChanges();
            return menu.MenuId;
        }
        public bool AddsubMenu(List<MainMenu> submenu)
        {
            _Context.AddRange(submenu);
           int res= _Context.SaveChanges();
            if (res > 0)
                return true;
            return false;
        }
        public List<MainMenu> GetMenuListForAdmin()
        {
            return _Context.MainMenus.Where(m=>m.ParentId==null).ToList();
        }
        public bool DeletesubMenu(List<MainMenu> subMenus)
        {
            _Context.RemoveRange(subMenus);
            int res = _Context.SaveChanges();
            if (res > 0)
                return true;
            return false;
        }
        public bool DeleteMenu(MainMenu mainMenu)
        {
            List<MainMenu> sublist = _Context.MainMenus.Where(m => m.ParentId == mainMenu.ParentId).ToList();
            bool res = true;

            if (sublist != null && sublist.Count > 0)
            {
                res= DeletesubMenu(sublist);
            }
            if (res)
            {
                _Context.Remove(mainMenu);
                int result = _Context.SaveChanges();
                if(result>0)
                return true;
                return false;
            }  
            return false;
        }
        public MainMenu GetParentMenu(int id)
        {
            return _Context.MainMenus.Where(m => m.ParentId == null && m.MenuId == id).SingleOrDefault();
        }
        public List<MainMenuShowViewModel> GetMainMenu()
        {
            return _Context.MainMenus.Select(m => new MainMenuShowViewModel
            {
                Link = m.Link,
                MenuId = m.MenuId,
                MenuTitle = m.MenuTitle,
                ParentId = m.ParentId,
                Sort = m.Sort,
                Type = m.Type
            }).ToList();
        }
    }
}
