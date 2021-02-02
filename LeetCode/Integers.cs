using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    [TestFixture]
    public class Integers
    {
        #region Reverse Integer

        /* 
         *  https://leetcode.com/explore/interview/card/top-interview-questions-easy/127/strings/880/ 
            Given a signed 32-bit integer x, return x with its digits reversed. 
            If reversing x causes the value to go outside the signed 32-bit integer range [-231, 231 - 1], then return 0.

            Assume the environment does not allow you to store 64-bit integers (signed or unsigned).

            Examples:

            Input: x = 123 Output: 321
            Input: x = -123 Output: -321
            Input: x = 120 Output: 21
            Input: x = 0 Output: 0

         * */

        public int Reverse(int x)
        {
            bool isNegative = false;

            if (x < 0)
            {
                x = 0 - x;
                isNegative = true;
            }

            int result = 0;

            while (x > 0) {
                try
                {
                    #region Explanation of Checked Keyword

                    /*
                     *  https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/checked
                        try
                        {
                            int i = Int32.MaxValue;
                            int i2 =  i + 10;
                            Console.WriteLine(i2);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }

                        try
                        {
                            checked {
                                int i = Int32.MaxValue;
                                int i2 = i + 10;
                                Console.WriteLine(i2);
                            }                
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                    */

                    #endregion

                    checked
                    {
                        result = result * 10 + x % 10;
                        x = x / 10;
                    }
                }
                catch (OverflowException ex)
                {
                    return 0;
                }
            }

            return isNegative ? -1 * result : result;
        }

        [TestCase(123, 321)]
        [TestCase(-123, -321)]
        [TestCase(120, 21)]
        [TestCase(0, 0)]
        [TestCase(1534236469, 0)]
        public void ReverseTest(int Input, int Output)
        {
            Assert.AreEqual(Output, Reverse(Input));
        }
        #endregion
    }
}
