using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entites.Vairty
{
   public class ProductOption
    {
        [Key]
        public int ProductOptionId { get; set; }
        public byte Type { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        [MaxLength(15)]
        public string Value { get; set; }

        public List<Variant> Variants { get; set; }
        public List<ProductPrice> ProductPrices { get; set; }
    }
}
