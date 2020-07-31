using System;
using System.Collections.Generic;
using System.Linq;

namespace PlotlyDotnet
{
    public static class Util
    {
        public static string ToKebabCase(this string src)
        {
            List<char> charArr = src.ToCharArray().ToList();

            for (int i = 0; i < charArr.Count; i++)
            {
                var target = charArr[i];

                if(Char.IsUpper(target)) 
                {
                    charArr[i] = Char.ToLower(target);
                    if (i != 0)
                        charArr.Insert(i, '-');
                }
            }

            return new String(charArr.ToArray());
        }

        public static string EnumToString<T> (this T enumValue) where T : Enum
        {
            return Enum.GetName(typeof(T), enumValue);
        }
    }
}
