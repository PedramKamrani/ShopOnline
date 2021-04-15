using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CorService.ExtinsionMethod;
using CorService.Helper;
using CorService.Security;
using CorService.Sender;
using CorService.Services.IService;
using CorService.ViewModels.Users;
using DataLayer.Entites.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace StorPedramBackend.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _UserService;
        private IEmailSender _emailSender;
        private ISmsSender _SmsSender;
        private IRenderViewToString _renderViewToString;
        private IConfiguration _config;
        private IHttpContextAccessor _accessor;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IUserService UserService, IEmailSender emailSender,
            IRenderViewToString renderViewToString, ISmsSender SmsSender, IConfiguration config,
            ILogger<AccountController> logger, IHttpContextAccessor accessor)
        {
            _UserService = UserService;
            _emailSender = emailSender;
            _renderViewToString = renderViewToString;
            _SmsSender = SmsSender;
            _config = config;
            _logger = logger;
            _accessor = accessor;
        }
        
        #region Register
        public IActionResult Register()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (!await GoogleRecaptchaHelper.IsReCaptchaPassedAsync(Request.Form["g-recaptcha-response"],
         _config["GoogleReCaptcha:secret"]))

            {
                ModelState.AddModelError(string.Empty, "لطفا احراز هویت انجام دهید");
                return View(model);
            }
            int phoneactivecode = CodeGenrator.PhoneActiveCode();
            User user = new User
            {
                Phone = model.Phone,
                Password = string.Join("-", PasswordHash.HashPasswordV2(model.Password)),
                
                PhoneActiveCode = phoneactivecode
            };
            int userid = _UserService.AddUser(user);

            if (userid > 0)
            {
                await _SmsSender.SendAuthSmsAsync(model.Phone, "فروشگاه ما \n " + phoneactivecode);
                TempData["phone"] = model.Phone;
                TempData["activecode"] = phoneactivecode;
                return RedirectToAction("ConfirmPhone");
            }

            ModelState.AddModelError(string.Empty, "در ثبت اطلاعات مشکلی بوجود آمده است");
            return View(model);
        }
        [Route("ConfirmPhone")]
        public IActionResult ConfirmPhone()
        {
            return View();
        }

        [Route("ConfirmPhone")]
        [HttpPost]
        public IActionResult ConfirmPhone(ActivePhoneViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["phone"] = TempData["phone"];
                TempData["activecode"] = TempData["activecode"];
                return View();
            }
            var user = _UserService.FindUserById(model.userid);
            if (user != null && user.PhoneActiveCode.ToString() == model.ActiveCode)
            {
                user.IsActive = true;
                user.PhoneActiveCode = CodeGenrator.PhoneActiveCode();

                if (_UserService.EditUser(user))
                {
                    return RedirectToAction("welcome");
                }
            }
            return View();
        }
        [Route("resendcode")]
        [HttpPost]
        public void ResendCode()
        {
            TempData["phone"] = TempData["phone"];
            TempData["activecode"] = TempData["activecode"];
           _SmsSender.SendSms(TempData["phone"].ToString(), "فروشگاه ما \n " + TempData["activecode"].ToString());
        }
        [Route("ConfirmEmail")]
        public IActionResult ConfirmEmail(int id, string activecode)
        {
            var user = _UserService.FindUserById(id);
            if (user != null && user.EmailActiveCode == activecode)
            {
                user.IsActive = true;
                user.EmailActiveCode = Guid.NewGuid().ToString().Replace("-", "");

                if (_UserService.EditUser(user))
                {
                    return RedirectToAction("welcome");
                }
            }
            return RedirectToAction("error");
        }

        #endregion

        #region Login
        public IActionResult Login(string Returnurl)
        {
            ViewData["returnUrl"] = Returnurl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string Returnurl)
        {
            ViewData["returnUrl"] = Returnurl;
            if (!ModelState.IsValid)
            {
                return View(model);
            }
          //  if (!await GoogleRecaptchaHelper.IsReCaptchaPassedAsync(Request.Form["g-recaptcha-response"],
          //_config["GoogleReCaptcha:secret"]))

          //  {
          //      ModelState.AddModelError(string.Empty, "لطفا احراز هویت انجام دهید");
          //      return View(model);
          //  }
            var user = _UserService.UserLogin(model.Phone);
            if (user != null)
            {
                
                    string[] tempstring = user.Password.Split("-");
                    byte[] hashpassword = new byte[tempstring.Length];
                    for (int i = 0; i < tempstring.Length; i++)
                        hashpassword[i] = Convert.ToByte(tempstring[i]);
                    if (PasswordHash.VerifyHashedPasswordV2(hashpassword, model.Password))
                    {
                        var claims = new List<Claim>
                        {
                            new Claim("userid",user.UserId.ToString()),
                            new Claim("name",String.IsNullOrEmpty(user.FullName) ? user.Phone : user.FullName),
                            
                        };

                        var properties = new AuthenticationProperties()
                        {
                            IsPersistent = model.IsPersistent
                        };
                       await HttpContext.SignInAsync(new ClaimsPrincipal(new ClaimsIdentity(claims, "Cookies")), properties);
                        return IslocalUrl(Returnurl);
                    
                }
                else
                {
                    _logger.LogWarning($"{model.Phone}this wit{_accessor.HttpContext?.Connection?.RemoteIpAddress.ToString()}{model.Password}");
                    ModelState.AddModelError("", "نام کاربری یا رمز عبور اشتباه است");
                }
            }
            else
            {
                ModelState.AddModelError("", "نام کاربری یا رمز عبور اشتباه است");
            }
            return View(model);
        }
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
        #endregion

        #region ForgetPassword
        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ForgetPassword(FogotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var user = _UserService.GetUserForForgetPassword(model.Phone);
            if (user != null)
            {
                ActivePhoneViewModel smsviewmodel = new ActivePhoneViewModel
                {
                    ActiveCode = user.ActiveCode,
                    userid = user.UserId
                };

                _SmsSender.SendSms(model.Phone, "فروشگاه ما \n " + smsviewmodel.ActiveCode);
                return RedirectToAction("ResetPassword",smsviewmodel);
            }


            ModelState.AddModelError("Phone", "تلفن وارد شده معتبر نمی باشد");
            return View(model);

        }

        
        public IActionResult ResetPassword(int userid, string activecode)
        {
            return View(new ResetPaswordViewModel
            {
                UserId = userid,
                ActiveCode = activecode
            });
        }

       [HttpPost]
        public IActionResult ResetPassword(ResetPaswordViewModel model)
        {
            var user = _UserService.FindUserById(model.UserId);
            if (user != null && user.PhoneActiveCode.ToString() == model.ActiveCode)
            {

                user.Password = string.Join("-", PasswordHash.HashPasswordV2(model.Password));
                user.EmailActiveCode =Guid.NewGuid().ToString().Replace("-", "");
                if (_UserService.EditUser(user))
                {
                    return RedirectToAction("welcome");
                }
            }
            return RedirectToAction("error");
        }
        #endregion
        #region ChangePassword
        [Authorize]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordViewModel model)
        {
            var user = _UserService.FindUserById(int.Parse(User.FindFirst("userid").Value));
            string[] tempstring = user.Password.Split("-");
            byte[] hashpassword = new byte[tempstring.Length];
            for(int i = 0; i < tempstring.Length; i++)
                hashpassword[i] = Convert.ToByte(tempstring[i]);
            if (PasswordHash.VerifyHashedPasswordV2(hashpassword, model.OldPassword))
            {
                user.Password = string.Join("-", PasswordHash.HashPasswordV2(model.Password));
                bool res = _UserService.EditUser(user);
                if (res == true)
                {
                    return RedirectToAction("plofile");
                }
                else
                {
                    ModelState.AddModelError("", "درتغییر رمز مشکلی پیش امده");
                }
            }
            else
            {
                ModelState.AddModelError("","رمز اشتباه است");
            }
            

            return View();
        }
        #endregion
        public IActionResult IslocalUrl(string reternurl)
        {
            return Redirect(Url.IsLocalUrl(reternurl) ? reternurl : "/");
        }
    }
}