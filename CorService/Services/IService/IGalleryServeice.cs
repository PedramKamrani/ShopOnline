using DataLayer.Entites.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorService.Services
{
   public interface IGalleryServeice
    {
        List<ProductImage> GetProductImagesForAdmin(int id);
        ProductImage FindImageForAdmin(int id);
        bool AddProductImage(ProductImage image);
        bool DeleteProductImage(ProductImage image);
    }
}
