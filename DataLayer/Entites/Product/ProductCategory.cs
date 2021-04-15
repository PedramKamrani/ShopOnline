using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Entites.Product
{
   public class ProductCategory
    {
        [Key]
        public int ProductCategoryId { get; set; }
        public int ProuctId { get; set; }
        public int Categoryid { get; set; }
        [ForeignKey("Categoryid")]
        public CategoryData.Categores Categores { get; set; }
        [ForeignKey("ProuctId")]
        public Products Products { get; set; }
    }
}
