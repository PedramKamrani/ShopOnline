using CorService.Services.IService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorPedramBackend.ViewComponents.Product
{
    
        public class ProductPropertyComponent : ViewComponent
        {
            IProductService _productService;
            public ProductPropertyComponent(IProductService productService)
            {
                _productService = productService;
            }

            public async Task<IViewComponentResult> InvokeAsync(int productid)
            {
                return await Task.FromResult(View("ProductProperty", _productService.GetProperty(productid)));
            }
        }
    
}
