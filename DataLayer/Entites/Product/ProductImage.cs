using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entites.Product
{
   public class ProductImage
    {
        [Key]
        public int ProductImageId { get; set; }
        [Display(Name = "عکس")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string ImgName { get; set; }
        public int ProductId { get; set; }


        public Product.Products Product { get; set; }
    }
}
