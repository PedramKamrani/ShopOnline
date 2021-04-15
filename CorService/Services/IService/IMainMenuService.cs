using DataLayer.Entites.MainMenu;
using System;
using System.Collections.Generic;
using System.Text;
using static CorService.ViewModels.MainMenu.MainMenuViewModel;

namespace CorService.Services.IService
{
   public interface IMainMenuService
    {
        int AddParentMenu(MainMenu menu);
        bool AddsubMenu(List<MainMenu> submenu);
        List<MainMenu> GetMenuListForAdmin();
         bool DeleteMenu(MainMenu mainMenu);
         bool DeletesubMenu(List<MainMenu> subMenus);
        MainMenu GetParentMenu(int id);
        List<MainMenuShowViewModel> GetMainMenu();
    }
}
