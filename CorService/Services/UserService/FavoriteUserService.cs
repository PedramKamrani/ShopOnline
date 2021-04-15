using CorService.Services.IService;
using CorService.ViewModels.Favorite;
using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CorService.Services.UserService
{
   public class FavoriteUserService:IFavoriteService
    {
        DigikalaContext _context;
        public FavoriteUserService(DigikalaContext context)
        {
            _context = context;
        }
        public List<FavoriteViewModel> ProductFavoriteUser(int UserId)
        {
            return _context.UserProductFovorites.Where(u => u.UserId == UserId).Select(b=>new FavoriteViewModel 
            { 
                ImgName=b.Products.ImgName,
                price=b.Products.Weight,
                FavoriteId=b.UserProductFovoritesId,
                Productid=b.ProductId,
                ProductTitle=b.Products.FaTitle
            }).ToList();
        }
        public bool ChekEcxistFavorite(int userid, int favoriteid)
        {
   
            return _context.UserProductFovorites.Any(u=>u.UserId==userid&&u.UserProductFovoritesId== favoriteid);
        }
        public bool RemoveFavpritr(FavoriteViewModel favorite)
        {
            try
            {
                _context.Remove(favorite);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
