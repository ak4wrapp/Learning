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
    }
}
