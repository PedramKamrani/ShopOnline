using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorService.Security
{
  public static  class ImgeSecurity
    {
        public static bool ImageValitor(IFormFile img)
        {
            if (img.Length>0 && img!=null)
            {
                try
                {
                    System.Drawing.Image.FromStream(img.OpenReadStream());
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
    }
}
