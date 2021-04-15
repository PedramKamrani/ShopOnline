using DataLayer.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using static CorService.ViewModels.Slider.SliderViewModel;

namespace CorService.Services.IService
{
  public interface ISlider
    {
        List<Slider> GetSliderForMain();
        List<Slider> GetSlierForAdmin();
        Slider FindSliderById(int id);
        bool DeleteSlider(Slider slider);
        bool AddSlider(Slider slid);
        bool updateSlider(Slider slider);
    }
}
