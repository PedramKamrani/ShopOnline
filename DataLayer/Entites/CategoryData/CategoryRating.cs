using DataLayer.Entites.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Entites.CategoryData
{
   public class CategoryRating
    {
        [Key]
        public int CategoryRatingId { get; set; }
        public int CategoryId { get; set; }
        public int RatingAttributeId { get; set; }

        [ForeignKey("RatingAttributeId")]
        public RatingAttributs RatingTitle { get; set; }
        [ForeignKey("CategoryId")]
        public CategoryData.Categores Categores { get; set; }
    }
}
