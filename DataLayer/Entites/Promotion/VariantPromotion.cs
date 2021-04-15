using DataLayer.Entites.Vairty;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entites.Promotion
{
   public class VariantPromotion
    {
        [Key]
        public int VariantPromotionId { get; set; }
        public int Price { get; set; }
        public byte Percent { get; set; }
        public int Count { get; set; }
        public int? MaxOrderCount { get; set; }
        public int ReminaingCount { get; set; }
        public byte Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }


        public int VariantId { get; set; }
        public int PromotionId { get; set; }
        public Variant Variant { get; set; }
        public Promotion.Promotions Promotions { get; set; }
    }
}
