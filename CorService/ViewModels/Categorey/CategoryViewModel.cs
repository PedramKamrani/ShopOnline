using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CorService.ViewModels.Categorey
{
    public class CreateCategoryViewModel
    {
        [Display(Name = "عنوان فارسی")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string FaTitle { get; set; }

        [Display(Name = "عنوان انگلیسی")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string EnTitle { get; set; }

        [Display(Name = "توضیحات")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Descrption { get; set; }
        [Display(Name = "عکس")]
        public IFormFile Image { get; set; }
        public List<int> ParentList { get; set; }
    }

    public class GetCategoryForAddViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }

    public class EditCategoryViewModel
    {
        public int Id { get; set; }
        [Display(Name = "عنوان فارسی")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string FaTitle { get; set; }

        [Display(Name = "عنوان انگلیسی")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string EnTitle { get; set; }

        [Display(Name = "توضیحات")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Descrption { get; set; }
        public string CurrentImage { get; set; }
        [Display(Name = "عکس")]
        public IFormFile Image { get; set; }
        public List<int> ParentList { get; set; }
    }


    public class SearchCategoryViewModel
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public int? ParentId { get; set; }
    }
}


