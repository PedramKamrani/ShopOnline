using DataLayer.Entites.Proprty;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Entites.Product
{
   public class ProductProperty
    {
        public int ProductPropertyId { get; set; }
        public int ProductId { get; set; }
        public int PropertyValueId { get; set; }

        public PropertyValue PropertyValue { get; set; }
        [ForeignKey("ProductId")]
        public Products Products { get; set; }

    }
}
