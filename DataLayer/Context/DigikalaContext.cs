using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DataLayer.Entites;
using DataLayer.Entites.CategoryData;
using System.Linq;
using DataLayer.Entites.Brand;
using DataLayer.Entites.Product;
using DataLayer.Entites.Proprty;
using DataLayer.Entites.User;
using DataLayer.Entites.Product.Comment;
using DataLayer.Entites.Product.FAQ;
using DataLayer.Entites.MainMenu;
using DataLayer.Entites.Banner;
using DataLayer.Entites.Address;
using DataLayer.Entites.Seller;
using DataLayer.Entites.Vairty;
using DataLayer.Entites.Promotion;
using DataLayer.Entites.Cart;
using DataLayer.Entites.Order;
using DataLayer.Entites.OrderProuduct;

namespace DataLayer.Context
{
    public class DigikalaContext : DbContext
    {
        public DigikalaContext(DbContextOptions<DigikalaContext> options) : base(options)
        {

        }
        #region Table
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<BrandCategory> BrandCategories { get; set; }
        #endregion
        #region Category
        public DbSet<Categores> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<CategoryRating> CategoryRatings { get; set; }
        public DbSet<CategoryCommsion> CategoryCommsions { get; set; }
        #endregion
        #region Product
        public DbSet<Products> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductRaview> ProductRaviews { get; set; }
        public DbSet<RatingAttributs> RatingAttributs { get; set; }
        public DbSet<ProductReviewRating> ProductReviewRatings { get; set; }
        public DbSet<ProductProperty> ProductProperties { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        
        #endregion
        #region Proprty
        public DbSet<ProprtyGroup> ProprtyGroups { get; set; }
        public DbSet<ProprtyName> ProprtyNames { get; set; }
        public DbSet<PropertyValue> PropertyValues { get; set; }
        public DbSet<PropertyCategory> PropertyCategories { get; set; }
        #endregion
        #region Comment
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentLike> CommentLikes { get; set; }
        public DbSet<CommentRating> CommentRatings { get; set; }
        public DbSet<UserCommentRating> UserComments { get; set; }
        #endregion
        #region FAQ
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<AnswerLike> AnswerLikes { get; set; }
        #endregion
        #region MainMenu
        public DbSet<MainMenu> MainMenus { get; set; }
        #endregion
        #region Banner
        public DbSet<Banners> Banners{get;set;}
        public DbSet<BannerImage> BannerImages{get;set;}
        #endregion
        #region User
        public DbSet<User> Users { get; set; }
        public DbSet<UserProductFovorites> UserProductFovorites { get; set; }
        #endregion
        #region Seller
        public DbSet<Seller> Sellers { get; set; }
        #endregion

        #region Variety
        public DbSet<Variant> Variants { get; set; }
        public DbSet<Guarantee> Guarantees { get; set; }
        public DbSet<ProductOption> ProductOptions { get; set; }
        public DbSet<ProductPrice> ProductPrices { get; set; }
        public DbSet<VariantVoteDetial> VariantVoteDetials { get; set; }
        #endregion
        #region Promotion
        public DbSet<Promotions> Promotions { get; set; }
        public DbSet<VariantPromotion> VariantPromotions { get; set; }
        #endregion
        #region Cart
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }
        public DbSet<DsicountCode> DiscountCodes { get; set; }
        public DbSet<GiftCardTransaction> GiftCardTransactions { get; set; }
        public DbSet<GiftCard> GiftCards { get; set; }
        #endregion
        #region Order
        public DbSet<Order> Orders { get; set; }
        public DbSet<ShipmentDetail> ShipmentDetails { get; set; }
        public DbSet<PaymentDetail> paymentDetails { get; set; }
        public DbSet<Shipment> Shipmments { get; set; }
        public DbSet<SaleTransaction> SaleTransactions { get; set; }
        #endregion
        #region OrderProduct
        public DbSet<OrderProuducts> OrderProuducts { get; set; }
        public DbSet<DetailesOrder> DetailesOrders { get; set; }
        #endregion
        #region Address
        public DbSet<City> Cities { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categores>().HasQueryFilter(c =>!c.IsDelete);
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);
        }
    }
}
