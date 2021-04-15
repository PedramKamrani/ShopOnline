using DataLayer.Entites.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Entites.Proprty
{
   public class PropertyValue
    {
        [Key]
        public int PropertyValueId { get; set; }
        [Display(Name = "مقدار")]
        [MaxLength(200, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Value { get; set; }
        public int PropertyNameId { get; set; }
        [Display(Name = "متن راهنما")]
        [MaxLength(1000, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        public string WikiText { get; set; }
        public bool ISDelete { get; set; }

        [ForeignKey("PropertyNameId")]
        public ProprtyName ProprtyName { get; set; }
        public List<ProductProperty> ProductProperties { get; set; }
    }
}
