using DataLayer.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Entites.Product.Comment
{
   public class CommentRating
    {

        [Key]
        public int CommentRatingId { get; set; }
        public int ProductId { get; set; }
        public int RatingAttributeId { get; set; }
        [Display(Name = "مقدار")]
        public byte Value { get; set; }

        [ForeignKey("ProductId")]
        public Products product { get; set; }
        [ForeignKey("RatingAttributeId")]
        public RatingAttributs RatingAttribute { get; set; }
    }
}
