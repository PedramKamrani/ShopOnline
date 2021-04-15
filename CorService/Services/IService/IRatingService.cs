using DataLayer.Entites.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorService.Services.IService
{
   public interface IRatingService
    {
        List<RatingAttributs> ShowAttibuitForAdmin();
        bool AddRating(RatingAttributs rating);
    }
}
