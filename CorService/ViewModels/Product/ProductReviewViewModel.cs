using System;
using System.Collections.Generic;
using System.Text;

namespace CorService.ViewModels.Product
{
   public class ProductReviewViewModel
    {
        public string Suammry { get; set; }
        public string ShortReview { get; set; }
        public string Review { get; set; }
        public string Psitive { get; set; }
        public string Negative { get; set; }

        public List<ReviewRatingViewModel> ReviewRatingViewModels { get; set; }
    }
}
