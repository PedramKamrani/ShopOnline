using System;
using System.Collections.Generic;
using System.Text;

namespace CorService.ViewModels.Favorite
{
   public class FavoriteViewModel
    {
        public int FavoriteId { get; set; }
        public int Productid { get; set; }
        public string ProductTitle { get; set; }
        public string ImgName { get; set; }
        public int price { get; set; }
        public byte Star { get; set; }
    }
}
