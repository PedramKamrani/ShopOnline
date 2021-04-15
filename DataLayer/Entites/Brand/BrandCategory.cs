using DataLayer.Entites.CategoryData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Entites.Brand
{
   public class BrandCategory
    {
        public int BrandCategoryId { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }

        public Brand Brand { get; set; }
        [ForeignKey("CategoryId")]
        public Categores Categores { get; set; }
    }
}
