using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entites.Vairty
{
   public class ProductPrice
    {
        [Key]
        public int ProductPriceId { get; set; }
        public DateTime SubmitDate { get; set; }
        public int Price { get; set; }
        public int DiscountPrice { get; set; }
        public byte DiscountPercent { get; set; }
        public bool IsAvailable { get; set; }

        public int VariantId { get; set; }
        public int ProductOptionId { get; set; }

        public Variant Variant { get; set; }
        public ProductOption ProductOption { get; set; }
    }
}
