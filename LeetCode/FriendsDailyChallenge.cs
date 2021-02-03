﻿using System;
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

        public int LengthOfLongestSubstring(string s)
        {
            if (String.IsNullOrEmpty(s)) return 0;
            if (s.Length == 1) return 1;

            Dictionary<char, int > dictCharLastIndex = new Dictionary<char, int>();
            int longestSubStringLength = 0;
            int currentSubStringLength = 0;
            int lastDuplicateCharIndex = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (!dictCharLastIndex.ContainsKey(s[i]))
                {
                    // Means we have not seen this character earlier
                    dictCharLastIndex.Add(s[i], i);
                    currentSubStringLength++;
                }
                else // We have a repeatative character here, reset counters
                {
                    if (longestSubStringLength >= s.Length) return longestSubStringLength;

                    int lastApperance = dictCharLastIndex[s[i]];
                    currentSubStringLength = i - lastApperance;
                    lastDuplicateCharIndex = i;

                }

                if (currentSubStringLength > longestSubStringLength)
                {
                    longestSubStringLength = currentSubStringLength;
                }
            }

            return longestSubStringLength;
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
        public void LengthOfLongestSubstringTest(string Input, int ExpectedOutput)
        {
            Assert.AreEqual(ExpectedOutput, LengthOfLongestSubstring(Input));
        }
        #endregion
    }
}