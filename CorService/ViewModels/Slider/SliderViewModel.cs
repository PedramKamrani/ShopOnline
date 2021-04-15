using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CorService.ViewModels.Slider
{
  public class SliderViewModel
    {
        public class CreateSliderViewModel
        {

            [Display(Name = "توضیحات")]
            [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
            [MaxLength(50, ErrorMessage = "{0}نباید بیشتر از {1} باشد")]
            public string Descrption { get; set; }

            [Display(Name = "عکس دسکتاپ")]
            [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
            public IFormFile DesktopImg { get; set; }

            [Display(Name = "عکس موبایل")]
            [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
            public IFormFile MobileImg { get; set; }



            [Display(Name = "ترتیب")]
            [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
            public int sort { get; set; }

            [Display(Name = "لینک")]
            [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
            [MaxLength(150, ErrorMessage = "{0}نباید بیشتر از {1} باشد")]
            public string Link { get; set; }
        }

        public class EditSliderViewModel
        {
            public int sliderid { get; set; }
            [Display(Name = "توضیحات")]
            [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
            [MaxLength(50, ErrorMessage = "{0}نباید بیشتر از {1} باشد")]
            public string Descrption { get; set; }


            [Display(Name = "عکس دسکتاپ")]
            public IFormFile DesktopImg { get; set; }

            [Display(Name = "عکس موبایل")]
            public IFormFile MobileImg { get; set; }

            public string CurrentImgName { get; set; }


            [Display(Name = "ترتیب")]
            [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
            public int sort { get; set; }

            [Display(Name = "لینک")]
            [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
            [MaxLength(150, ErrorMessage = "{0}نباید بیشتر از {1} باشد")]
            public string Link { get; set; }
        }
    }
}
