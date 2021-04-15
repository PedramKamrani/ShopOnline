using CorService.Services.IService;
using CorService.ViewModels.Product;
using DataLayer.Context;
using DataLayer.Entites.Banner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CorService.Services.Banner
{
   public class BannerService:IBannerService
    {
        private DigikalaContext _Context;
        public BannerService(DigikalaContext Context)
        {
            _Context = Context;
        }
        public List<Banners> GetBannerForAdmin()
        {
          return  _Context.Banners.ToList();

        }
        public bool ChangeActiveBanner(int id)
        {
            Banners banners = _Context.Find<Banners>(id);
            banners.IsActive = banners.IsActive == true ? false : true;
            _Context.Update(banners);
            int res = _Context.SaveChanges();
            if (res > 0)
                return true;
            return false;
        }
       
    }
}
