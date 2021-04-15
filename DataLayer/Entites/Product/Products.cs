using DataLayer.Entites.Product.FAQ;
using DataLayer.Entites.User;
using DataLayer.Entites.Vairty;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Entites.Product
{
   public class Products
    {
        [Key]
        public int ProductId { get; set; }
        [Display(Name = "عنوان فارسی")]
        [MaxLength(300, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string FaTitle { get; set; }

        [Display(Name = "عنوان انگلیسی")]
        [MaxLength(300, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string EnTitle { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateTime CreteDate { get; set; }

        [Display(Name = "تاریخ بروزرسانی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateTime UpdateDate { get; set; }

        [Display(Name = "عکس اصلی")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string ImgName { get; set; }
        public int Weight { get; set; }
        public int CategoryID { get; set; }
        public int BrandID { get; set; }
        public bool IsPublish { get; set; }
        
        public Brand.Brand Brand { get; set; }
        [ForeignKey("CategoryID")]
        public CategoryData.Categores Categores { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public List<ProductRaview> ProductRaviews { get; set; }
        public List<ProductReviewRating> ProductReviewRatings { get; set; }
        public List<ProductProperty> ProductProperties { get; set; }
        public List<Comment.Comment> Comments { get; set; }
        public List<Comment.CommentRating> CommentRatings { get; set; }
        public List<Comment.UserCommentRating> UserCommentRatings { get; set; }
        public List<Question> Questions { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
        public List<UserProductFovorites> UserProductFovorites { get; set; }
        public List<Variant> Variants { get; set; }
        public List<OrderProuduct.DetailesOrder> DetailesOrders { get; set; }


    }
}
