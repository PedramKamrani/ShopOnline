using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entites.Cart
{
   public class Cart
    {
        [Key]
        public int CartId { get; set; }
        [MaxLength(200)]
        public string Coockie { get; set; }
        public int? UserId { get; set; }
        public DateTime UpdateDate { get; set; }
        public int? AddressId { get; set; }
        public bool ShippingType { get; set; }

        public User.User User { get; set; }
        public List<CartDetail> CartDetails { get; set; }
        //public Address.UserAddress Address { get; set; }
    }
}
