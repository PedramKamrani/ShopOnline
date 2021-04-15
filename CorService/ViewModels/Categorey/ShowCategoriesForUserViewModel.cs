using System;
using System.Collections.Generic;
using System.Text;

namespace CorService.ViewModels.Categorey
{
    public class ShowCategoriesForUserViewModel
    {
        public string FaTitle { get; set; }
        public List<DataLayer.Entites.CategoryData.Categores> categories { get; set; }
    }
}
