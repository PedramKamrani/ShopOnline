using System;
using System.Collections.Generic;
using System.Text;

namespace CorService.ViewModels.Product
{
   public class AnswerViewModel
    {
        public int? AnswerId { get; set; }
        public string AnswerText { get; set; }
        public int? Like { get; set; }
        public int? Dislike { get; set; }
        public string AnswerDate { get; set; }
        public string AnswerUser { get; set; }
    }
}
