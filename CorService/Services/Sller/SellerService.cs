using CorService.Services.IService;
using CorService.ViewModels.Seller;
using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CorService.Services.Sller
{
   public class ISellerService:ISellerService1
    {
        DigikalaContext _Context;
        public ISellerService(DigikalaContext Context)
        {
            _Context = Context;
        }
        public List<SellerViewModel> GetSellerById(List<int> sellerid)
        {
            return _Context.Sellers.Where(s => sellerid.Contains(s.SellerId))
                .Select(s => new SellerViewModel
            {
                    Name = s.Name,
                    SellerId = s.SellerId,
                    DeliveryTime = s.DeliveryTime,
                    NoReturend = s.NoReturend,
                    PostingWarranty = s.PostingWarranty,
                    RegisterDate = s.RegisterDate.ToString(),
                    TimleySupply = s.TimleySupply,
                    Vote = s.Vote
                }).ToList();
        }
    }
}
