using System;
using NUnit.Framework;
namespace CodingExcercises.Algorithms
{
    [TestFixture]
    public class Searching
    {
        #region Linear Search

        public int LinerarSearch(int[] inputArr, int searchNum)
        {
            for (int i = 0; i < inputArr.Length; i++)
            {
                if (inputArr[i] == searchNum) return i;
            }

            return -1;

        }

        [Test]
        public void LinerarSearchTest()
        {
            int[] inputArr = new int[] { 10, 20, 80, 30, 60, 50, 110, 100, 130, 170 };
            int searchNum1 = 110;
            int expectedOutput1 = 6;

            int searchNum2 = 175;
            int expectedOutput2 = -1;

            Assert.AreEqual(expectedOutput1, LinerarSearch(inputArr, searchNum1));
            Assert.AreEqual(expectedOutput2, LinerarSearch(inputArr, searchNum2));
        }

        #endregion

        #region Binary Search

        public int BinarySearch(int[] inputArr, int searchNum)
        {
            return BinarySearch(inputArr, searchNum, 0, inputArr.Length - 1);
        }

        private int BinarySearch(int[] inputArr, int searchNum, int leftIndex, int rightIndex)
        {
            if (rightIndex >= leftIndex)
            {
                int midIndex = leftIndex + (rightIndex -leftIndex) / 2;

                if (inputArr[midIndex] == searchNum) return midIndex;

                if (inputArr[midIndex] > searchNum) {
                    return BinarySearch(inputArr, searchNum, leftIndex, midIndex -1);
                }
                return BinarySearch(inputArr, searchNum, midIndex + 1, rightIndex);
            }
            return -1;
        }

        [Test]
        public void BinarySearchTest()
        {
            int[] inputArr = new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };

            Assert.AreEqual(4, BinarySearch(inputArr, 50));
            Assert.AreEqual(0, BinarySearch(inputArr, 10));
            Assert.AreEqual(1, BinarySearch(inputArr, 20));
            Assert.AreEqual(6, BinarySearch(inputArr, 70));
            Assert.AreEqual(8, BinarySearch(inputArr, 90));
            Assert.AreEqual(9, BinarySearch(inputArr, 100));
            Assert.AreEqual(-1, TernarySearch(inputArr, 175));
        }

        #endregion

        #region Ternary Search

        public int TernarySearch(int[] inputArr, int searchNum)
        {
            return TernarySearch(inputArr, searchNum, 0, inputArr.Length - 1);
        }

        private int TernarySearch(int[] inputArr, int searchNum, int leftIndex, int rightIndex)
        {
            if (rightIndex >= leftIndex)
            {
                int midIndex1 = leftIndex + (rightIndex - leftIndex) / 3;
                int midIndex2 = rightIndex - (rightIndex - leftIndex) / 3;

                if (inputArr[midIndex1] == searchNum) return midIndex1;
                if (inputArr[midIndex2] == searchNum) return midIndex2;

                if (inputArr[midIndex1] > searchNum)
                {
                    // Number is in first 1/3
                    return BinarySearch(inputArr, searchNum, leftIndex, midIndex1 - 1);
                }
                if (inputArr[midIndex1] < searchNum && searchNum < inputArr[midIndex2])
                {
                    // Number is in second 1/3
                    return BinarySearch(inputArr, searchNum, midIndex1 + 1, midIndex2);
                }
                // else number is in third 1/3
                return BinarySearch(inputArr, searchNum, midIndex2 + 1, rightIndex);
            }
            return -1;
        }

        [Test]
        public void TernarySearchTest()
        {
            int[] inputArr = new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };

            Assert.AreEqual(4, TernarySearch(inputArr, 50));
            Assert.AreEqual(0, TernarySearch(inputArr, 10));
            Assert.AreEqual(1, TernarySearch(inputArr, 20));
            Assert.AreEqual(6, TernarySearch(inputArr, 70));
            Assert.AreEqual(8, TernarySearch(inputArr, 90));
            Assert.AreEqual(9, TernarySearch(inputArr, 100));
            Assert.AreEqual(-1, TernarySearch(inputArr, 175));
        }

        #endregion
    }
}
