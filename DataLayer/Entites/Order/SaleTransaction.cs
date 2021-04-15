using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entites.Order
{
   public class SaleTransaction
    {
        [Key]
        public int SaleTransactionId { get; set; }
        public DateTime Date { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public int UnitDiscount { get; set; }
        public int SumPriceAfterDiscount { get; set; }


        public int VariantId { get; set; }
        public int OrderId { get; set; }
        public Vairty.Variant Variant { get; set; }
        public Order Order { get; set; }
    }
}
