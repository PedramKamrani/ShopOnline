using CorService.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorService.Services.IService
{
   public interface IFAQService
    {
        List<FAQShowUserViewModel> GetFAQ(int Productid, int pageid, int sort, int take);
        int FAQCount(int productid);
    }
}
