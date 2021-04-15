using System;
using System.Collections.Generic;
using System.Text;

namespace CorService.ViewModels.Product
{
  public class FAQShowUserViewModel
    {

        public int QuestionID { get; set; }
        public string QuestionText { get; set; }
        public int AnswerCount { get; set; }
        public DateTime QuestionDate { get; set; }
        public string QuestionName { get; set; }
        public AnswerViewModel Answer { get; set; }
    }
}
