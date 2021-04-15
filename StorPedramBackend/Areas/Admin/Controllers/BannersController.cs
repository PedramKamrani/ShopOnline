using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CorService.ExtinsionMethod;
using CorService.Security;
using CorService.Services.IService;
using CorService.Services.SliderService;
using DataLayer.Entites;
using Microsoft.AspNetCore.Mvc;
using static CorService.ViewModels.Slider.SliderViewModel;

namespace StorPedramBackend.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AutoValidateAntiforgeryToken]
    public class BannersController : Controller
    {
        ISlider _Slider;
        IBannerService _BannerService;
        public BannersController(ISlider Slider, IBannerService BannerService)
        {
            _Slider = Slider;
            _BannerService = BannerService;
        }
        #region Slider
        public IActionResult SliderList()
        {
            return View(_Slider.GetSlierForAdmin());
        }
        public IActionResult DeleteSlider(int id)
        {
            Slider slider = _Slider.FindSliderById(id);
            if (slider == null)
            {
                TempData["res"] = "faild";
                return RedirectToAction("SliderList");
            }
            bool res = _Slider.DeleteSlider(slider);
            if (res)
            {
                slider.ImgName.DeleteImage("wwwroot/img/slider/");
                slider.ImgName.DeleteImage("wwwroot/img/slider/mobile-slider/");
            }
            TempData["res"] = res ? "success" : "faild";

            return RedirectToAction("SliderList");
        }
        public IActionResult CreateSlider()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult CreateSlider(CreateSliderViewModel slid)
        {
            if (!ModelState.IsValid)
            {
                return View(slid);
            }
            string filename = "";
            if (ImgeSecurity.ImageValitor(slid.DesktopImg))
            {
                filename = slid.DesktopImg.SaveImage("", "wwwroot/img/slider");
            }
            else
            {
                ModelState.AddModelError("DesktopImg", "لطفا یک فایل عکس قرار بدید");
            }
            if (ImgeSecurity.ImageValitor(slid.MobileImg))
            {
                slid.MobileImg.SaveImage(filename, "wwwroot/img/slider/mobile-slider");
            }
            else
            {
                ModelState.AddModelError("MobileImg", "لطفا یک فایل عکس قرار بدید");
            }
            Slider sl = new Slider
            {
                ImgName = filename,
                Descrption = slid.Descrption,
                Link = slid.Link,
                sort = slid.sort,
            };
            bool res = _Slider.AddSlider(sl);
            TempData["res"] = res ? "success" : "faild";
            return RedirectToAction("SliderList");
        }
        public IActionResult EditSlider(int id)
        {
            Slider slid = _Slider.FindSliderById(id);
            if (slid == null)
            {
                TempData["res"] = "faild";
            }
            EditSliderViewModel slvm = new EditSliderViewModel
            {
                sliderid = slid.SliderId,
                CurrentImgName = slid.ImgName,
                Descrption = slid.Descrption,
                Link = slid.Link,
                sort = slid.sort
            };
            return View(slvm);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult EditSlider(EditSliderViewModel edit)
        {
            if (!ModelState.IsValid)
            {
                return View(edit);
            }

            string filname = TempData["imgename"].ToString();
            if (edit.DesktopImg != null)
            {
                if (ImgeSecurity.ImageValitor(edit.DesktopImg))
                {
                    filname.DeleteImage("wwwroot/img/slider/");

                    edit.DesktopImg.SaveImage(filname, "wwwroot/img/slider/");

                }
                else
                {
                    ModelState.AddModelError("DesktopImg", "لطفا یک فایل عکس قرار بدید");
                }
                if (ImgeSecurity.ImageValitor(edit.MobileImg))
                {
                    edit.MobileImg.SaveImage(filname, "wwwroot/img/slider/mobile-slider");
                }
                else
                {
                    ModelState.AddModelError("MobileImg", "لطفا یک فایل عکس قرار بدید");
                }
                Slider sl = new Slider
                {
                    SliderId = int.Parse(TempData["sliderid"].ToString()),
                    sort = edit.sort,
                    Descrption = edit.Descrption,
                    ImgName = filname,
                    Link = edit.Link,
                };
                bool res = _Slider.updateSlider(sl);
                TempData["res"] = res ? "success" : "faild";
            }
            return RedirectToAction("SliderList");
        }
        #endregion
        #region Banner
        public IActionResult BannerList()
        {
            return View(_BannerService.GetBannerForAdmin());
        }
        public IActionResult ChangeActive(int id)
        {
            ViewData["Title"]= _BannerService.ChangeActiveBanner(id)?"succsse":"faild";
            return RedirectToAction("BannerList");
        }
        #endregion
    }
}