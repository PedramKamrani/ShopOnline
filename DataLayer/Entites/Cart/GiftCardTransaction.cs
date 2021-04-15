using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entites.Cart
{
   public class GiftCardTransaction
    {
        [Key]
        public int GiftCardTransactionId { get; set; }
        public int GiftCardId { get; set; }
        public int OrderId { get; set; }
        public int Price { get; set; }

        public Order.Order Order { get; set; }
        public GiftCard GiftCard { get; set; }
    }
}
