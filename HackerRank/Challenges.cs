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
                // If amount is more than the total monet we have, continue to next one
                if (arr[i] > m) continue;

                int currentItemToLook = m - arr[i];
                if (amountIndex.ContainsKey(currentItemToLook)) return new int[] { amountIndex[currentItemToLook] + 1, i + 1 };

                // If there is a duplicate not needed number, we will update index to avoid Runtime error
                if (amountIndex.ContainsKey(arr[i])) amountIndex[arr[i]] = i;
                else amountIndex.Add(arr[i], i);

            }
            return new int[] { -1, -1 };
        }

        [TestMethod]
        public void IceCreamtParlorTest()
        {
            foreach (var spec in new[] {
                (money: 4, flavors: new int[] { 1, 4, 5, 3, 2 }, expectedOutput: new int[] { 1, 4 }),
                (money: 4, flavors: new int[] { 2, 2, 4, 3 }, expectedOutput: new int[] { 1, 2  }),
                (money: 100,
                    flavors: new int[] { 25, 75, 100 },
                    expectedOutput: new int[] { 1, 2  }),
                (money: 200,
                    flavors: new int[] { 150, 24, 79, 50, 88, 345, 3 },
                    expectedOutput: new int[] { 1, 4 }),
                (money: 8,
                    flavors: new int[] { 2 ,1 ,9 ,4 ,4 ,56 ,90 ,3 },
                    expectedOutput: new int[] { 4,5  }),
                (money: 542,
                    flavors: new int[] { 230,863,916,585,981,404,316,785,88,12,70,435,384,778,887,755,740,337,86,92,325,422,815,650,920,125,277,336,221,847,168,23,677,61,400,136,874,363,394,199,863,997,794,587,124,321,212,957,764,173,314,422,927,783,930,282,306,506,44,926,691,568,68,730,933,737,531,180,414,751,28,546,60,371,493,370,527,387,43,541,13,457,328,227,652,365,430,803,59,858,538,427,583,368,375,173,809,896,370,789 },
                    expectedOutput: new int[] { 29,46  }),
                (money: 789,
                    flavors: new int[] { 591,955,829,805,312,83,764,841,12,744,104,773,627,306,731,539,349,811,662,341,465,300,491,423,569,405,508,802,500,747,689,506,129,325,918,606,918,370,623,905,321,670,879,607,140,543,997,530,356,446,444,184,787,199,614,685,778,929,819,612,737,344,471,645,726 },
                    expectedOutput: new int[] { 11,56  }),
                (money: 101,
                    flavors: new int[] { 722,600,905,54,47 },
                    expectedOutput: new int[] { 4,5  }),
                (money: 35, flavors: new int[] { 210,582,622,337,626,580,994,299,386,274,591,921,733,851,770,300,380,225,223,861,851,525,206,714,985,82,641,270,5,777,899,820,995,397,43,973,191,885,156,9,568,256,659,673,85,26,631,293,151,143,423},
                    expectedOutput: new int[] { 40,46 }),
                (money: 890, flavors: new int[] { 286,461,830,216,539,44,989,749,340,51,505,178,50,305,341,292,415,40,239,950,404,965,29,972,536,922,700,501,730,430,630,293,557,542,598,795,28,344,128,461,368,683,903,744,430,648,290,135,437,336,152,698,570,3,827,901,796,682,391,693,161,145},
                    expectedOutput: new int[] { 16,35 }),
                (money: 163, flavors: new int[] { 22,391,140,874,75,339,439,638,158,519,570,484,607,538,459,758,608,784,26,792,389,418,682,206,232,432,537,492,232,219,3,517,460,271,946,418,741,31,874,840,700,58,686,952,293,848,55,82,623,850,619,380,359,479,48,863,813,797,463,683,22,285,522,60,472,948,234,971,517,494,218,857,261,115,238,290,158,326,795,978,364,116,730,581,174,405,575,315,101,99},
                    expectedOutput: new int[] { 55,74  }),
                (money: 295, flavors: new int[] { 678,227,764,37,956,982,118,212,177,597,519,968,866,121,771,343,561 },
                    expectedOutput: new int[] { 7,9 }),
            })
            {
                CollectionAssert.AreEqual(spec.expectedOutput, icecreamParlor(spec.money, spec.flavors));
            }
        }
        #endregion
    }
}
