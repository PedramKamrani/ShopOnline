using CorService.Services.IService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorPedramBackend.ViewComponents
{
    public class ShowCategoryForBrandComponent:ViewComponent
    {
        ICategoryService _CategoryService;
        public ShowCategoryForBrandComponent(ICategoryService categoryService)
        {
            _CategoryService = categoryService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            return await Task.FromResult(View("ShowCategoryForBrand", _CategoryService.GetCategoryByBrandId(id)));
        }
    }
}
