using DataLayer.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Entites.Product
{
   public class ProductReviewRating
    {
        [Key]
        public int ProductReviewRatingId { get; set; }
        public int ProductId { get; set; }
        public int RatingAttributeId { get; set; }
        public byte Value { get; set; }

        [ForeignKey("ProductId")]
        public Product.Products Products { get; set; }

        public RatingAttributs RatingAttribute { get; set; }
    }
}
