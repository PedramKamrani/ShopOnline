using CorService.ViewModels.Product;
using DataLayer.Entites.Banner;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorService.Services.IService
{
   public interface IBannerService
    {
        List<Banners> GetBannerForAdmin();
        bool ChangeActiveBanner(int id);
        
    }
}
