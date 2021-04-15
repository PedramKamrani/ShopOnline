using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Entites.OrderProuduct
{
  public class DetailesOrder
    {
        public int DetailesOrderId { get; set; }
        public int ProductId { get; set; }
        public int Ordeid { get; set; }
        public int count { get; set; }
        public int Price { get; set; }
        
        [ForeignKey("Ordeid")]
        public OrderProuduct.OrderProuducts OrderProuducts { get; set; }
        [ForeignKey("ProductId")]
        public Product.Products Products { get; set; }
    }
}
