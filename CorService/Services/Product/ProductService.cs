using CorService.Services.IService;
using CorService.ViewModels.Product;
using DataLayer.Context;
using DataLayer.Entites.Product;
using DataLayer.Entites.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CorService.Services.Product
{
    public class ProductService : IProductService
    {
        DigikalaContext _Context;
        public ProductService(DigikalaContext Context)
        {
            _Context = Context;
        }
        public List<ProductDetailUserViewModel> GetAllProduct()
        {
            return _Context.Products.Select(p=>new ProductDetailUserViewModel
            { 
                FaTitle=p.FaTitle,
                ImgName=p.ImgName,
                price=p.Weight,
                ProductId=p.ProductId
            }
            ).ToList();
        }
        public Products FindProductId(int id)
        {
            return _Context.Find<Products>(id);
        }
        public List<Products> GetAllProductForYou()
        {
            return _Context.Products.OrderBy(p=>p.CreteDate).Take(4).ToList();
        }

        public ProductDetailUserViewModel GetProductDetailUser(int id)
        {
            IQueryable<ProductDetailUserViewModel> products = (from p in _Context.Products
                                                               join c in _Context.Categories
                                                               on p.CategoryID equals c.CategoryId
                                                               join b in _Context.Brands
                                                               on p.BrandID equals b.BrandId
                                                               where (p.ProductId == id)
                                                               select new ProductDetailUserViewModel
                                                               {
                                                                   FaTitle = p.FaTitle,
                                                                   EnTitle = p.EnTitle,
                                                                   ImgName = p.ImgName,
                                                                   price=p.Weight,
                                                                   BrandName = b.FaTitle,
                                                                   CategoryName = c.FaTitle,
                                                                   ProductId=p.ProductId                                                            
                                                               });
            return products.FirstOrDefault();
        }

        public ProductReviewViewModel GetProductReview(int ProductId)
        {
            ProductReviewViewModel reviwe = _Context.ProductRaviews.Where(p => p.ProductId == ProductId).
                Select(p => new ProductReviewViewModel
                {
                    Suammry=p.Summary,
                    Negative=p.Negative,
                    Psitive=p.Positive,
                    Review=p.Review,
                    ShortReview=p.ShortReview
                }).SingleOrDefault();
            if (reviwe != null)
            {
                List<ReviewRatingViewModel> ratting = (from r in _Context.ProductReviewRatings
                                                       join att in _Context.RatingAttributs on r.RatingAttributeId
                                                       equals att.RatingAttributeId
                                                       where (r.ProductId == ProductId)
                                                       select new ReviewRatingViewModel
                                                       {
                                                           Title = att.Title,
                                                           Value = r.Value
                                                       }).ToList();
                reviwe.ReviewRatingViewModels = ratting;
                return reviwe;
            }
            return reviwe;
        }

        public List<ProductPropertyUserViewModel> GetProperty(int ProductId)
        {
            var proprty = (from p in _Context.ProductProperties
                           join v in _Context.PropertyValues on p.PropertyValueId equals v.PropertyValueId
                           join n in _Context.ProprtyNames on v.PropertyNameId equals n.PropertyNameId
                           join g in _Context.ProprtyGroups on n.PropertyGroupId equals g.PropertyGroupId
                           where (p.ProductId == ProductId)
                           select new ProductPropertyUserViewModel
                           {
                               GroupName=g.Title,
                               PropertValue=v.Value,
                               PropertyName=n.Title

                           }).ToList();
            return proprty;
        }
        public Tuple<int,List<ProductListViewModel>> GetProductsForAdmin(string serchText,int pagenumber,int take)
        {
            int skip = (pagenumber-1) * take;
            IQueryable<ProductListViewModel> qury= _Context.Products.
                Where(p=>EF.Functions.Like(p.EnTitle,"%"+serchText+"%")||EF.Functions.Like(p.FaTitle, "%" + serchText + "%"))
                .Select(p => new ProductListViewModel
            {
                Id = p.ProductId,
                FaTitle = p.FaTitle,
                Image = p.ImgName
            });
            return Tuple.Create(qury.Count(),qury.Skip(skip).Take(take).ToList());
        }
        public int AddProduct(Products products)
        {
            _Context.Add(products);
             _Context.SaveChanges();
            
            return products.ProductId;
        }
        public void AddProductFavirty(int id)
        {
          var pro= _Context.UserProductFovorites.Select(u=>new UserProductFovorites 
          {
              ProductId=id,
             
          });
            
        }
    }
}
