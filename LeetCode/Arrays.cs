using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Concurrent;
using System.Linq;

namespace LeetCode
{
    public class ArraysTests
    {
        #region RemoveDuplicates
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
                ( InputStr: new int[] { 1, 1, 2}, ExpectedOutPut: 2),
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

    }
}
