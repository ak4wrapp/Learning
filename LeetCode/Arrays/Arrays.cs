using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Arrays
{
    public class Arrays
    {
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
        #endregion

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
    }
}
