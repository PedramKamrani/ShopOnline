using System;
using System.Collections.Generic;
using System.Text;

namespace CorService.ViewModels.Varint
{
   public class VarintViewModel
    {
        public int VariantId { get; set; }
        public int MainPrice { get; set; }
        public int SellerPrice { get; set; }
        public int Count { get; set; }
        public int DigikalaCount { get; set; }
        public int VoteCount { get; set; }
        public string PurchaseConsentPercent { get; set; }
        public byte TotallySatisfied { get; set; }
        public byte Satisfied { get; set; }
        public byte Neutral { get; set; }
        public int DisSatisfied { get; set; }
        public int TotallyDisSatisfied { get; set; }
        public int SellerId { get; set; }
        public string Guarantee { get; set; }
        public string ProductOption { get; set; }
        public string ProductOptionCode { get; set; }

        public byte DiscountType { get; set; }
        public DateTime DiscountEndDate { get; set; }
    }
}
