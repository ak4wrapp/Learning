using System;
using NUnit.Framework;

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
                charCounts[s[i] - 97]++;
                charCounts[t[i] - 97]--;
            }

            // expecting finally there will be no index which has a value less than or greater than 0
            for (int i = 0; i < 26; i++)
            {
                if (charCounts[i] != 0) return false;
            }

            return true;
        }

        [Test]
        public void IsAnagramTest()
        {
            foreach (var spec in new[]{
                ( Input1: "anagram", Input2: "nagaram", ExpectedOutPut: true),
                ( Input1: "rat", Input2: "car", ExpectedOutPut: false),
                ( Input1: "a", Input2: "ab", ExpectedOutPut: false),
                ( Input1: "aman", Input2: "nama", ExpectedOutPut: true),
            })
            {
                Assert.AreEqual(spec.ExpectedOutPut, IsAnagram(spec.Input1, spec.Input2));
            }
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
    }
}
