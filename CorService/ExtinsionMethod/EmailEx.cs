using System;
using System.Collections.Generic;
using System.Text;

namespace CorService.ExtinsionMethod
{
  public static  class EmailEx
    {
        public static string EmailNormalize(this string email)
        {
            return email.Trim().ToLower();
        }
    }
}
