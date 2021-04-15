using DataLayer.Entites.Cart;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entites.Order
{
   public class PaymentDetail
    {
        [Key]
        public int PaymentDetailId { get; set; }
        public int OrderId { get; set; }
        public byte Type { get; set; }
        public int Price { get; set; }
        public DateTime Date { get; set; }
        public bool State { get; set; }
        [MaxLength(50)]
        public string RefIf { get; set; }

        public int? DiscountCodeId { get; set; }
        public int? GiftCartId { get; set; }

        public Order Order { get; set; }
        public DsicountCode DiscountCode { get; set; }
        public GiftCard GiftCard { get; set; }
    }
}
