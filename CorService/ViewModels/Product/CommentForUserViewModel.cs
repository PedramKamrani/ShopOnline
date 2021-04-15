using System;
using System.Collections.Generic;
using System.Text;

namespace CorService.ViewModels.Product
{
   public class CommentForUserViewModel
    {

        public int CommentId { get; set; }
        public string CommentTitle { get; set; }
        public string CommentText { get; set; }
        public string Positive { get; set; }
        public string Negative { get; set; }
        public string UserName { get; set; }
        public int Like { get; set; }
        public int DisLike { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
