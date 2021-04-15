using DataLayer.Entites.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Entites.User
{
   public class UserProductFovorites
    {
        public int UserProductFovoritesId { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        [ForeignKey("ProductId")]
        public Products Products { get; set; }
        public User User { get; set; }
    }
}
