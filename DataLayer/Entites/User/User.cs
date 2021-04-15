using DataLayer.Entites.Product.Comment;
using DataLayer.Entites.Product.FAQ;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entites.User
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        public string FullName { get; set; }
        
        [Display(Name = "ایمیل")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        public string Email { get; set; }

        [Display(Name = "رمز عبور")]
        [MaxLength(200, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        [Required]
        public string Password { get; set; }

        [Display(Name = "شماره تلفن")]
        [MaxLength(11, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        public string Phone { get; set; }

        [Display(Name = "شماره کارت")]
        [MaxLength(25, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        public string CardNumber { get; set; }

        [Display(Name = "تاریخ ثبت نام")]
        public DateTime RegisterDate { get; set; }

        [Display(Name = "عکس")]
        public byte Avatar { get; set; }

        [Display(Name = "کد فعال سازی تلفن")]
        public int PhoneActiveCode { get; set; }

        [Display(Name = "کد فعال سازی ایمیل")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        public string EmailActiveCode { get; set; }

        [Display(Name = "وضعیت")]
        public bool IsActive { get; set; }
        [Display(Name = "با قوانین سایت موافقم")]
        public bool Terms { get; set; }
        public bool IsDelete { get; set; }
        public int? AddressId { get; set; }
        public int RoleId { get; set; }

        public List<Comment> Comments { get; set; }
        public List<UserCommentRating> UserCommentRatings { get; set; }
        public List<Question> Questions { get; set; }
        public List<Answer> Answers { get; set; }
        public List<AnswerLike> AnswerLikes { get; set; }
        public List<UserProductFovorites> UserProductFovorites { get; set; }
        public List<Cart.Cart> Carts { get; set; }
        public List<Order.Order> Orders { get; set; }
        public List<OrderProuduct.OrderProuducts> OrderProuducts { get; set; }

    }
}
