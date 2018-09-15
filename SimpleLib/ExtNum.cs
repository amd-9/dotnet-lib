using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleLib
{
    public static class ExtNum
    {
        public static string middle(this List<string> list)
        {
            var middle_index = Convert.ToInt32(Math.Round(Enumerable.Count(list) / 2.0, 0));

            return Enumerable.ElementAt(list, middle_index);
        }

        public static string plural(this string str, char symbol)
        {
            return str.EndsWith('s') ? str : $"{str}{symbol}";
        }

        public static string puts(this string str){
            //do something usefull to put data to FileSystem

            //just returning str for test purposes
            return str;
        }
    }

}
