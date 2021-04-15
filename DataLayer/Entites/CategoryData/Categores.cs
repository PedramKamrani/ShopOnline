using DataLayer.Entites.Brand;
using DataLayer.Entites.Cart;
using DataLayer.Entites.CategoryData;
using DataLayer.Entites.Product;
using DataLayer.Entites.Proprty;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entites.CategoryData
{
   public class Categores
    {
        [Key]
        public int CategoryId { get; set; }
        [Display(Name = "عنوان فارسی")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string FaTitle { get; set; }

        [Display(Name = "عنوان انگلیسی")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string EnTitle { get; set; }

        [Display(Name = "عکس")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        public string ImgName { get; set; }

        [Display(Name = "توضیحات")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Descrption { get; set; }
        public bool IsDelete { get; set; }
        public bool IsMain { get; set; }


        public List<SubCategory> parenteCategory { get; set; }
        public List<SubCategory> SubCategory { get; set; }
        public List<BrandCategory> BrandCategories { get; set; }
        public List<Product.Products> Products { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
        public List<ProprtyName> ProprtyNames { get; set; }
        public List<PropertyCategory> PropertyCategories { get; set; }
        public List<CategoryCommsion> CategoryCommsions { get; set; }
        public List<DsicountCode> DsicountCodes { get; set; }
    }
}
