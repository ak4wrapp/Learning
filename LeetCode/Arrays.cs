using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Concurrent;
using System.Linq;

namespace LeetCode
{
    public class Arrays
    {
        #region Remove Duplicates from Sorted Array

        #region Problem Statement
        /*
            https://leetcode.com/problems/remove-duplicates-from-sorted-array/
         
            Given a sorted array nums, remove the duplicates in-place such that each element appears only once and returns the new length.

            Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.

            Clarification:

            Confused why the returned value is an integer but your answer is an array?

            Note that the input array is passed in by reference, which means a modification to the input array will be known to the caller as well.

            Internally you can think of this:

            // nums is passed in by reference. (i.e., without making a copy)
            int len = removeDuplicates(nums);

            // any modification to nums in your function would be known by the caller.
            // using the length returned by your function, it prints the first len elements.
            for (int i = 0; i < len; i++) {
                print(nums[i]);
            }
 

            Example 1:

            Input: nums = [1,1,2]
            Output: 2, nums = [1,2]
            Explanation: Your function should return length = 2, with the first two elements of nums being 1 and 2 respectively. It doesn't matter what you leave beyond the returned length.
            Example 2:

            Input: nums = [0,0,1,1,1,2,2,3,3,4]
            Output: 5, nums = [0,1,2,3,4]
            Explanation: Your function should return length = 5, with the first five elements of nums being modified to 0, 1, 2, 3, and 4 respectively. It doesn't matter what values are set beyond the returned length.
 

            Constraints:

            0 <= nums.length <= 3 * 104
            -104 <= nums[i] <= 104
            nums is sorted in ascending order.
            */
        #endregion

        public static int RemoveDuplicates(int[] nums)
        {
            if (nums == null || nums.Length < 1) return 0;
            if (nums.Length == 1) return 1;

            int i = 0;
            for (int j = 1; j < nums.Length; j++)
            {
                if (nums[j] != nums[i])
                {
                    i++;
                    nums[i] = nums[j];
                }
            }
            return i + 1;
        }

        [Test]
        public void RemoveDuplicatesTest()
        {
            foreach (var spec in new[]{
                ( InputStr: new int[] { 1, 1, 2, 3, 3, 4, 5, 6, 6, 7}, ExpectedOutPut: 7),
                ( InputStr: new int[] { 1, 1, 2, 3, 4, 5, 6}, ExpectedOutPut: 6)
            })
            {
                int duplicateCount = RemoveDuplicates(spec.InputStr);

                Assert.AreEqual(duplicateCount, spec.ExpectedOutPut);
            }
        }

        #endregion

        # region ContainsDuplicate
        public static bool ContainsDuplicate_LinearSearch(int[] nums)
        {
            for (int i = 0; i < nums.Length; ++i)
            {
                for (int j = 0; j < i; ++j)
                {
                    if (nums[j] == nums[i]) return true;
                }
            }
            return false;
        }

        public static bool ContainsDuplicate_Sorting(int[] nums)
        {
            Array.Sort(nums);
            for (int i = 0; i < nums.Length - 1; ++i)
            {
                if (nums[i] == nums[i + 1]) return true;
            }
            return false;
        }

        public static bool ContainsDuplicate_HashSet(int[] nums)
        {
            var hashSet = new HashSet<int>(nums);
            return hashSet.Count != nums.Length;
        }

        [Test]
        public void ContainsDuplicate_LinearSearchTest()
        {
            foreach (var spec in new[]{
                ( InputStr: new int[] { 1, 1, 2}, ExpectedOutPut: true),
                ( InputStr: new int[] { 1, 2, 3, 4, 5, 6, 7}, ExpectedOutPut: false),
                ( InputStr: new int[] { 1, 2, 3, 4, 5, 4}, ExpectedOutPut: true),
                ( InputStr: new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 1}, ExpectedOutPut: true)
            })
            {
                bool hasDuplicates = ContainsDuplicate_LinearSearch(spec.InputStr);

                Assert.AreEqual(hasDuplicates, spec.ExpectedOutPut);
            }
        }

