using DataLayer.Entites.CategoryData;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entites.Proprty
{
    public class PropertyCategory
    {
        public int PropertyCategoryId { get; set; }
        public int PropertyNameId { get; set; }
        public int CategoryId { get; set; }

        public Categores Category { get; set; }
        public ProprtyName PropertyName { get; set; }
    }
}
