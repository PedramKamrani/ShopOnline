using DataLayer.Entites.CategoryData;
using DataLayer.Entites.Promotion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entites.Promotion
{
    public class Promotions
    {
        [Key]
        public int PromotionId { get; set; }
        public byte Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DateProductAdd { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }
        public int CmpId { get; set; }


        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }

        public Categores Category { get; set; }
        public Brand.Brand Brand { get; set; }
        public List<VariantPromotion> VariantPromotions { get; set; }
    }
}
