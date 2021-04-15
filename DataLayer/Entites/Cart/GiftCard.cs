using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entites.Cart
{
   public class GiftCard
    {
        [Key]
        public int GiftCardId { get; set; }
        [MaxLength(20)]
        public string Code { get; set; }
        public int Amount { get; set; }
        public int Balance { get; set; }

        public int? UserId { get; set; }

        public User.User User { get; set; }
        public List<GiftCardTransaction> GiftCardTransactions { get; set; }
        //public List<PaymentDetail> paymentDetails { get; set; }
    }
}
