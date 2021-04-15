using CorService.Services.IService;
using DataLayer.Context;
using DataLayer.Entites.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CorService.Services.RatingService
{
   public class RatingService:IRatingService
    {
        DigikalaContext _context;
        public RatingService(DigikalaContext context)
        {
            _context = context;
        }
        public List<RatingAttributs> ShowAttibuitForAdmin()
        {
            return _context.RatingAttributs.ToList();
        }
        public bool AddRating(RatingAttributs rating)
        {
            _context.Add(rating);
            int res = _context.SaveChanges();
            if (res > 0)
                return true;
            return false;
        }
    }
}
