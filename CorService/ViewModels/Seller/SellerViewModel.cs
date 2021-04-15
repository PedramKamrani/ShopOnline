using System;
using System.Collections.Generic;
using System.Text;

namespace CorService.ViewModels.Seller
{
   public class SellerViewModel
    {
        public int SellerId { get; set; }
        public string Name { get; set; }
        public string RegisterDate { get; set; }
        public string TimleySupply { get; set; }
        public string PostingWarranty { get; set; }
        public string NoReturend { get; set; }
        public string Vote { get; set; }
        public byte DeliveryTime { get; set; }
    }
}
