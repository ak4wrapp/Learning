using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    [TestFixture]
    public class Problems
    {
        #region Find all duplicates in Array
        /*
         *  https://leetcode.com/problems/find-all-duplicates-in-an-array/
            Given an array of integers, 1 ≤ a[i] ≤ n (n = size of array), some elements appear twice and others appear once.

            Find all the elements that appear twice in this array.

            Could you do it without extra space and in O(n) runtime?

            Example:
            Input:
            [4,3,2,7,8,2,3,1]

            Output:
            [2,3]
        */

        public IList<int> FindDuplicates(int[] nums)
        {
            List<int> duplicateNumbers = new List<int>();
            if (nums == null || nums.Length == 0)
                return duplicateNumbers;

            int index = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                index = Math.Abs(nums[i]) - 1;
                // Check if number at index i is already found and has a value less than 0
                if (nums[i] < 0 && !duplicateNumbers.Contains(nums[i]))
                {
                    // number was updated earlier hence its a duplicate one this time
                    duplicateNumbers.Add(index + 1);
                }

                nums[index] = -nums[index];
            }
            return duplicateNumbers;
        }

        [Test]
        public void FindDuplicatesTest()
        {
            foreach (var spec in new[]{
                ( Input: new List<int>(){4,3,2,7,8,2,3,1 }, ExpectedOutPut: new List<int>(){2,3 } )
            })
            {
                var result = FindDuplicates(spec.Input.ToArray());
                Assert.AreEqual(spec.ExpectedOutPut, result); ;
            }
        }
        #endregion
    }
}
