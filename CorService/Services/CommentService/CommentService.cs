using CorService.Services.IService;
using CorService.ViewModels.Product;
using DataLayer.Context;
using DataLayer.Entites.Product.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CorService.Services.CommentService
{
    public class CommentService : ICommentService
    {
        DigikalaContext _Context;
        public CommentService(DigikalaContext Context)
        {
            _Context = Context;
        }
        public Tuple<List<CommentForUserViewModel>, List<ReviewRatingViewModel>, int> GetCommentForUser(int productid, int take)
        {
            IQueryable<CommentForUserViewModel> comment = (from c in _Context.Comments
                                                           join u in _Context.Users on c.UserId equals u.UserId
                                                           where c.ProductId == productid
                                                           select new CommentForUserViewModel
                                                           {
                                                               CommentId = c.CommentId,
                                                               CommentTitle = c.CommentTitle,
                                                               CommentText = c.CommentText,
                                                               Positive = c.Positive,
                                                               Negative = c.Negative,
                                                               Like = c.CommentLike,
                                                               DisLike = c.CommentDisLike,
                                                               CreateDate = c.CreateDate,
                                                               UserName = u.FullName
                                                           });
            var count = comment.Count();

            List<ReviewRatingViewModel> rating = (from c in _Context.CommentRatings
                                                  join r in _Context.RatingAttributs on c.RatingAttributeId equals r.RatingAttributeId
                                                  select new ReviewRatingViewModel
                                                  {
                                                      Title = r.Title,
                                                      Value = c.Value
                                                  }).ToList();

            return Tuple.Create(comment.Take(take).ToList(), rating.ToList(), count);
        }

        public List<CommentForUserViewModel> GetCommentByFilter(int productid,int pagenumber,int sort,int take)
        {
            int skip = (pagenumber - 1) * take;
            IQueryable<Comment> comments = _Context.Comments.Where(c => c.ProductId == productid);
            if (sort == 2)
               comments= comments.OrderByDescending(c => c.CommentLike);
            if (sort == 3)
                comments = comments.OrderByDescending(c => c.CreateDate);
            List<CommentForUserViewModel> commentlist = comments.Select(c => new CommentForUserViewModel
            {
                CommentId=c.CommentId,
                CommentText=c.CommentText,
                CommentTitle=c.CommentTitle,
                CreateDate=c.CreateDate,
                Like=c.CommentLike,
                DisLike=c.CommentDisLike,
                Negative=c.Negative,
                Positive=c.Positive,
                UserName=c.User.FullName
            }).Skip(skip).Take(take).ToList();
            return commentlist;
        }
    }
}
