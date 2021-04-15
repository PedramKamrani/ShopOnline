using DataLayer.Entites.Vairty;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entites.Order
{
   public class ShipmentDetail
    {
        [Key]
        public int ShipmentDetailId { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public int SumPrice { get; set; }
        public int Discount { get; set; }
        public int SumPriceAfterDiscount { get; set; }
        public int UnitDiscount { get; set; }
        public bool StorePlace { get; set; }
        public byte DiscountType { get; set; }

        public int VariantId { get; set; }
        public int ShipmmentId { get; set; }

        public Vairty.Variant Variant { get; set; }
        public Shipment Shipmment { get; set; }
      public List<VariantVoteDetial> VariantVoteDetials { get; set; }
    }
}
