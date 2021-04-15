using CorService.Services.IService;
using CorService.ViewModels.Categorey;
using DataLayer.Context;
using DataLayer.Entites.CategoryData;
using DataLayer.Entites.Product;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CorService.Services.Category
{
    public class CategoryService : ICategoryService
    {
        DigikalaContext _context;
        public CategoryService(DigikalaContext context)
        {
            _context = context;
        }
        public Categores GetCategoresByName(string CatgoreyName)
        {
            return _context.Categories.FirstOrDefault(c => c.EnTitle == CatgoreyName);
        }
        public List<Categores> GetSubCategoryById(int Parentid)
        {
            List<Categores> categores = (from c in _context.Categories
                                         join s in _context.SubCategories
                                         on c.CategoryId equals s.IdSubCat
                                         where (s.IdParent == Parentid)
                                         select c).ToList();
            return categores;
        }
        public ShowCategoriesForUserViewModel GetSubCategoryByName(string catname)
        {
            Categores categores = GetCategoresByName(catname);
            if (categores == null)
                return null;
            ShowCategoriesForUserViewModel showCategoriesvm = new ShowCategoriesForUserViewModel
            {
                FaTitle = categores.FaTitle,
                categories = GetSubCategoryById(categores.CategoryId)
            };
            return showCategoriesvm;
        }

        public List<CategoryForBrandViewModel> GetCategoryByBrandId(int BrandId)
        {
            IQueryable<CategoryForBrandViewModel> categories = (from c in _context.Categories
                                                                join b in _context.BrandCategories
                                                                on c.CategoryId equals b.CategoryId
                                                                where (b.BrandId == BrandId)
                                                                select new CategoryForBrandViewModel
                                                                {
                                                                    Id = c.CategoryId,
                                                                    FaTitle = c.FaTitle
                                                                });
            return categories.ToList();
        }
        public List<Categores> GetCategoresForAdmin()
        {
            return _context.Categories.ToList();
        }
        public Categores GetFindById(int id)
        {
            return _context.Find<Categores>(id);
        }
        public bool DeleteCategory(Categores categores)
        {
            _context.Update(categores);
            int res = _context.SaveChanges();
            if (res > 0)
                return true;
            return false;

        }
        public List<GetCategoryForAddViewModel> GetCategoryForAdd()
        {
            return _context.Categories.Select(c => new GetCategoryForAddViewModel
            {
                Id = c.CategoryId,
                Title = c.FaTitle
            }).ToList();
        }
        public void AddOrUpdateParentCategory(int subid, List<int> newparentid)
        {
            List<SubCategory> addlist = new List<SubCategory>();
            List<SubCategory> parentlist = _context.SubCategories.AsNoTracking().Where(s => s.IdSubCat == subid).ToList();
            if (parentlist.Count > 0)
            {
                List<SubCategory> removelist = new List<SubCategory>();
                foreach (var item in parentlist)
                {
                    if (newparentid != null)
                    {
                        if (newparentid.Contains(item.IdParent))
                        {
                            newparentid.Remove(item.IdParent);
                        }
                        else
                        {
                            removelist.Add(new SubCategory
                            {
                                Id = item.Id,
                            });
                        }
                    }
                    else
                    {
                        removelist.Add(new SubCategory
                        {
                            Id = item.Id,
                        });
                    }
                }

                if (newparentid != null && newparentid.Count > 0)
                {
                    foreach (var item in newparentid)
                    {
                        if (!_context.SubCategories.Any(s => s.IdSubCat == subid && s.IdParent == item))
                        {
                            addlist.Add(new SubCategory
                            {
                                IdSubCat = subid,
                                IdParent = item
                            });
                        }
                    }
                }
                _context.RemoveRange(removelist);
            }
            else
            {
                if (newparentid != null)
                {
                    foreach (var item in newparentid)
                    {
                        if (!_context.SubCategories.Any(s => s.IdSubCat == subid && s.IdParent == item))
                        {
                            addlist.Add(new SubCategory
                            {
                                IdSubCat = subid,
                                IdParent = item
                            });
                        }
                    }

                }
            }
            _context.AddRange(addlist);
            _context.SaveChanges();
        }
    
            public bool AddCategory(Categores categores, List<int> parentid)
            {
                _context.Add(categores);
                int res = _context.SaveChanges();
                if (res > 0)
                {
                    if (parentid != null)
                    {
                        AddOrUpdateParentCategory(categores.CategoryId, parentid);
                    }
                }
                return true;

            }
            public List<int> GetSubCategory(int id)
            {
                return _context.SubCategories.Where(c => c.IdSubCat == id).
                    Select(p => p.IdParent).ToList();
            }

        public bool IsExsisitCategory(int Catid,string entitle)
        {
            return _context.Categories.Any(c => c.CategoryId != Catid && c.EnTitle == entitle);
        }
        public bool UpdateCategory(Categores categores,List<int> parentlist)
        {
            _context.Update(categores);
            int res = _context.SaveChanges();
            if (res > 0)
            {
                AddOrUpdateParentCategory(categores.CategoryId, parentlist);
                return true;
            }
            return false;
        }
        public List<int> GetParentCategory(int id)
        {
            List<int> parentList = new List<int>();
            List<int> Temp = new List<int>();
            List<int> Temp2 = _context.SubCategories.Where(s => s.IdSubCat == id).Select(p => p.IdParent).ToList();
        Labl1: parentList.AddRange(Temp2);
            Temp.Clear();
            Temp.AddRange(Temp2);
            Temp2.Clear();
            foreach(var item in Temp)
            {
                Temp2.AddRange(_context.SubCategories.Where(s => s.IdSubCat == item).Select(p => p.IdParent).ToList());
                if (item.Equals(Temp.Last()))
                goto Labl1;
            }
            return parentList.Distinct().ToList();
        }
        public bool AddProductCategory(List<ProductCategory> productCategories)
        {
            _context.AddRange(productCategories);
            int res = _context.SaveChanges();
            if (res > 0)
                return true;
            return false;
        }

    }
}
