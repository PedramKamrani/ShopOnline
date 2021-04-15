using System;
using System.Collections.Generic;
using System.Text;
using CorService.ViewModels.Categorey;
using DataLayer.Entites.CategoryData;
using DataLayer.Entites.Product;

namespace CorService.Services.IService
{
    public interface ICategoryService
    {
        Categores GetCategoresByName(string CatgoreyName);
        List<Categores> GetSubCategoryById(int Parentid);
        ShowCategoriesForUserViewModel GetSubCategoryByName(string catname);
        List<CategoryForBrandViewModel> GetCategoryByBrandId(int BrandId);
        List<Categores> GetCategoresForAdmin();
        Categores GetFindById(int id);
        bool DeleteCategory(Categores categores);
        List<GetCategoryForAddViewModel> GetCategoryForAdd();
        void AddOrUpdateParentCategory(int subid, List<int> parentid);
        bool AddCategory(Categores categores, List<int> parentid);
        List<int> GetSubCategory(int id);
        bool IsExsisitCategory(int Catid, string entitle);
        bool UpdateCategory(Categores categores, List<int> parentlist);
        List<int> GetParentCategory(int id);
        bool AddProductCategory(List<ProductCategory> productCategories);
    }
}
