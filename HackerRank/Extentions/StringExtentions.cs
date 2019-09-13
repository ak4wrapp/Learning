using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank.Extentions
{
    public static class StringExtentions
    {
        public static int CountAs(this string inputStr)
        {
            return inputStr.Count(x => x.ToString().Equals("a", StringComparison.OrdinalIgnoreCase));
        }
    }
}
