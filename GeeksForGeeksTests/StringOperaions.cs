using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeeksForGeeksTests
{
    public class StringOperations
    {
        // https://www.geeksforgeeks.org/rearrange-a-string-in-sorted-order-followed-by-the-integer-sum/

        /*
            Rearrange a string in sorted order followed by the integer sum
            
            Given a string containing uppercase alphabets and integer digits (from 0 to 9), the task is to print the alphabets in the order followed by the sum of digits.

            Examples:

            Input : AC2BEW3
            Output : ABCEW5
            Alphabets in the lexicographic order 
            followed by the sum of integers(2 and 3).
        */

        public static string ReverseAStringInSortedArrayFollowedBySumOfDigits(string inputStr)
        {
            if (string.IsNullOrWhiteSpace(inputStr)) return inputStr;

            //return new string(inputStr.Where(x => Char.IsLetter(x) && Char.IsUpper(x)).OrderBy(x => x).ToArray()) +
            //    inputStr.Where(Char.IsDigit).Count();

            return new string(inputStr.Where(Char.IsLetter).Where(Char.IsUpper).OrderBy(x => x).ToArray()) +
                Array.ConvertAll(inputStr.Where(Char.IsDigit).ToArray(), c => (int)Char.GetNumericValue(c)).Sum();
        }
    }
}
