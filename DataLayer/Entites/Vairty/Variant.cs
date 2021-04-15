using DataLayer.Entites.Order;
using DataLayer.Entites.Product;
using DataLayer.Entites.Promotion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Entites.Vairty
{
   public class Variant
    {
        [Key]
        public int VariantId { get; set; }
        public int Price { get; set; }
        public int SepcialPrice { get; set; }
        public int Count { get; set; }
        public int storeOnlineCount { get; set; }
        public int? MaxOrderCount { get; set; }

        public int VoteCount { get; set; }
        public string PurchaseConsentPercent { get; set; }

        public byte TotallySatisfied { get; set; }
        public byte Satisfied { get; set; }
        public byte Neutral { get; set; }
        public int DisSatisfied { get; set; }
        public int TotallyDisSatisfied { get; set; }
        public int ReserveCount { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }



        public int ProductOptionId { get; set; }
        public int GuaranteeId { get; set; }
        public int? SellerId { get; set; }
        public int ProductId { get; set; }

        public ProductOption productOption { get; set; }
        [ForeignKey("GuaranteeId")]
        public Guarantee Guarantee { get; set; }
        
        public Seller.Seller Seller { get; set; }
        [ForeignKey("ProductId")]
        public Products Product { get; set; }

        public List<ProductPrice> ProductPrices { get; set; }
        public List<Cart.Cart> Carts { get; set; }
        public List<ShipmentDetail> Shipmments { get; set; }
        public List<VariantPromotion> VariantPromotions { get; set; }
        //public List<SaleTransaction> SaleTransactions { get; set; }
    }
}
