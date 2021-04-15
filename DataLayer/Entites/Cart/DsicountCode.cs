using DataLayer.Entites.Order;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Entites.Cart
{
   public class DsicountCode
    {
        [Key]
        public int DsicountCodeId { get; set; }
        [MaxLength(10)]
        public string Code { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Value { get; set; }
        public int? MinOrderAmount { get; set; }
        public int? MaxUseCount { get; set; }
        public bool ForFirstOrder { get; set; }

        public int? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public CategoryData.Categores Category { get; set; }
       public List<PaymentDetail> paymentDetails { get; set; }

    }
}
