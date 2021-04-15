using CorService.Services.IService;
using DataLayer.Context;
using DataLayer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static CorService.ViewModels.Slider.SliderViewModel;

namespace CorService.Services.SliderService
{
    public class SliderService : ISlider
    {

        DigikalaContext _Context;
        public SliderService(DigikalaContext Context)
        {
            _Context = Context;
        }
        public List<Slider> GetSliderForMain()
        {
            return _Context.Sliders.OrderBy(s=>s.sort).ToList();
        }
        public List<Slider> GetSlierForAdmin()
        {
            return _Context.Sliders.OrderBy(s=>s.sort).ToList();
        }
        public Slider FindSliderById(int id)
        {
            return _Context.Find<Slider>(id);
        }
        public bool DeleteSlider(Slider slider)
        {
            _Context.Sliders.Remove(slider);
            int res = _Context.SaveChanges();
            if (res > 0)
                return true;
            return false;
        }
        public bool AddSlider(Slider slid)
        {
            _Context.Add(slid);
            int res = _Context.SaveChanges();
            if (res > 0)
                return true;
            return false;
        }

        public bool updateSlider(Slider slider)
        {
            _Context.Update(slider);
            int res = _Context.SaveChanges();
            if (res > 0)
                return true;
            return false;
        }
    }
}
