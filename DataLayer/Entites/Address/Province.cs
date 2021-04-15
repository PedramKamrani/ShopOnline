using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entites.Address
{
   public class Province
    {
        [Key]
        public int ProvinceId { get; set; }

        [Display(Name = "نام استان")]
        [MaxLength(30, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        public string ProvinceName { get; set; }
        public List<UserAddress> UserAddresses { get; set; }
        public List<City> Cities { get; set; }
    }
}
