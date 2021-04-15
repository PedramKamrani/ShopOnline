using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorService.ViewModels.Brand
{
   public class BrandForAddProductViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }

    public class BrandForShowAdminViewModel
    {
        public int Id { get; set; }
        public string FaTitle { get; set; }
        public string EnTitle { get; set; }
        public string ImageName { get; set; }
      
    }
    public class BrandAddViewModel
    {
        public string FaTitle { get; set; }
        public string EnTitle { get; set; }
        public string Deccription { get; set; }
        public bool IsDelete { get; set; }
        public IFormFile Image { get; set; }
    }
    public class BrandEditViewModel
    {
        public int id { get; set; }
        public string FaTitle { get; set; }
        public string EnTitle { get; set; }
        public string Deccription { get; set; }
        public bool IsDelete { get; set; }
        public IFormFile Image { get; set; }
        public string ImageName { get; set; }
    }
}
