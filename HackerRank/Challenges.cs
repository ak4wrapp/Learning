using HackerRank.Extentions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank
{
    [TestClass]
    public class Challenges
    {
        #region SockMerchant

        public static int SockMerchant(int totalNumber, int[] Socks)
        {
            var pairs = 0;
            var hash = new HashSet<int>();
            foreach (int sock in Socks)
            {
                if (!hash.Add(sock))
                {
                    pairs++;
                    hash.Remove(sock);
                }
            }
            return pairs;
        }

        #endregion

        #region CountingValleys

        public static int CountingValleys(int totalSteps, string inputStr)
        {
            if (string.IsNullOrEmpty(inputStr)) throw new ArgumentNullException();
            if (inputStr.Length < totalSteps) throw new ArgumentException("Input string cannot be less than total Steps");

            // Total Valleys Transversed
            int totalValleys = 0;

            // Current Level
            int currentLevel = 0;

            foreach (char step in inputStr)
            {
                currentLevel += GetLevelNumber(step);

                // If current Level is 0 and Gary is walking up, means he is just coming up from Valley
                if (currentLevel == 0 && IsSteppingUp(step))
                    totalValleys++;
            }

            return totalValleys;
        }

        private static int GetLevelNumber(char step)
        {
            if (IsSteppingUp(step))
                return 1;
            return -1;
        }
        private static bool IsSteppingUp(char step)
        {
            return String.Equals(step.ToString(), "U", StringComparison.OrdinalIgnoreCase);
        }

        [TestMethod]
        public void Test_CountingValleys()
        {
            foreach (var spec in new[]{
                ( totalSteps : 8, steps : "DDUUUUDD", expectedOutPut : 1 ),
                ( totalSteps : 8, steps : "UDDDUDUU",expectedOutPut : 1 ),
                ( totalSteps : 8, steps : "UUDDDDUU",expectedOutPut : 1 ),
                ( totalSteps : 14, steps : "DDDDUUUUDDUUDU", expectedOutPut : 3 )
            })
            {
                int output = CountingValleys(spec.totalSteps, spec.steps);

                Assert.AreEqual(spec.expectedOutPut, output);
            }

        }


        #endregion

        #region JumpingOnClouds

        public static int JumpingOnClouds(int[] clouds)
        {
            if (clouds == null || clouds.Length == 0) throw new ArgumentNullException();

            int totalJumps = 0;

            // We will be checking current and current + 1
            for (int i = 0; i < clouds.Length - 1; i++)
            {
                // if i+2 is 0, we directly jump to third
                // Also check only if there are atleast i+2 elements left
                if (i < clouds.Length - 2 && clouds[i + 2] == 0)
                {
                    // Make additional Jump
                    i++;
                }
                totalJumps++;
            }
            return totalJumps;
        }

        [TestMethod]
        public void Test_JumpingOnTheClouds()
        {
            foreach (var spec in new[]{
                ( clouds : new [] {0, 0, 0, 1, 0, 0}, expectedOutPut : 3 ),
                ( clouds : new [] {0, 0, 0, 0, 1, 0 }, expectedOutPut : 3 ),
                ( clouds : new [] {0, 0, 1, 0, 0, 1, 0}, expectedOutPut : 4 )
            })
            {
                int output = JumpingOnClouds(spec.clouds);

                Assert.AreEqual(spec.expectedOutPut, output);
            }
        }
        #endregion

        #region RepeatedString

        public static long CountRepeatedString(string inputStr, long numOfChars)
        {
            // If given string does not have 'a', then return 0
            if (inputStr.CountAs() == 0) return 0;

            long totalAs;
            if (numOfChars < inputStr.ToCharArray().Length)
            {
                inputStr = inputStr.Substring(0, Convert.ToInt32(numOfChars));

                totalAs = inputStr.CountAs();

                return totalAs;
            }

            // When numOfChars > inputStr.ToCharArray().Length
            // total number of A's in initial string
            totalAs = inputStr.CountAs();

            // Find the dividend of number of 
            var dividend = numOfChars / inputStr.ToCharArray().Length;
            totalAs *= dividend;

            var remainingChars = numOfChars - (dividend * inputStr.Length);
            var remainingAs = inputStr.Substring(0, Convert.ToInt32(remainingChars)).CountAs();

            totalAs += remainingAs;

            return totalAs;
        }

        [TestMethod]
        public void Test_RepeatedStringCount()
        {
            foreach (var spec in new[]{
                ( InputStr: "ababa", NumOfChars: 3, ExpectedOutPut: 2 ),
                ( InputStr: "epsxyyflvrrrxzvnoenvpegvuonodjoxfwdmcvwctmekpsnamchznsoxaklzjgrqruyzavshfbmuhdwwmpbkwcuomqhiyvuztwvq", NumOfChars: 549382313570, ExpectedOutPut: 16481469408 ),
                ( InputStr: "ceebbcb", NumOfChars : 817723, ExpectedOutPut: 0 ),
                ( InputStr: "aab", NumOfChars : 882787, ExpectedOutPut: 588525 ),
                ( InputStr: "aba", NumOfChars : 10, ExpectedOutPut: 7 ),
                ( InputStr: "a", NumOfChars : 1000000000000, ExpectedOutPut : 1000000000000 )
            })
            {
                long output = CountRepeatedString(spec.InputStr, spec.NumOfChars);

                Assert.AreEqual(spec.ExpectedOutPut, spec.ExpectedOutPut);
            }
        }

        #endregion

        #region Ice Cream Parlor
        // https://www.hackerrank.com/challenges/icecream-parlor/problem

        static int[] icecreamParlor(int m, int[] arr)
        {
            IDictionary<int, int> amountIndex = new Dictionary<int, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                int currentItemToLook = m - arr[i];
                if (amountIndex.ContainsKey(currentItemToLook)) return new int[] { amountIndex[currentItemToLook] + 1, i + 1 };
                amountIndex.Add(arr[i], i);

            }
            return new int[] { -1, -1 };
        }

        [TestMethod]
        public void IceCreamtParlorTest()
        {
            int[] flavors = new int[] { 1, 4, 5, 3, 2 };
            int money = 4;
            int[] expectedOutput = new int[] { 1, 4 };
            int[] actualOutput = icecreamParlor(money, flavors);

            CollectionAssert.AreEqual(expectedOutput, actualOutput);

            flavors = new int[] { 2, 2, 4, 3 };
            money = 4;
            expectedOutput = new int[] { 1, 2 };
            actualOutput = icecreamParlor(money, flavors);

            CollectionAssert.AreEqual(expectedOutput, actualOutput);
        }
        #endregion
    }
}
