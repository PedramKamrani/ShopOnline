using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entites.Banner
{
   public class Banners
    {
        [Key]
        public int BannerId { get; set; }
        [Display(Name = "عنوان")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیشتر از {1} باشید")]
        public string Title { get; set; }
        [Display(Name = "وضعیت")]
        public bool IsActive { get; set; }

        public List<BannerImage> BannerImages { get; set; }
    }
}
