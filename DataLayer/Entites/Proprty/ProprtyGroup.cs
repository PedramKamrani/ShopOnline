using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entites.Proprty
{
   public class ProprtyGroup
    {
        [Key]
        public int PropertyGroupId { get; set; }

        [Display(Name = "عنوان")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Title { get; set; }

        [Display(Name = "ترتیب")]
        public int Priority { get; set; }

        [Display(Name = "متن راهنما")]
        [MaxLength(1000, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        public string WikiText { get; set; }
        public bool IsDelete { get; set; }

        public List<ProprtyName> ProprtyNames { get; set; }

    }
}
