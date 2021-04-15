using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Entites.Product.Comment
{
   public class UserCommentRating
    {
        [Key]
        public int UserCommentRatingId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int RatingAttributeId { get; set; }
        [Display(Name = "مقدار")]
        public byte Value { get; set; }

        [ForeignKey("ProductId")]
        public Product.Products Products { get; set; }
        [ForeignKey("UserId")]
        public User.User User { get; set; }
        [ForeignKey("RatingAttributeId")]
        public RatingAttributs RatingAttributs { get; set; }
    }
}
