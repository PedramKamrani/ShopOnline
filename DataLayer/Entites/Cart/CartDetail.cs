using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entites.Cart
{
    public class CartDetail
    {
        [Key]
        public int CartDetailId { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public int CartId { get; set; }
        public bool IsActiveCart { get; set; }

        public int VariantId { get; set; }
        public Vairty.Variant Variant { get; set; }
        public Cart Cart { get; set; }
    }
}
