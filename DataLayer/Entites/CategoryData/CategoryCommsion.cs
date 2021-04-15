using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Entites.CategoryData
{
   public class CategoryCommsion
    {
        [Key]
        public int CategoryCommsionId { get; set; }
        public byte Value { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Categores Category { get; set; }
    }
}
