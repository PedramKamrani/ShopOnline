using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Entites.Product.Comment
{
   public class Comment
    {

        [Key]
        public int CommentId { get; set; }

        [Display(Name = "عنوان نظر")]
        [MaxLength(150, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string CommentTitle { get; set; }
        [Display(Name = "متن نظر")]
        [MaxLength(3000, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string CommentText { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "نقاط قوت")]
        [MaxLength(1000, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        public string Positive { get; set; }

        [Display(Name = "نقاط ضعف")]
        [MaxLength(1000, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        public string Negative { get; set; }

        [Display(Name = "تایید شده")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public bool IsConfirm { get; set; }

        [Display(Name = "لایک")]
        public int CommentLike { get; set; }

        [Display(Name = "دیسلایک")]
        public int CommentDisLike { get; set; }

        public int ProductId { get; set; }
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User.User User { get; set; }
        [ForeignKey("ProductId")]
        public Product.Products Products { get; set; }
        public List<CommentLike> Comments { get; set; }
    }
}
