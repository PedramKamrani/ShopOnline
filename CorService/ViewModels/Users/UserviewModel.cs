using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CorService.ViewModels.Users
{
    public class ShowUserViewModel
    {
        public int UserId { get; set; }
        [Display(Name = " شماره تلفن")]
     
        public string Phone { get; set; }

        [Display(Name = "نام")]
        
        public string FullName { get; set; }

        [Display(Name ="وضعیت کاربر")]
        public bool IActive { get; set; }
    }
    public class RegisterUserViewModel
    {
        [Display(Name = " شماره تلفن")]
        [MaxLength(11, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        [Required(ErrorMessage = "{0} اجباری است")]
        [RegularExpression(@"^\(?(09)\)?([0-9]{9})$", ErrorMessage = "{0} وارد شده معتبر نمی باشد")]
        public string Phone { get; set; }

        [Display(Name = "رمز عبور")]
        [MaxLength(200, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        [Required(ErrorMessage = "{0} اجباری است")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "باید با قوانین و مقررات موافقت کنید")]
        public bool Terms { get; set; }
    }

    public class ActiveEmailViewModel
    {
        public int UserId { get; set; }
        public string ActiveCode { get; set; }
    }

    public class FogotPasswordViewModel
    {
        [Display(Name = "تلفن")]
        [MaxLength(11, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        [Required(ErrorMessage = "{0} اجباری است")]
        [RegularExpression(@"^\(?(09)\)?([0-9]{9})$", ErrorMessage = "{0} وارد شده معتبر نمی باشد")]
        public string Phone { get; set; }
    }

    public class ResetPaswordViewModel
    {
        public int UserId { get; set; }
        public string ActiveCode { get; set; }
        [Display(Name = "رمز عبور")]
        [MaxLength(200, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        [Required(ErrorMessage = "{0} اجباری است")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "تکرار رمز عبور")]
        [MaxLength(200, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        [Required(ErrorMessage = "{0} اجباری است")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "تکرار کلمه عبور همخوانی ندارد")]
        public string RePassword { get; set; }

    }

    public class ActivePhoneViewModel
    {
        public int userid { get; set; }
        public string Phone { get; set; }

        [Display(Name = "کد")]
        [MaxLength(4, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        [Required(ErrorMessage = "{0} اجباری است")]
        public string ActiveCode { get; set; }
    }

    public class LoginViewModel
    {
        [Display(Name = " شماره تلفن")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        [Required(ErrorMessage = "{0} اجباری است")]
        [RegularExpression(@"^\(?(09)\)?([0-9]{9})$", ErrorMessage = "{0} وارد شده معتبر نمی باشد")]

        public string Phone { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "{0} اجباری است")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool IsPersistent { get; set; }
    }

    public class ChangePasswordViewModel
    {

        [Display(Name = "رمز عبور قبلی")]
        [MaxLength(200, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        [Required(ErrorMessage = "{0} اجباری است")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }


        [Display(Name = "رمز عبور جدید")]
        [MaxLength(200, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        [Required(ErrorMessage = "{0} اجباری است")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "تکرار رمز عبور")]
        [MaxLength(200, ErrorMessage = "مقدار {0} نباید بیشتراز{1} باشد")]
        [Required(ErrorMessage = "{0} اجباری است")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "تکرار کلمه عبور همخوانی ندارد")]
        public string RePassword { get; set; }
    }

    //public class EditRoleViewModel
    //{
    //    public int RoleId { get; set; }
    //    public string Name { get; set; }
    //    public List<int> SelctedPermissons { get; set; }
    //    public List<Permisson> Permissons { get; set; }
    //}
}

