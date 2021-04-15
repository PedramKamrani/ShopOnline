using DataLayer.Entites.CategoryData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Entites.Proprty
{
  public class ProprtyName
    {
        [Key]
        public int PropertyNameId { get; set; }
        [Display(Name = "عنوان")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Title { get; set; }

        [Display(Name = "ترتیب")]
        public int Priority { get; set; }

        [Display(Name = "استفاده در جستجو")]
        public bool UseSearch { get; set; }
        [Display(Name = "گروه خصوصیات")]
        public int PropertyGroupId { get; set; }

        [Display(Name = "متن راهنما")]
        [MaxLength(1000, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        public string WikiText { get; set; }
        public int Type { get; set; }
        public int? CategoresCategoryId { get; set; }

        [ForeignKey("PropertyGroupId")]
        public ProprtyGroup ProprtyGroup { get; set; }
        public List<PropertyValue> PropertyValues { get; set; }
        [ForeignKey("CategoresCategoryId")]
        public Categores Category { get; set; }
        public List<PropertyCategory> PropertyCategories { get; set; }
    }
}
