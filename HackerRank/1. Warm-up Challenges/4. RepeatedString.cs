using System;
using System.Linq;

namespace HackerRank
{
    public static class StringExtentions
    {
        public static int CountAs(this string inputStr)
        {
            return inputStr.Count(x => x.ToString().Equals("a", StringComparison.OrdinalIgnoreCase));
        }
    }
    public class RepeatedString
    {
        public static long CountRepeatedString(string inputStr, long numOfChars)
        {
            // If given string does not have 'a', then return 0
            if (inputStr.CountAs() == 0) return 0;
            
            // If there is only one character in given string which is 'a', then return  numOfChars
            if (inputStr.Length == 1 && string.Equals(inputStr, "a", StringComparison.OrdinalIgnoreCase)) return numOfChars;

            long totalAs;
            if (numOfChars < inputStr.ToCharArray().Length)
            {
                inputStr = inputStr.Substring(0, Convert.ToInt32(numOfChars));

                totalAs = inputStr.CountAs();

                return totalAs;
            }

            // When numOfChars > inputStr.ToCharArray().Length
            // total number of A's in initial string
            totalAs = inputStr.CountAs();

            // Find the dividend of number of 
            var dividend = numOfChars / inputStr.ToCharArray().Length;
            totalAs *= dividend;

            var remainingChars = numOfChars - (dividend * inputStr.Length);
            var remainingAs = inputStr.Substring(0, Convert.ToInt32(remainingChars)).CountAs();

            totalAs += remainingAs;

            return totalAs;
        }
    }
}
