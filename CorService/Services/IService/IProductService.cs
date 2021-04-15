using System;
using System.Collections.Generic;
using System.Text;
using CorService.ViewModels.Product;
using DataLayer.Entites.Product;

namespace CorService.Services.IService
{
   public interface IProductService
    {
        List<ProductDetailUserViewModel> GetAllProduct();
        Products FindProductId(int id);
        List<Products> GetAllProductForYou();
        ProductDetailUserViewModel GetProductDetailUser(int id);
        ProductReviewViewModel GetProductReview(int ProductId);
        List<ProductPropertyUserViewModel> GetProperty(int ProductId);
        Tuple<int, List<ProductListViewModel>> GetProductsForAdmin(string serchText, int pagenumber, int take);
        int AddProduct(Products products);
    }
}
