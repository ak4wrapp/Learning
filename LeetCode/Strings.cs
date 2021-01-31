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

        #region Reverse String

        /*
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
