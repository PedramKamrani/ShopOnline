using CorService.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorService.Services.IService
{
   public interface ICommentService
    {
        Tuple<List<CommentForUserViewModel>, List<ReviewRatingViewModel>, int> GetCommentForUser(int productid, int take);
        List<CommentForUserViewModel> GetCommentByFilter(int productid, int pagenumber, int sort, int take);
    }
}
