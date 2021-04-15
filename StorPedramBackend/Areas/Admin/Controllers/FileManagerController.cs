using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorService.ExtinsionMethod;
using CorService.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StorPedramBackend.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FileManagerController : Controller
    {
        public IActionResult ImageUpload(IFormFile image)
        {
            string imagename = "";
            if (image != null)
            {
                if (ImgeSecurity.ImageValitor(image))
                {
                    imagename = image.SaveImage("", "wwwroot/img/test");
                }
               
            }
            return Json(new { uploaded = true,url= "wwwroot/img/test/"+imagename }) ;
        }
    }
}