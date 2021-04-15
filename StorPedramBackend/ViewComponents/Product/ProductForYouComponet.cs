using CorService.Services.IService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorPedramBackend.ViewComponents.Product
{
    public class ProductForYouComponet:ViewComponent
    {
        IProductService _productService;
        public ProductForYouComponet(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult(View("_ProductFor", _productService.GetAllProductForYou()));
        }
    }
}
