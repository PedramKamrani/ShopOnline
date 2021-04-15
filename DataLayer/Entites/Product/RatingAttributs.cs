using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entites.Product
{
   public class RatingAttributs
    {
        [Key]
        public int RatingAttributeId { get; set; }
        [Display(Name = "نام ")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Title { get; set; }

        public List<CategoryData.CategoryRating> CategoryRatings { get; set; }
        public List<Comment.CommentRating> CommentRatings { get; set; }
        public List<Comment.UserCommentRating> UserCommentRatings { get; set; }
    }
}
