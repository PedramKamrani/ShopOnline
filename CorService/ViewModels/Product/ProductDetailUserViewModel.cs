using System;
using System.Collections.Generic;
using System.Text;

namespace CorService.ViewModels.Product
{
   public class ProductDetailUserViewModel
    {
        public int ProductId { get; set; }
        public string FaTitle { get; set; }
        public string EnTitle { get; set; }
        public string ImgName { get; set; }
        public string CategoryName { get; set; }
        public string BrandName { get; set; }
        public int price { get; set; }
    }
}