        [Test]
        public void ContainsDuplicate_SortingTest()
        {
            foreach (var spec in new[]{
                ( InputStr: new int[] { 1, 1, 2}, ExpectedOutPut: true),
                ( InputStr: new int[] { 1, 2, 3, 4, 5, 6, 7}, ExpectedOutPut: false),
                ( InputStr: new int[] { 1, 2, 3, 4, 5, 4}, ExpectedOutPut: true),
                ( InputStr: new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 1}, ExpectedOutPut: true)
            })
            {
                bool hasDuplicates = ContainsDuplicate_Sorting(spec.InputStr);

                Assert.AreEqual(hasDuplicates, spec.ExpectedOutPut);
            }
        }

        [Test]
        public void ContainsDuplicate_HashSetTest()
        {
            foreach (var spec in new[]{
                ( InputStr: new int[] { 1, 1, 2}, ExpectedOutPut: true),
                ( InputStr: new int[] { 1, 2, 3, 4, 5, 6, 7}, ExpectedOutPut: false),
                ( InputStr: new int[] { 1, 2, 3, 4, 5, 4}, ExpectedOutPut: true),
                ( InputStr: new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 1}, ExpectedOutPut: true)
            })
            {
                bool hasDuplicates = ContainsDuplicate_HashSet(spec.InputStr);

                Assert.AreEqual(hasDuplicates, spec.ExpectedOutPut);
            }
        }

        #endregion

        #region Single Number
        public static int SingleNumber(int[] nums)
        {
            ConcurrentDictionary<int, int> dictOccurrances = new ConcurrentDictionary<int, int>();
            foreach (var num in nums)
            {
                dictOccurrances.AddOrUpdate(num, 1, (key, value) => value + 1);
            }

            return dictOccurrances.Where(p => p.Value == 1).First().Key;
        }

        [Test]
        public void SingleNumberTest()
        {
            foreach (var spec in new[]{
                ( InputStr: new int[] { 1, 1, 2}, ExpectedOutPut: 2),
                ( InputStr: new int[] { 1, 2, 3, 4, 5, 6, 7}, ExpectedOutPut: 1),
                ( InputStr: new int[] { 1, 2, 3, 1, 2, 1}, ExpectedOutPut: 3)
            })
            {
                int singleNumber = SingleNumber(spec.InputStr);

                Assert.AreEqual(singleNumber, spec.ExpectedOutPut);
            }
        }
        #endregion

        #region Increament Given Array Sum by 1
        public static int[] Add1ToArray(int[] digits)
        {
            if (digits == null) return null;
            if (digits.Length == 0) return new int[] { 1 };
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (digits[i] != 9)
                {
                    digits[i]++;
                    return digits; // As soon as we get a a number less than 9, increament it and return
                }
                else digits[i] = 0;
            }
            // Will reach here only when all numbers were 9 in Array so we set all to 0

            // create a new array with increamented index
            int[] retVal = new int[digits.Length + 1];
            // set fist one as 1
            retVal[0] = 1;
            return retVal;

            // If you don't want to create a new Array then uncomment below
            //Array.Resize(ref digits, digits.Length + 1);
            //digits[0] = 1;
            //return digits;
        }
        [Test]
        public void Add1ToArrayTest()
        {
            foreach (var spec in new[]{
                ( InputStr: new int[] { 1, 1, 2}, ExpectedOutPut: new int[] { 1, 1, 3}),
                ( InputStr: new int[] { 9, 9 }, ExpectedOutPut: new int[] { 1, 0, 0 }),
                ( InputStr: new int[] { 9, 9, 8 }, ExpectedOutPut: new int[] { 9, 9, 9 }),
                ( InputStr: new int[] { 9, 8, 9 }, ExpectedOutPut: new int[] { 9, 9, 0 }),
                ( InputStr: new int[] { 1, 9, 9 }, ExpectedOutPut: new int[] { 2, 0, 0 })
            })
            {
                var singleNumber = Add1ToArray(spec.InputStr);

                Assert.AreEqual(singleNumber, spec.ExpectedOutPut);
            }
        }

        #endregion

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
            /*  How we plan to solve it
             *  
             *  We know numbers are between range of 1 to length of array
             *  We will browse througha all numbers and flag each number at i-1 index as negative
             *  netx time when same number appear we will find index (i-1) as negative number
             *  so we will know this number is duplicate
             */
            List<int> duplicateNumbers = new List<int>();
            if (nums == null || nums.Length == 0)
                return duplicateNumbers;
            for (int i = 0; i < nums.Length; i++)
            {
                int index = Math.Abs(nums[i]) - 1;
                // Check if number at index i is already found and has a value less than 0
                if (nums[index] < 0)
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
                ( Input: new List<int>(){4,3,2,7,8,2,3,1}, ExpectedOutPut: new List<int>(){2,3 } )
            })
            {
                var result = FindDuplicates(spec.Input.ToArray());
                Assert.AreEqual(spec.ExpectedOutPut, result); ;
            }
        }
        #endregion

        #region Move Zeros

        #region Problem Statement
        /*
            https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/567/
         
            Given an array nums, write a function to move all 0's to the end of it while maintaining the relative order of the non-zero elements.

            Example:

            Input: [0,1,0,3,12]
            Output: [1,3,12,0,0]

            Note:

            You must do this in-place without making a copy of the array.
            Minimize the total number of operations.

            Hint # 1

            In-place means we should not be allocating any space for extra array.
            But we are allowed to modify the existing array.
            However, as a first step, try coming up with a solution that makes use of additional space.
            For this problem as well, first apply the idea discussed using an additional array and the in-place
            solution will pop up eventually.

            Hint # 2

            A two-pointer approach could be helpful here.
            The idea would be to have one pointer for iterating the array and
            another pointer that just works on the non-zero elements of the array.
            */
        #endregion


        public void MoveZeroes(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    for (int j = i; j > 0 && nums[j - 1] == 0; j--)
                    {
                        nums[j - 1] = nums[j];
                        nums[j] = 0;
                    }
                }
            }
        }

        [TestCase(new int[] { 0, 0, 1, 0, 2 }, new int[] { 1, 2, 0, 0, 0 })]
        [TestCase(new int[] { 0, 1, 0, 3, 12 }, new int[] { 1, 3, 12, 0, 0 })]
        public void MoveZeroesTest(int[] Input, int[] Output)
        {
            MoveZeroes(Input);
            Assert.AreEqual(Output, Input);
        }
        #endregion

        #region Remove Duplicates from Sorted Array Attempt2

        public static int RemoveDuplicatesAttempt2(int[] nums)
        {
            if (nums == null || nums.Length < 1) return 0;
            if (nums.Length == 1) return 1;

            int dups = 1;
            // We can start with first element as its sorted array
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > nums[dups - 1])
                {
                    nums[dups] = nums[i];
                    dups++;
                }

            }
            return dups;
        }

        [TestCase(new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 }, 5)]
        [TestCase(new int[] { 1, 1, 2 }, 2)]
        public void RemoveDuplicatesAttempt2Test(int[] Input, int ExpectedOutPut)
        {

            Assert.AreEqual(ExpectedOutPut, RemoveDuplicatesAttempt2(Input));
        }

        #endregion

        #region Best Time to Buy and Sell Stock

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

        public static int MaxProfit(int[] prices)
        {
            int profit = 0;
            int lastBuyPrice = 0;

            bool isBuying = true;

            for (int i = 0; i < prices.Length; i++)
            {
                if (isBuying)
                {
                    for (int j = i + 1; j < prices.Length; j++)
                    {
                        if (prices[j] < prices[i]) i = j;
                        else break;
                    }
                    if (i == prices.Length - 1) return profit;

                    lastBuyPrice = prices[i];
                    isBuying = false;
                }
                else
                {
                    // int upcomingHighestPriceIndex = i;
                    for (int j = i + 1; j < prices.Length; j++)
                    {
                        if (prices[j] > prices[i]) i = j;
                        else break;
                    }

                    profit += prices[i] - lastBuyPrice;
                    isBuying = true;
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

        public static int MaxProfitOptimized(int[] prices)
        {
            int profit = 0;

            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] > prices[i - 1])
                {
                    profit += prices[i] - prices[i - 1];
                }
            }

            return profit;
        }

        [TestCase(new int[] { 9, 8, 7, 7, 10 }, 3)]
        [TestCase(new int[] { 7, 1, 5, 3, 6, 4 }, 7)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4)]
        [TestCase(new int[] { 7, 6, 4, 3, 1 }, 0)]
        public void MaxProfitOptimizedTest(int[] prices, int ExpectedoutPut)
        {
            Assert.AreEqual(ExpectedoutPut, MaxProfitOptimized(prices));
        }
        #endregion
    }
}
