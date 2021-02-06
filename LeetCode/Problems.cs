using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    [TestFixture]
    public class Problems
    {

        #region Return all possible Subsets from given Array of Numbers
        /*  https://leetcode.com/problems/subsets/description/
         *  
         *  Given an integer array nums of unique elements, return all possible subsets (the power set).

            The solution set must not contain duplicate subsets. Return the solution in any order.

            Example 1:

            Input: nums = [1,2,3]
            Output: [[],[1],[2],[1,2],[3],[1,3],[2,3],[1,2,3]]

            Example 2:

            Input: nums = [0]
            Output: [[],[0]]
 
            Constraints:

            1 <= nums.length <= 10
            -10 <= nums[i] <= 10
            All the numbers of nums are unique.
         */

        public IList<IList<int>> Subsets(int[] nums)
        {
            List<IList<int>> res = new List<IList<int>>
            {
                // Always return an empty Array as first element
                new List<int>()
            };

            if (nums == null || nums.Length == 0) return res;

            for (int i = 0; i < nums.Length; i++)
            {
                int count = res.Count;

                for (int j = 0; j < count; j++)
                {
                    List<int> subList = new List<int>(res[j]);
                    subList.Add(nums[i]);
                    res.Add(subList);
                }

                #region explanation

                // Pick all elements from result array and append current element to create a new list
                /*
                 *  res[] = [[]];
                 *  iterating through all elements on nums input, 3 in case [1,2,3]
                 *  
                 *  ==iteration 1==
                 *  
                 *  res is = [[]]
                 *  i=0; nums[i] is 1; j loop will run(res.Count = 1) times 
                 *  
                 *  j=0
                 *      subList = new List<int>(res[j]) is new SubList with value {[]}, 
                 *      subList.Add(nums[i]) 
                 *      subList ignores empty array and becomes [1]
                 *      added [1] to res list
                 *      res is now [[][1]]
                 *  
                 *  ==iteration 2==
                 *  
                 *  res is = [[][1]]
                 *  i=1; nums[i] is 2; j loop will run(res.Count = 2) times
                 *  
                 *  j=0
                 *      subList = new List<int>(res[j]) is new SubList with value {[]}, 
                 *      subList.Add(nums[i] which is 2) 
                 *      subList ignores empty array and becomes [2]
                 *      added [2] to res list 
                 *      res is now [[][2]]
                 *  j=1
                 *      subList = new List<int>(res[j]) is new SubList with value {[1]}, 
                 *      subList.Add(nums[i] which is 2) 
                 *      subList becomes [1,2]
                 *      added [1,2] to res list 
                 *      res is now [[][1][2][1,2]]
                 *      
                 *  ==iteration 3==
                 *  
                 *  res is = [[][1][2][1,2]]
                 *  i=2; nums[i] is 3; j loop will run(res.Count = 4) times
                 *  
                 *  j=0 on res [[][1][2][1,2]]
                 *      subList = new List<int>(res[j]) is new SubList with value {[]}, 
                 *      subList.Add(nums[i] which is 3) 
                 *      subList ignores empty array and becomes [3]
                 *      added [3] to res list 
                 *      res is now [[][1][2][1,2][3]]
                 *  j=1 on res [[][1][2][1,2][3]]
                 *      subList = new List<int>(res[j]) is new SubList with value {[1]}, 
                 *      subList.Add(nums[i] which is 3) 
                 *      subList becomes [1,3]
                 *      added [1,3] to res list 
                 *      res is now [[][1][2][1,2][3][1,3]]
                 *  
                 *  j=2 on res [[][1][2][1,2][3][1,3]]
                 *      subList = new List<int>(res[j]) is new SubList with value {[2]}, 
                 *      subList.Add(nums[i] which is 3) 
                 *      subList becomes [2,3]
                 *      added [2,3] to res list 
                 *      res is now [[][1][2][1,2][3][1,3][2,3]]
                 *      
                 *  j=3 on res [[][1][2][1,2][3][1,3][2,3]]
                 *      subList = new List<int>(res[j]) is new SubList with value {[1,2]}, 
                 *      subList.Add(nums[i] which is 3) 
                 *      subList becomes [1,2,3]
                 *      added [1,2] to res list 
                 *      res is now [[][1][2][1,2][3][1,3][2,3],[1,2,3]]
                 */

                #endregion

            }
            return res;
        }

        [Test]
        public void Subsets()
        {
            foreach (var spec in new[] {
                (   Input: new int[] { 0 },
                    OutPut: new List<IList<int>> {
                                                    new List<int>(),
                                                    new List<int>() { 0 }
                                                 }
                ),
                (   Input: new int[] { 1, 2, 3 },
                    OutPut: new List<IList<int>> {
                                                    new List<int>(),
                                                    new List<int>() { 1 },
                                                    new List<int>() { 2 },
                                                    new List<int>() { 1, 2 },
                                                    new List<int>() { 3 },
                                                    new List<int>() { 1, 3 },
                                                    new List<int>() { 2, 3 },
                                                    new List<int>() { 1, 2, 3 }
                                                 }
                )
            })
            {
                Assert.AreEqual(spec.OutPut, Subsets(spec.Input));
            }
        }
        #endregion

        #region 953. Verifying an Alien Dictionary
        /*  
         *  https://leetcode.com/problems/verifying-an-alien-dictionary/
         *  
         *  In an alien language, surprisingly they also use english lowercase letters, but possibly in a different order. The order of the alphabet is some permutation of lowercase letters.

            Given a sequence of words written in the alien language, and the order of the alphabet, return true if and only if the given words are sorted lexicographicaly in this alien language.

            Example 1:

            Input: words = ["hello","leetcode"], order = "hlabcdefgijkmnopqrstuvwxyz"
            Output: true
            Explanation: As 'h' comes before 'l' in this language, then the sequence is sorted.

            Example 2:

            Input: words = ["word","world","row"], order = "worldabcefghijkmnpqstuvxyz"
            Output: false
            Explanation: As 'd' comes after 'l' in this language, then words[0] > words[1], hence the sequence is unsorted.

            Example 3:

            Input: words = ["apple","app"], order = "abcdefghijklmnopqrstuvwxyz"
            Output: false
            Explanation: The first three characters "app" match, and the second string is shorter (in size.) According to lexicographical rules "apple" > "app", because 'l' > '∅', where '∅' is defined as the blank character which is less than any other character (More info).
 

            Constraints:

            1 <= words.length <= 100
            1 <= words[i].length <= 20
            order.length == 26
            All characters in words[i] and order are English lowercase letters.
         */


        public bool IsAlienSorted(string[] words, string order)
        {
            int[] charIndex = new int[26];

            for (int i = 0; i < order.Length; i++)
            {
                charIndex[order[i] - 'a'] = i;
            }

            for (int i = 0; i < words.Length; i++)
            {
                for (int j = 1; j < words.Length; j++)
                {
                    int wordLengthToCompare = Math.Min(words[i].Length, words[j].Length);

                    for (int k = 0; k < wordLengthToCompare; k++)
                    {
                        char iChar = words[i][k];
                        char jChar = words[j][k];
                        if (charIndex[iChar - 'a'] < charIndex[jChar - 'a']) break;
                        else if (charIndex[iChar - 'a'] > charIndex[jChar - 'a']) return false;
                        else if (k == wordLengthToCompare - 1 && words[i].Length > words[j].Length)
                            return false;

                    }
                }

            }
            return true;
        }

        [TestCase(new string[] { "hello", "leetcode" }, "hlabcdefgijkmnopqrstuvwxyz", true)]
        [TestCase(new string[] { "word", "world", "row" }, "worldabcefghijkmnpqstuvxyz", false)]
        [TestCase(new string[] { "apple", "app" }, "abcdefghijklmnopqrstuvwxyz", false)]
        public void IsAlienSorted(string[] Words, string Order, bool ExpectedOutput)
        {
            Assert.AreEqual(ExpectedOutput, IsAlienSorted(Words, Order));
        }
        #endregion
    }
}
