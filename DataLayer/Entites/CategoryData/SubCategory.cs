using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Entites.CategoryData
{
   public class SubCategory
    {
        [Key]
        public int Id { get; set; }
        public int IdParent { get; set; }
        public int IdSubCat { get; set; }


        [ForeignKey("IdParent")]
        [InverseProperty("parenteCategory")]
        public Categores ParentCategory { get; set; }
        [ForeignKey("IdSubCat")]
        [InverseProperty("SubCategory")]
        public Categores SubCatores { get; set; }
    }
}
