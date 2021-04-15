using CorService.Services.IService;
using CorService.ViewModels.Varint;
using DataLayer.Context;
using DataLayer.Entites.Promotion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CorService.Services.VarintS
{
   public class VarintService:IVarintService
    {
        DigikalaContext _context;
        public VarintService(DigikalaContext context)
        {
            _context = context;
        }
        public List<VarintViewModel> GetVarintByProudctId(int Productid)
        {
            var qury = _context.Variants.Where(v => v.ProductId == Productid && (v.Count > 0) || (v.storeOnlineCount > 0));
            var varints = (from q in qury
                           join g in _context.Guarantees on q.GuaranteeId equals g.GuaranteeId
                           join po in _context.ProductOptions on q.ProductOptionId equals po.ProductOptionId
                           join vp in _context.VariantPromotions on q.VariantId equals vp.VariantId
                           into varleft from v in _context.Variants
                           select new VarintViewModel
                           {
                               VariantId = q.VariantId,
                               Count = q.Count,
                               DigikalaCount = q.storeOnlineCount,
                               DisSatisfied = q.DisSatisfied,
                               TotallyDisSatisfied = q.TotallyDisSatisfied,
                               Satisfied = q.Satisfied,
                               Neutral = q.Neutral,
                               TotallySatisfied = q.TotallySatisfied,
                               VoteCount = q.VoteCount,
                               PurchaseConsentPercent = q.PurchaseConsentPercent,
                               Guarantee = g.Title,
                               ProductOption = po.Name,
                               ProductOptionCode = po.Value,
                               //DiscountType = v.Type,
                               //DiscountEndDate = v.en,
                               SellerId = (int)q.SellerId,
                               MainPrice = q.Price,
                               SellerPrice = v.Price > 0 ? v.Price : q.SepcialPrice > 0 ? q.SepcialPrice : q.Price

                           }
                          ).ToList();
            return varints;
        }
    }
}
