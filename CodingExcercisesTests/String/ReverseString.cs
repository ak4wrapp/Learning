using System;
using System.Collections.Generic;
using System.Text;

namespace CodingExcercisesTests.String
{
    public class ReverseString
    {
        public static string Reverse(string inputStr) {
            char[] charArray = inputStr.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
