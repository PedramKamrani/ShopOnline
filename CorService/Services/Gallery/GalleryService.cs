using DataLayer.Context;
using DataLayer.Entites.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CorService.Services.Gallery
{
   public class GalleryService: IGalleryServeice
    {
        DigikalaContext _Context;
        public GalleryService(DigikalaContext Context)
        {
            _Context = Context;
        }
        public List<ProductImage> GetProductImagesForAdmin(int id)
        {
            return _Context.ProductImages.Where(pi => pi.ProductId == id).ToList();
        }
        public ProductImage FindImageForAdmin(int id)
        {
            return _Context.Find<ProductImage>(id);
        }
        public bool AddProductImage(ProductImage image)
        {
            try
            {
                _Context.Add(image);
                _Context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteProductImage(ProductImage image)
        {
            _Context.Remove(image);
            int res = _Context.SaveChanges();
            if (res > 0)
                return true;
            return false;
        }
    }
}
