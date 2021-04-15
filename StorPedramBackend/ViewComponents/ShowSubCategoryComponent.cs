using CorService.Services.IService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorPedramBackend.ViewComponents
{
    public class ShowSubCategoryComponent:ViewComponent
    {
        ICategoryService _CategoryService;
        public ShowSubCategoryComponent(ICategoryService categoryService)
        {
            _CategoryService = categoryService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            return await Task.FromResult(View("ShowCategory",_CategoryService.GetSubCategoryById(id)));
        }
    }
}
