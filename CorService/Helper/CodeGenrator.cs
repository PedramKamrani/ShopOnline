using System;
using System.Collections.Generic;
using System.Text;

namespace CorService.Helper
{
    public static class CodeGenrator
    {
        public static int PhoneActiveCode()
        {
            Random rnd = new Random();
           return rnd.Next(1000, 9999);
        }
    }
}
