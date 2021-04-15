using CorService.ViewModels.Brand;
using CorService.ViewModels.Categorey;
using DataLayer.Entites.Brand;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorService.Services.IService
{
   public interface IBrandService
    {
        Brand FindBrandById(int id);
        int Brandcunt();
        List<BrandForShowAdminViewModel> BrandForAdmin(int pagenum = 1);
        bool AddBrand(Brand brand);
        bool EditBrand(Brand brand);
        Brand GetBrandByName(string brandTitle);
        List<BrandForAddProductViewModel> GetBrandForAddProduct();
        bool DeleteBrand(Brand brand);


    }
}
