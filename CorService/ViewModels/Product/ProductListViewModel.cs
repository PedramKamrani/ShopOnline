using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CorService.ViewModels.Product
{
    public class ProductListViewModel
    {
        [Display(Name = "کد محصول")]
        public int Id { get; set; }

        [Display(Name = "عنوان")]
        public string FaTitle { get; set; }
        [Display(Name = "عکس")]
        public string Image { get; set; }
        [Display(Name = "پول")]
        public int? Price { get; set; }
    }

    public class AddProductViewModel
    {
        [Display(Name = "عنوان فارسی")]
        [MaxLength(300, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string FaTitle { get; set; }

        [Display(Name = "عنوان انگلیسی")]
        [MaxLength(300, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string EnTitle { get; set; }

        [Display(Name = "تصویر اصلی")]
        public IFormFile ImgName { get; set; }

        [Display(Name = "دسته بندی")]
        public int CategoryID { get; set; }
        [Display(Name = " برند")]
        public int BrandID { get; set; }

        [Display(Name = " انتشار")]
        public bool IsPublished { get; set; }
    }

}
