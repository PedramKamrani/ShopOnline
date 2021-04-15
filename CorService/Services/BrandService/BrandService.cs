using CorService.Services.IService;
using CorService.ViewModels.Brand;
using CorService.ViewModels.Categorey;
using DataLayer.Context;
using DataLayer.Entites.Brand;
using DataLayer.Entites.CategoryData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CorService.Services.BrandService
{
    public class BrandService : IBrandService
    {
        DigikalaContext _context;
        public BrandService(DigikalaContext context)
        {
            _context = context;
        }
        public Brand FindBrandById(int id)
        {
           return _context.Find<Brand>(id);
        }
        public int Brandcunt()
        {
            return _context.Brands.Count();
        }
        public List<BrandForShowAdminViewModel> BrandForAdmin(int pagenum)
        {
            int skip = (pagenum - 1) * 8;
            return _context.Brands.Where(b=>b.IsDelete==false).Select(b => new BrandForShowAdminViewModel
            {
                Id=b.BrandId,
                EnTitle=b.EnTitle,
                FaTitle=b.FaTitle,
                ImageName=b.ImgName
            }).Skip(skip).Take(8).ToList();
        }
        public Brand GetBrandByName(string brandTitle)
        {
            return _context.Brands.FirstOrDefault(b => b.EnTitle == brandTitle);
        }
        public bool AddBrand(Brand brand)
        {
                _context.Add(brand);
               int res= _context.SaveChanges();
                if (res > 0)
                    return true;
                return false;
        }
        public bool EditBrand(Brand brand)
        {
            _context.Update(brand);
            int res = _context.SaveChanges();
            if (res > 0)
                return true;
            return false;
        }
        public List<BrandForAddProductViewModel> GetBrandForAddProduct()
        {
            return _context.Brands.Select(b => new BrandForAddProductViewModel
            {
                Id=b.BrandId,
                Title=b.FaTitle
            }).ToList();
        }
        public bool DeleteBrand(Brand brand)
        {
            _context.Update(brand);
           int res= _context.SaveChanges();
            if(res>0)
            return true;
            return false;
        }
       
    }
}
