using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;

namespace LeetCode
{
    [TestFixture]
    public class Strings
    {
        #region Check is Palindrome

        /*  https://leetcode.com/explore/interview/card/top-interview-questions-easy/127/strings/883/
         *  
         *  Given a string, determine if it is a palindrome, considering only alphanumeric characters and ignoring cases.

            Note: For the purpose of this problem, we define empty string as valid palindrome.

            Example 1:

                Input: "A man, a plan, a canal: Panama"
                Output: true

            Example 2:

                Input: "race a car"
                Output: false

            Constraints:

            s consists only of printable ASCII characters.
         */


        public bool IsPalindrome(string s)
        {
            int leftPositionIndex = 0;
            int rightPostionIndex = s.Length - 1;

            while (leftPositionIndex < rightPostionIndex)
            {
                if (!Char.IsLetterOrDigit(s[leftPositionIndex]))
                {
                    leftPositionIndex++;
                    continue;
                }

                if (!Char.IsLetterOrDigit(s[rightPostionIndex]))
                {
                    rightPostionIndex--;
                    continue;
                }

                if (Char.ToLower(s[leftPositionIndex]) != Char.ToLower(s[rightPostionIndex]))
                {
                    return false;
                }

                leftPositionIndex++;
                rightPostionIndex--;
            }
            return true;
        }

        [Test]
        public void IsPalindromeTest()
        {
            foreach (var spec in new[] {
                (input: "A man, a plan, a canal: Panama", output: true),
                (input: "race a car", output: false)
            })
            {
                Assert.AreEqual(spec.output, IsPalindrome(spec.input));
            }
        }

        #endregion

        #region IsAnagram

        /*
         *  https://leetcode.com/explore/interview/card/top-interview-questions-easy/127/strings/882/
         *  
         *  Given two strings s and t , write a function to determine if t is an anagram of s.

            Example 1:

            Input: s = "anagram", t = "nagaram"
            Output: true

            Example 2:

            Input: s = "rat", t = "car"
            Output: false
            
            Note:
            You may assume the string contains only lowercase alphabets.

            Follow up:
            What if the inputs contain unicode characters? How would you adapt your solution to such case?
         */

        public bool IsAnagram(string s, string t)
        {
            // Both string length has to match
            if (s.Length != t.Length) return false;

            // Get an array for each 26 characters
            int[] charCounts = new int[26];

            // We will find index of each chartacter in array s and t
            // We will decude all with Value of char 'a' as its first chracter so index of current charact falls in from 0 to 26
            for (int i = 0; i < s.Length; i++)
            {
                // increament index for each character from array s
                // decrement index for each character from array t
                charCounts[s[i] - 'a']++;
                charCounts[t[i] - 'a']--;
            }

            // expecting finally there will be no index which has a value less than or greater than 0
            for (int i = 0; i < 26; i++)
            {
                if (charCounts[i] != 0) return false;
            }

            return true;
        }

        [TestCase("anagram", "nagaram", true)]
        [TestCase("rat", "car", false)]
        [TestCase("a", "ab", false)]
        [TestCase("aman", "nama", true)]

        public void IsAnagramTest(string Input1, string Input2, bool ExpectedOutPut)
        {
           Assert.AreEqual(ExpectedOutPut, IsAnagram(Input1, Input2));           
        }
        #endregion

        #region Reverse String

        /*
         *  https://leetcode.com/explore/interview/card/top-interview-questions-easy/127/strings/879/
         *  Write a function that reverses a string. The input string is given as an array of characters char[].

            Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.

            You may assume all the characters consist of printable ascii characters.

            Example 1:

            Input: ['h','e','l','l','o']
            Output: ['o','l','l','e','h']
            
            Example 2:

            Input: ['H','a','n','n','a','h']
            Output: ['h','a','n','n','a','H']

            Hint #1  
            
            The entire logic for reversing a string is based on using the opposite directional two-pointer approach!
         */

        public void ReverseString(char[] s)
        {
            // Idea is to travers in reverse starting from last index till mid
            // and compare index in loop with a local variable which in increasing with each cycle
            int index = 0;
            int midIndex = s.Length / 2;

            for (int i = s.Length -1; i >= midIndex; i--)
            {
                char c = s[i];
                s[i] = s[index];
                s[index++] = c;
            }
        }

