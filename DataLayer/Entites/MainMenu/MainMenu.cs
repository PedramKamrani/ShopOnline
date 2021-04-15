using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Entites.MainMenu
{
    public class MainMenu
    {
        [Key]
        public int MenuId { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = "{0}نباید بیشتر از {1} باشد")]
        public string MenuTitle { get; set; }

        [Display(Name = "لینک")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(250, ErrorMessage = "{0}نباید بیشتر از {1} باشد")]
        public string Link { get; set; }

        [Display(Name = "ترتیب ")]
        public int Sort { get; set; }

        [Display(Name = "اسم عکس")]
        [MaxLength(150, ErrorMessage = "{0}نباید بیشتر از {1} باشد")]
        public string ImageName { get; set; }

        [Display(Name = "نوع منو ")]
        public byte Type { get; set; }
        public int? ParentId { get; set; }

        [ForeignKey("ParentId")]
        public List<MainMenu> MainMenus { get; set; }
    }
}
