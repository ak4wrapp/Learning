using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LeetCode
{
    [TestFixture]
    public class FriendsDailyChallenge
    {
        #region 2/2/2021 Remove Duplicates

        public int RemoveDuplicates(int[] nums)
        {
            if (nums == null || nums.Length < 1) return 0;
            if (nums.Length == 1) return 1;

            int dups = 1;
            // We can start with first element as its sorted array
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > nums[dups - 1])
                {
                    int temp = nums[dups];
                    nums[dups] = nums[i];
                    nums[i] = temp;
                    dups++;
                }

            }
            return dups;
        }

        [TestCase(new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 }, 5, new int[] { 0, 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 1, 2 }, 2, new int[] { 1, 2, 1 })]
        public void RemoveDuplicatesTest(int[] Input, int ExpectedOutPut, int[] UpdatedInput)
        {

            Assert.AreEqual(ExpectedOutPut, RemoveDuplicates(Input));
        }

        #endregion

        #region 2/3/2021 Longest Substring

        #region Problem Description
        /*  https://leetcode.com/problems/longest-substring-without-repeating-characters/
         *  
         *  Given a string s, find the length of the longest substring without repeating characters.

            Example 1:

            Input: s = "abcabcbb"
            Output: 3
            Explanation: The answer is "abc", with the length of 3.

            Example 2:

            Input: s = "bbbbb"
            Output: 1
            Explanation: The answer is "b", with the length of 1.

            Example 3:

            Input: s = "pwwkew"
            Output: 3
            Explanation: The answer is "wke", with the length of 3.
            Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.

            Example 4:

            Input: s = ""
            Output: 0
 

            Constraints:
             
            0 <= s.length <= 5 * 104
            s consists of English letters, digits, symbols and spaces.
         */

        #endregion

        public int LengthOfLongestSubstring(string s)
        {

            #region Attempt with one loop
            Dictionary<char, int> dictCharLastIndex = new Dictionary<char, int>();
            int longestSubStringLength = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (dictCharLastIndex.ContainsKey(s[i]))
                {
                    // Set longestSubStringLength to whatever number is greater out of
                    // Current unique characters Dictionary Length or Previously found longest substr 
                    longestSubStringLength = Math.Max(longestSubStringLength, dictCharLastIndex.Count);

                    // lets start finding new character from Index of current character;s previously found Index
                    i = dictCharLastIndex[s[i]];

                    // clear dictionary
                    dictCharLastIndex.Clear();
                }
                else
                {
                    dictCharLastIndex.Add(s[i], i);
                }
            }
            longestSubStringLength = Math.Max(longestSubStringLength, dictCharLastIndex.Count);
            return longestSubStringLength;

            //if (String.IsNullOrEmpty(s)) return 0;
            //if (s.Length == 1) return 1;

            //Dictionary<char, int> dictCharLastIndex = new Dictionary<char, int>();
            //dictCharLastIndex.Add(s[0], 1);

            //int subStrStartIndex = 0;
            //int subStrEndIndex = 0;

            //int longestSubStringLength = 1;
            //for (int i = 0; i < s.Length; i++)
            //{
            //    if (!dictCharLastIndex.ContainsKey(s[i]))
            //    {
            //        // Means we have not seen this character earlier
            //        dictCharLastIndex.Add(s[i], i);

            //        // currentSubStringLength = i - lastDuplicateCharIndex + 1;
            //        currentSubStringLength++;
            //    }
            //    else // We have a repeatative character here, reset counters
            //    {
            //        // this is the case when we know a new substring 
            //        // can never be more than longest sub string
            //        // if (longestSubStringLength > s.Length/2) return longestSubStringLength;

            //        currentSubStringIndex = i;
            //        lastDuplicateCharIndex = dictCharLastIndex[s[i]] > lastDuplicateCharIndex ?
            //            dictCharLastIndex[s[i]] : lastDuplicateCharIndex;

            //        dictCharLastIndex[s[i]] = i;
            //        currentSubStringLength = i - lastDuplicateCharIndex + 1;

            //        lastDuplicateCharIndex = i;
            //    }

            //    if (currentSubStringLength > longestSubStringLength)
            //    {
            //        longestSubStringLength = currentSubStringLength;
            //    }
            //}
            #endregion

            #region Brute Force
            //if (String.IsNullOrEmpty(s)) return 0;
            //if (s.Length == 1) return 1;

            //Dictionary<char, int> dictCharLastIndex = new Dictionary<char, int>();
            //int longestSubStringLength = 1;
            //for (int i = 0; i < s.Length; i++)
            //{
            //    dictCharLastIndex.Add(s[i], 1);
            //    for (int j = i + 1; j < s.Length; j++)
            //    {
            //        if (!dictCharLastIndex.ContainsKey(s[j]))
            //        {
            //            dictCharLastIndex.Add(s[j], 1);
            //        }
            //        else
            //        {
            //            break;
            //        }
            //    }

            //    longestSubStringLength = Math.Max(dictCharLastIndex.Count, longestSubStringLength);
            //    dictCharLastIndex.Clear();
            //}
            //return longestSubStringLength;
            #endregion

            #region Copied (80ms Solution
            //if (String.IsNullOrEmpty(s)) return 0;
            //if (s.Length == 1) return 1;

            //HashSet<char> setChars = new HashSet<char>();
            //int currentMax = 0, i = 0, j = 0;

            //while (j < s.Length)
            //    if (!setChars.Contains(s[j]))
            //    {
            //        setChars.Add(s[j++]);
            //        currentMax = Math.Max(currentMax, j - i);
            //    }
            //    else
            //        setChars.Remove(s[i++]);

            //return currentMax;
            #endregion

            #region Optimized (Copied), using Dictionary, the approach I was trying)

            //Dictionary<char, int> letters = new Dictionary<char, int>();
            //int length = 0;
            //for (int i = 0; i < s.Length; i++)
            //{
            //    if (letters.TryGetValue(s[i], out int index))
            //    {
            //        length = Math.Max(length, letters.Count);
            //        i = index;
            //        letters.Clear();
            //    }
            //    else
            //    {
            //        letters.Add(s[i], i);
            //    }
            //}
            //length = Math.Max(length, letters.Count);
            //return length;
            #endregion
        }

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
            Assert.AreEqual(ExpectedOutput, LengthOfLongestSubstring(Input));
        }

        #endregion

        #region 2/4/2021 Best Time to Buy and Sell Stock

        #region Problem Details
        /*  https://leetcode.com/explore/featured/card/top-interview-questions-easy/92/array/564/
         *  
         *  Say you have an array prices for which the ith element is the price of a given stock on day i.

            Design an algorithm to find the maximum profit. You may complete as many transactions as you like (i.e., buy one and sell one share of the stock multiple times).

            Note: You may not engage in multiple transactions at the same time (i.e., you must sell the stock before you buy again).

            Example 1:

            Input: [7,1,5,3,6,4]
            Output: 7
            Explanation: Buy on day 2 (price = 1) and sell on day 3 (price = 5), profit = 5-1 = 4.
                         Then buy on day 4 (price = 3) and sell on day 5 (price = 6), profit = 6-3 = 3.
            Example 2:

            Input: [1,2,3,4,5]
            Output: 4
            Explanation: Buy on day 1 (price = 1) and sell on day 5 (price = 5), profit = 5-1 = 4.
                         Note that you cannot buy on day 1, buy on day 2 and sell them later, as you are
                         engaging multiple transactions at the same time. You must sell before buying again.
            Example 3:

            Input: [7,6,4,3,1]
            Output: 0
            Explanation: In this case, no transaction is done, i.e. max profit = 0.
 

            Constraints:

            1 <= prices.length <= 3 * 10 ^ 4
            0 <= prices[i] <= 10 ^ 4
         */
        #endregion

        public int MaxProfit(int[] prices)
        {
            int profit = 0;
            int lastBuyPrice = 0;
            int bestBuyPrice = 0;

            for (int i = 0; i < prices.Length; i++)
            {
                int todayPrice = prices[i];

                // Check if price Increasing after today
                int j = i + 1;
                while(j < prices.Length)
                {
                    if (prices[j] > todayPrice) {
                        bestBuyPrice = todayPrice;
                        i++;
                        j++;
                    }
                }
                if (bestBuyPrice != lastBuyPrice) {
                    lastBuyPrice = bestBuyPrice;
                }
            }

            return profit;
        }

        [TestCase(new int[] { 7, 1, 5, 3, 6, 4 }, 7)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4)]
        [TestCase(new int[] { 7, 6, 4, 3, 1 }, 0)]
        public void MaxProfitTest(int[] prices, int ExpectedoutPut)
        {
            Assert.AreEqual(ExpectedoutPut, MaxProfit(prices));
        }
        #endregion
    }

}
