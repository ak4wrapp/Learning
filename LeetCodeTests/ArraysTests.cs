using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using LeetCode.Arrays;

namespace LeetCodeTests
{
    public class ArraysTests
    {
        [SetUp]
        public void Setup()
        {

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
                int duplicateCount = Arrays.RemoveDuplicates(spec.InputStr);

                Assert.AreEqual(duplicateCount, spec.ExpectedOutPut);
            }
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
                bool hasDuplicates = Arrays.ContainsDuplicate_LinearSearch(spec.InputStr);

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
                bool hasDuplicates = Arrays.ContainsDuplicate_Sorting(spec.InputStr);

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
                bool hasDuplicates = Arrays.ContainsDuplicate_HashSet(spec.InputStr);

                Assert.AreEqual(hasDuplicates, spec.ExpectedOutPut);
            }
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
                int singleNumber = Arrays.SingleNumber(spec.InputStr);

                Assert.AreEqual(singleNumber, spec.ExpectedOutPut);
            }
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
                var singleNumber = Arrays.Add1ToArray(spec.InputStr);

                Assert.AreEqual(singleNumber, spec.ExpectedOutPut);
            }
        }
        
    }
}
