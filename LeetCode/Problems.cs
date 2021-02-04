using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    [TestFixture]
    public class Problems
    {

        #region Subsets
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
    }
}
