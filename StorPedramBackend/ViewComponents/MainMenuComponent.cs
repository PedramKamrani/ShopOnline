using CorService.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CorService.ViewModels.MainMenu.MainMenuViewModel;

namespace StorPedramBackend.ViewComponents
{
    public class MainMenuComponent : ViewComponent
    {

        private IMainMenuService _mainMenuService;
        private IMemoryCache _memoryCache;
        public MainMenuComponent(IMainMenuService mainMenuService, IMemoryCache memoryCache)
        {
            _mainMenuService = mainMenuService;
            _memoryCache = memoryCache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<MainMenuShowViewModel> value = new List<MainMenuShowViewModel>();
            string Key = "MainmenuChache";
            if (!_memoryCache.TryGetValue("MainmenuChache", out value))
            {
                value = _mainMenuService.GetMainMenu();
                _memoryCache.Set(Key, value,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(30)));
            }
            return await Task.FromResult(View("MainMenu", value));
        }
    }
}

