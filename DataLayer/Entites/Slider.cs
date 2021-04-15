using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entites
{
    public class Slider
    {
        [Key]
        public int SliderId { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "اسم عکس")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = "{0}نباید بیشتر از {1} باشد")]
        public string ImgName { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = "{0}نباید بیشتر از {1} باشد")]
        public string Descrption { get; set; }

        [Display(Name = "ترتیب")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int sort { get; set; }

        [Display(Name = "لینک")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150, ErrorMessage = "{0}نباید بیشتر از {1} باشد")]
        public string Link { get; set; }
    }
}
