using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Entites.Product.Comment
{
   public class CommentLike
    {
        [Key]
        public int CommentLikeId { get; set; }
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public bool Type { get; set; }

        [ForeignKey("CommentId")]
        public Comment Comment { get; set; }


    }
}
