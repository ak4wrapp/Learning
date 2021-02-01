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
            return 0;
        }

        [TestCase(123, 321)]
        [TestCase(-123, -321)]
        [TestCase(120, 21)]
        [TestCase(0, 0)]
        public void ReverseTest(int Input, int Output)
        {
            Assert.AreEqual(Output, Reverse(Input));
        }
        #endregion
    }
}
