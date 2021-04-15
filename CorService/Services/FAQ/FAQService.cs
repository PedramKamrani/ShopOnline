using CorService.Services.IService;
using CorService.ViewModels.Product;
using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CorService.Services.FAQ
{
   public class FAQService:IFAQService
    {
        DigikalaContext _Context;
        public FAQService(DigikalaContext Context)
        {
            _Context = Context;
        }
        public List<FAQShowUserViewModel> GetFAQ(int Productid, int pageid, int sort, int take)
        {
            int skip = (pageid - 1) * take;
            var qury = _Context.Questions.Where(p => p.ProductId == Productid &&p.IsConfirm==true);
            switch (sort)
            {
                case 1:
                    qury = qury.OrderByDescending(p => p.CreateDate);
                    break;
                case 2:
                    qury = qury.OrderByDescending(p => p.AnswerCount);
                    break;
                case 3:
                    qury = qury.OrderByDescending(p => p.UserId);
                    break;

            }
            var q = (from qus in _Context.Questions.Skip(skip).Take(take)
                     join u in _Context.Users on qus.UserId equals u.UserId
                     join a in _Context.Answers on qus.QuestionId equals a.QuestionId
                     into answer
                     from a in answer.DefaultIfEmpty()
                     join answeruser in _Context.Answers on a.UserId equals answeruser.UserId into aus
                     from answeruser in aus.DefaultIfEmpty()

                     select new FAQShowUserViewModel
                     {
                         QuestionID = qus.QuestionId,
                         QuestionText = qus.QuestionText,
                         QuestionDate = qus.CreateDate,
                         AnswerCount = qus.AnswerCount,
                         QuestionName = qus.User.FullName,
                         Answer = new AnswerViewModel
                         {
                             AnswerId = a.AnswerId,
                             AnswerText = a.AnswerText,
                             AnswerDate = a.CreateDate.ToString(),
                             AnswerUser = a.User.FullName,
                             Dislike = a.AnswerDisLike,
                             Like = a.AnswerLike
                         }
                     }).ToList();
            List<FAQShowUserViewModel> l = new List<FAQShowUserViewModel>();
            return q;
        }
        public int FAQCount(int productid)
        {
            return _Context.Questions.Where(c => c.ProductId == productid).Count();
        }
    }
}
