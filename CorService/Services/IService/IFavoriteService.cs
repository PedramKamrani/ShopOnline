using CorService.ViewModels.Favorite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorService.Services.IService
{
   public interface IFavoriteService
    {
        List<FavoriteViewModel> ProductFavoriteUser(int UserId);
        bool ChekEcxistFavorite(int userid, int favoriteid);
        bool RemoveFavpritr(FavoriteViewModel favorite);
    }
}
