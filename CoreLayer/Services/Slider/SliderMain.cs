using CoreLayer.Services.IServices;
using DataLayer.Context;
using DataLayer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreLayer.Services.Slider
{
    public class SliderMain : ISlider
    {
        private readonly DigikalaContext _context;
        public SliderMain(DigikalaContext context)
        {
            _context = context;
        }
        
    }

}
