using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Entites.OrderProuduct
{
   public class OrderProuducts
    {
        public int OrderProuductsid { get; set; }
        public int UserId { get; set; }
        public DateTime creatDate { get; set; }
        public bool IsFainally { get; set; }
        public int Sum { get; set; }

        [ForeignKey("UserId")]
        public User.User User { get; set; }
        public List< OrderProuduct.DetailesOrder> DetailesOrders { get; set; }
    }
}
