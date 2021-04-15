using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entites.Banner
{
   public class BannerImage
    {
        [Key]
        public int BannerImageId { get; set; }
        [Display(Name = "عنوان")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیشتر از {1} باشید")]
        public string Title { get; set; }
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیشتر از {1} باشید")]
        public string ImageName { get; set; }
        [Display(Name = "لینک")]
        [MaxLength(250, ErrorMessage = "مقدار {0} نباید بیشتر از {1} باشید")]
        public string Link { get; set; }
        public byte Discount { get; set; }
        public int? Sort { get; set; }
        [MaxLength(10)]
        public string Color { get; set; }
        public int BannerId { get; set; }

        public Banner.Banners Banner { get; set; }
    }
}
