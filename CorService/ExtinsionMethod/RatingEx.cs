using System;
using System.Collections.Generic;
using System.Text;

namespace CorService.ExtinsionMethod
{
   public static class RatingEx
    {
        public static string GetRatingRange(this int value)
        {
            if (value > 75)
                return "عالی";

            if (value > 50)
                return "خوب";

            if (value > 75)
                return "معمولی";

            else
                return "ضعیف";
        }
        public static string[] GeteEvaluation(this string value)
        {
            string[] str= value.Split("=");
            return str;
        }
    }
}
