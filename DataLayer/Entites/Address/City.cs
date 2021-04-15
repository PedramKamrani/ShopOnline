using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entites.Address
{
   public class City
    {
        [Key]
        public int CityId { get; set; }

        [Display(Name = "نام شهر")]
        [MaxLength(30, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        public string CityName { get; set; }

        public int ProvinceId { get; set; }
        public List<UserAddress> UserAddresses { get; set; }
        public Province Province { get; set; }
    }
}
