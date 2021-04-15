using CorService.Services.IService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorPedramBackend.ViewComponents.Product
{
    public class ReviewProductComponent:ViewComponent
    {
        private IProductService _ProductService;
        public ReviewProductComponent(IProductService ProductService)
        {
            _ProductService = ProductService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int productId)
        {
            return await Task.FromResult(View("ReviewProduct",_ProductService.GetProductReview(productId)));
        }
    }
}
