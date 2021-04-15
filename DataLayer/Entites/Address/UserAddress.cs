using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entites.Address
{
   public class UserAddress
    {
        [Key]
        public int UserAddressId { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string FullName { get; set; }

        [Display(Name = "شماره تلفن")]
        [MaxLength(11, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Phone { get; set; }

        [Display(Name = "استان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int ProvinceId { get; set; }

        [Display(Name = "شهر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int CityId { get; set; }


        [Display(Name = "آدرس پستی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        public string PostalAddress { get; set; }

        [Display(Name = "کد پسنی")]
        [MaxLength(10, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string PostalCode { get; set; }


        [MaxLength(20, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        public string Lat { get; set; }

        [MaxLength(20, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        public string Lng { get; set; }

        public int UserId { get; set; }


        public User.User User { get; set; }
        public List<User.User> Users { get; set; }
        public City City { get; set; }
        public Province Province { get; set; }
        //public List<Cart.Cart> Carts { get; set; }
    }
}
