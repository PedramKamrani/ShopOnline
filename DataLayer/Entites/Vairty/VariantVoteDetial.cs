using DataLayer.Entites.Order;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entites.Vairty
{
   public class VariantVoteDetial
    {
        [Key]
        public int VariantVoteDetialId { get; set; }
        public byte Vote { get; set; }
        public int ShipmentDetailId { get; set; }

        public ShipmentDetail OrderDetail { get; set; }
    }
}
