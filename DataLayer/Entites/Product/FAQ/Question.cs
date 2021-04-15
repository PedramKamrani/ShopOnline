using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Entites.Product.FAQ
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }
        [Display(Name = "متن سوال")]
        [MaxLength(1000, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string QuestionText { get; set; }
        public int UserId { get; set; }
        [Display(Name = "تاریخ ایجاد")]
        public DateTime CreateDate { get; set; }
        public bool IsConfirm { get; set; }
        public int AnswerCount { get; set; }
        public int ProductId { get; set; }
        public bool IsNotifiAnswer { get; set; }

        [ForeignKey("ProductId")]
        public Products Products { get; set; }
        [ForeignKey("UserId")]
        public User.User User { get; set; }
        public List<Answer> Answers { get; set; }

    }
}
