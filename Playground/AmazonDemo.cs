using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Playground
{
    [TestClass]
    public class AmazonDemo
    {
        #region CellCompete

        private int[] CellCompeteCopied(int[] states, int days)
        {
            //First create an array with an extra 2 cells (these represent the empty cells on either end)
            int[] inputArray = new int[states.Length + 2];

            //Copy the cell array into the new input array leaving the value of the first and last indexes as zero (empty cells)
            Array.Copy(states, 0, inputArray, 1, states.Length);

            //This is cool I stole this from the guy above! (cheers mate), this decrements the day count while checking that we are still above zero.
            while (days-- > 0)
            {
                int oldCellValue = 0;

                //In this section we loop through the array starting at the first real cell and going to the last real cell
                //(we are not including the empty cells at the ends which are always inactive/0)

                for (int i = 1; i < inputArray.Length - 1; i++)
                {
                    //if the cells below and above our current index are the same == then the target cell will be inactive/0
                    //otherwise if they are different then the target cell will be set to active/1
                    //NOTE: before we change the index value to active/inactive state we are saving the cells oldvalue to a variable so that
                    //we can use that to do the next "cell competition" comparison (this fulfills the requirement to update the values at the same time)

                    if (oldCellValue == inputArray[i + 1])
                    {
                        oldCellValue = inputArray[i];
                        inputArray[i] = 0;
                    }
                    else
                    {
                        oldCellValue = inputArray[i];
                        inputArray[i] = 1;
                    }
                }
            }

            //Finally we create a new output array that doesn't include the empty cells on each end
            //copy the input array to the output array and Bob's yer uncle ;)...(comments are lies)

            int[] outputArray = new int[states.Length];
            Array.Copy(inputArray, 1, outputArray, 0, outputArray.Length);
            return outputArray;
        }

        private int[] CellCompete(int[] states, int days)
        {
            int[] newStates = new int[states.Length];
            Array.Copy(states, 0, newStates, 0, states.Length);

            int currentDay = 1;

            while (currentDay <= days)
            {
                int prevCellVal = 0;

                for (int i = 0; i < states.Length; i++)
                {
                    // Last Element
                    if (i == states.Length - 1)
                    {
                        // Just check if previous cell is InActive
                        // then set current cell active too 
                        // (because the right most vacant cell is inactive)
                        if (prevCellVal == 0)
                        {
                            prevCellVal = states[i];
                            states[i] = 0;
                        }
                        else {
                            prevCellVal = states[i];
                            states[i] = 1;
                        }
                    }
                    else
                    {
                        if (prevCellVal == states[i + 1]) {
                            prevCellVal = states[i];
                            states[i] = 0;
                        }
                        else
                        {
                            prevCellVal = states[i];
                            states[i] = 1;
                        }
                    }
                }

                currentDay++;
            }

            return states;
        }

        [TestMethod]
        public void CellCompeteTest()
        {
            var DAYS = 1;
            var input = new int[] { 1, 0, 0, 0, 0, 1, 0, 0 };
            var expectedoutPut = new int[] { 0, 1, 0, 0, 1, 0, 1, 0 };

            var output = CellCompeteCopied(input, DAYS);
            Assert.AreEqual(string.Join(",", expectedoutPut), string.Join(",", output));

            output = CellCompete(input, DAYS);
            Assert.AreEqual(string.Join(",", expectedoutPut), string.Join(",", output));

            DAYS = 2;
            input = new int[] { 1, 1, 1, 0, 1, 1, 1, 1 };
            expectedoutPut = new int[] { 0, 0, 0, 0, 0, 1, 1, 0 };

            output = CellCompeteCopied(input, DAYS);
            Assert.AreEqual(string.Join(",", expectedoutPut), string.Join(",", output));

            output = CellCompete(input, DAYS);
            Assert.AreEqual(string.Join(",", expectedoutPut), string.Join(",", output));
        }


        #endregion

        #region GCD

        private int Gcd(int a, int b)
        {
            if (a == 0)
                return b;
            return Gcd(b % a, a);
        }
        public int GeneralizedGCD(int num, int[] arr)
        {
            int result = arr[0];
            for (int i = 1; i < num; i++)
                result = Gcd(arr[i], result);

            return result;
        }

        [TestMethod]
        public void GeneralizedGCDTest()
        {
            int[] arr = { 2, 4, 6, 8, 16 };
            int num = arr.Length;

            var expectedOutPut = 2;
            var output = GeneralizedGCD(num, arr);

            Assert.AreEqual(expectedOutPut, output);
        }
        #endregion

        #region PrioritizeOrders

        private struct AmazonOrderInfo {
            public string OrderId { get; set; }
            public string MetaData { get; set; }

            public string OriginalOrderId { get; set; }

            public bool isPrime { get; set; }
        }

        public List<string> PrioritizedOrders(int numOrders, string[] orderList)
        {
            // Problem Statement

            // Order
            // OrderId: Alphanumeric
            // Metadata: string: 
            //          Prime: 'a b c', non-Prime: '1 2 3'
            // e.g. AZNZ123 A B C (Prime)
            //      AZNZ124 1 2 3 (Non Prime)

            // 1. PRIME Orders returned first (alphabetic metadata)
            // 2. Order by alphabetic metadata then orderid
            // 3. Everything else in same order as provided
            if (numOrders <= 1) return orderList.ToList();

            List<AmazonOrderInfo> processedOrders = new List<AmazonOrderInfo>();
            bool hasPrimeOrders = false;
            foreach (string order in orderList)
            {
                string orderId = order.Split(" ")[0];
                string metaData = string.Join("", order.Split(" ").Skip(1));
                bool isPrimeOrder = !int.TryParse(metaData, out int n);

                processedOrders.Add(
                        new AmazonOrderInfo()
                        {
                            OriginalOrderId = order,
                            MetaData = metaData,
                            OrderId = orderId,
                            isPrime = isPrimeOrder
                        });

                if (isPrimeOrder) hasPrimeOrders = true;
            }

            if (hasPrimeOrders) {
                var primeOrders = processedOrders
                                        .Where(x => x.isPrime)
                                        .OrderBy(x => x.MetaData)
                                        .ThenBy(x => x.OrderId);

                var nonPrimeOrders = processedOrders
                                            .Where(x => !x.isPrime);

                return primeOrders.Concat(nonPrimeOrders).Select(x => x.OriginalOrderId).ToList();
            }


            return orderList.ToList();
        }

        [TestMethod]
        public void PrioritizedOrdersTest()
        {
            var TOTAL_ORDERS = 4;
            var inputArr = new string[] { "mi2 jog mid pet", "wz3 34 54 398", "a1 alps cow bar", "x4 45 21 7" };
            var expecedOutput = new string[] { "a1 alps cow bar", "mi2 jog mid pet", "wz3 34 54 398", "x4 45 21 7" };
            var output = PrioritizedOrders(TOTAL_ORDERS, inputArr);

            Console.WriteLine(string.Join(",", output));

            inputArr = new string[] { "mi2 1 2 3", "wz3 34 54 398", "a1 6 7 8", "x4 45 21 7" };
            expecedOutput = new string[] { "mi2 1 2 3", "wz3 34 54 398", "a1 6 7 8", "x4 45 21 7" };
            output = PrioritizedOrders(TOTAL_ORDERS, inputArr);

            Console.WriteLine(string.Join(",", output));
        }
        #endregion

        #region minimumDistance
        public int MinimumDistance(int numRows, int numColumns, int[,] area)
        {
            int areaCounter = 0;
            for (int i = 0; i < numRows; i++)
            {
                for (int x = 0; x < numColumns; x++)
                {
                    // Reached Destination
                    if (area[i, x] == 9) return areaCounter;

                    //Accessible counter++
                    if (area[i, x] == 1) areaCounter++;
                }
            }
            return -1;
        }

        [TestMethod]
        public void MinimumDistanceTest()
        {
            //int numRows = 3;
            //int numColumns = 3;

            //int[,] area = new int[,]
            //{
            //    {1, 0, 0},
            //    {1, 0, 0},
            //    {1, 9, 0}
            //};

            int numRows = 5;
            int numColumns = 4;

            int[,] area = new int[,]
            {
                {1, 1, 1, 1},
                {0, 1, 1, 1},
                {0, 1, 0, 1},
                {1, 1, 9, 1},
                {0, 0, 1, 1}
            };

            int output = MinimumDistance(numRows, numColumns, area);
            // WRITE YOUR CODE HERE
        }
        #endregion
    }
}