        [Test]
        public void ReverseStringTest()
        {
            foreach (var spec in new[]{
                ( Input: new char[] { 'h','e','l','l','o'}, ExpectedOutPut: new int[] { 'o', 'l', 'l', 'e', 'h'}),
                ( Input: new char[] { 'H','a','n','n','a','h'}, ExpectedOutPut: new int[] { 'h','a','n','n','a','H'})
            })
            {
                ReverseString(spec.Input);

                Assert.AreEqual(spec.ExpectedOutPut, spec.Input);
            }
        }


        #endregion

        #region   First Unique Character in a String

        /*  https://leetcode.com/explore/interview/card/top-interview-questions-easy/127/strings/881/
         *  
         *  Given a string, find the first non-repeating character in it and return its index. If it doesn't exist, return -1.

            Examples:

            s = "leetcode"
            return 0.

            s = "loveleetcode"
            return 2.
 
            Note: You may assume the string contains only lowercase English letters.
         */

        public int FirstUniqChar_UsingDictionary(string s)
        {
            Dictionary<char, int> dictCharCounts = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (!dictCharCounts.ContainsKey(s[i]))
                {
                    dictCharCounts.Add(s[i], 1);
                }
                else
                {
                    dictCharCounts[s[i]] += 1;
                }
            }
            for (int i = 0; i < s.Length; i++)
            {
                if (dictCharCounts[s[i]] == 1) return i;
            }

            return -1;
        }

        [TestCase("aa", -1)]
        [TestCase("leetcode", 0)]
        [TestCase("loveleetcode", 2)]
        public void FirstUniqChar_UsingDictionary(string s, int expectedOutPut)
        {
            Assert.AreEqual(expectedOutPut, FirstUniqChar_UsingDictionary(s));
        }

        private int FirstUniqChar_UsingOneArray(string s) {

            int[] chars = new int[26];
            foreach (char c in s)
            {
                chars[c - 'a']++;
            }
            for (int i = 0; i < s.Length; i++)
            {
                if (chars[s[i] - 'a'] == 1)
                {
                    return i;
                }
            }
            return -1;
        }

        [TestCase("aa", -1)]
        [TestCase("leetcode", 0)]
        [TestCase("loveleetcode", 2)]
        public void FirstUniqChar_UsingOneArray(string s, int expectedOutPut)
        {
            Assert.AreEqual(expectedOutPut, FirstUniqChar_UsingOneArray(s));
        }
        #endregion

        #region 3. Longest Substring Without Repeating Characters

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

        public static int LengthOfLongestSubstring(string s)
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

            #endregion

            #region Brute Force Solution
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

        #region 20. Valid Parentheses

        // https://leetcode.com/problems/valid-parentheses/

        #region Problem Statement
        /*
            Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

            An input string is valid if:

            Open brackets must be closed by the same type of brackets.
            Open brackets must be closed in the correct order.


            Example 1:

                Input: s = "()"
                Output: true

            Example 2:

                Input: s = "()[]{}"
                Output: true

            Example 3:

                Input: s = "(]"
                Output: false

            Example 4:
            
                Input: s = "([)]"
                Output: false

            Example 5:

                Input: s = "{[]}"
                Output: true
 

            Constraints:

            1 <= s.length <= 104
            s consists of parentheses only '()[]{}'.
            */
        #endregion

        #endregion

        #region 647. Palindromic Substrings

        // https://leetcode.com/problems/palindromic-substrings/

        #region Problem Statement

        /*
            Given a string, your task is to count how many palindromic substrings in this string.

            The substrings with different start indexes or end indexes are counted as different substrings even they consist of same characters.

            Example 1:

            Input: "abc"
            Output: 3
            Explanation: Three palindromic strings: "a", "b", "c".
 
            Example 2:

            Input: "aaa"
            Output: 6
            Explanation: Six palindromic strings: "a", "a", "a", "aa", "aa", "aaa".
 

            Note:

            The input string length won't exceed 1000.
         */

        #endregion

        #endregion
    }
}
