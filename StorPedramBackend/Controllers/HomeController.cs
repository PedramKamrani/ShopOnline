using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CorService.Services.IService;
using CorService.Services.SliderService;
using DataLayer.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StorPedramBackend.Models;

namespace StorPedramBackend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IBrandService _brandService;
        private readonly IProductService _productService;

        public HomeController( 
            ICategoryService categoryService, IBrandService brandService,
            IProductService productService)
        {
            _categoryService = categoryService;
            _brandService = brandService;
            _productService = productService;
        }

        public IActionResult Index()
        {
            
            return View(_productService.GetAllProduct());
        }
       
        [Route("main/{categoryname}")]
        public IActionResult Category(string categoryname)
        {
            var category = _categoryService.GetSubCategoryByName(categoryname);
            if (category == null||category.categories.Count<=0)
                return NotFound();
            return View(category);
        }
        [Route("brand/{brandTitle}")]
        public IActionResult Brand(string brandTitle)
        {
            return View(_brandService.GetBrandByName(brandTitle));

        }

        
    }
}
