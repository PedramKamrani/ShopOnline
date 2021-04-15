using CorService.ViewModels.Seller;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorService.Services.IService
{
   public interface ISellerService1
    {
        List<SellerViewModel> GetSellerById(List<int> sellerid);
    }
}
