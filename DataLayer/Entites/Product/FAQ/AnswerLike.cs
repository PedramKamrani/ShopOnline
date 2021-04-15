using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Entites.Product.FAQ
{
   public class AnswerLike
    {
        [Key]
        public int AnswerLikeId { get; set; }
        public int UserId { get; set; }
        public int AnswerId { get; set; }
        public bool Type { get; set; }

        [ForeignKey("AnswerId")]
        public Answer Answer { get; set; }
        [ForeignKey("UserId")]
        public User.User User { get; set; }
    }
}
