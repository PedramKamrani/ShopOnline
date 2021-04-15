using DataLayer.Entites.Cart;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entites.Order
{
   public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [MaxLength(100)]
        public string RecipientName { get; set; }
        [MaxLength(11)]
        public string RecipientTel { get; set; }
        [MaxLength(150)]
        public string RecipientAddress { get; set; }
        [MaxLength(10)]
        public string RecipientPostalCode { get; set; }

        public int SumAmount { get; set; }
        public int AmountPayable { get; set; }
        public int UserId { get; set; }
        public byte PaymentStatus { get; set; }


        public User.User User { get; set; }
        public List<Shipment> Shipmments { get; set; }
        public List<GiftCardTransaction> GiftCardTransactions { get; set; }
        public List<PaymentDetail> PaymentDetails { get; set; }
        public List<SaleTransaction> SaleTransactions { get; set; }
    }
}
