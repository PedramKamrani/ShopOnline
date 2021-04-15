using CorService.Services.IService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorPedramBackend.ViewComponents
{
    public class SliderComponent:ViewComponent
    {

        ISlider _Slider;
        public SliderComponent(ISlider Slider)
        {
            _Slider = Slider;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult(View("MainSlider", _Slider.GetSliderForMain()));
        }
    }
}
