using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LeetCode
{
    [TestFixture]
    public class FriendsDailyChallenge
    {
        #region 2/2/2021 Remove Duplicates
        
        [TestCase(new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 }, 5, new int[] { 0, 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 1, 2 }, 2, new int[] { 1, 2, 1 })]
        public void RemoveDuplicatesTest(int[] Input, int ExpectedOutPut, int[] UpdatedInput)
        {

            Assert.AreEqual(ExpectedOutPut, Arrays.RemoveDuplicatesAttempt2(Input));
        }

        #endregion

        #region 2/3/2021 Longest Substring

        [TestCase("abcabcbb", 3)]
        [TestCase("bbbbb", 1)]
        [TestCase("pwwkew", 3)]
        [TestCase("", 0)]
        [TestCase(" ", 1)]
        [TestCase("   ", 1)]
        [TestCase("ab", 2)]
        [TestCase("dvdf", 3)]
        [TestCase("abba", 2)]
        [TestCase("anviaj", 5)]
        [TestCase("tmmzuxt", 5)]
        public void LengthOfLongestSubstringTest(string Input, int ExpectedOutput)
        {
            Assert.AreEqual(ExpectedOutput, Strings.LengthOfLongestSubstring(Input));
        }

        #endregion

        #region 2/4/2021 Best Time to Buy and Sell Stock

        [TestCase(new int[] { 7, 1, 5, 3, 6, 4 }, 7)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4)]
        [TestCase(new int[] { 7, 6, 4, 3, 1 }, 0)]
        public void MaxProfitTest(int[] prices, int ExpectedoutPut)
        {
            Assert.AreEqual(ExpectedoutPut, Arrays.MaxProfit(prices));
        }

        [TestCase(new int[] { 9, 8, 7, 7, 10 }, 3)]
        [TestCase(new int[] { 7, 1, 5, 3, 6, 4 }, 7)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4)]
        [TestCase(new int[] { 7, 6, 4, 3, 1 }, 0)]
        public void MaxProfitOptimizedTest(int[] prices, int ExpectedoutPut)
        {
            Assert.AreEqual(ExpectedoutPut, Arrays.MaxProfitOptimized(prices));
        }
        #endregion

        #region 2/5/2021 Rotate Array and Reverse Linked LIst

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 3, new int[] { 5, 6, 7, 1, 2, 3, 4 })]
        [TestCase(new int[] { -1, -100, 3, 99 }, 2, new int[] { 3, 99, -1, -100 })]
        public void RotateTest(int[] InputArray, int NumOfRotations, int[] OutputArray)
        {
            Arrays.RotateRightWithReverse(InputArray, NumOfRotations);
            Assert.AreEqual(OutputArray, InputArray);
        }



        #endregion
    }

}
