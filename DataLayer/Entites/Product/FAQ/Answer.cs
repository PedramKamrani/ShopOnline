using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Entites.Product.FAQ
{
  public class Answer
    {
        [Key]
        public int AnswerId { get; set; }
        [Display(Name = "متن پاسخ")]
        [MaxLength(1000, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string AnswerText { get; set; }
        public int QuestionId { get; set; }
        public int UserId { get; set; }
        public int AnswerLike { get; set; }
        public int AnswerDisLike { get; set; }
        public bool IsConfirm { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        public DateTime CreateDate { get; set; }

        [ForeignKey("QuestionId")]
        public Question Question { get; set; }
        [ForeignKey("UserId")]
        public User.User User { get; set; }
        public List<AnswerLike> AnswerLikes { get; set; }
    }
}
