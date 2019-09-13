using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRankTests
{
    [TestClass]
    public class WarmupChallengesTests
    {
        #region SockMerchant

        #endregion

        #region CountingValleys

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
                int output = HackerRank.WarmupChallenges.CountingValleys(spec.totalSteps, spec.steps);

                Assert.AreEqual(spec.expectedOutPut, output);
            }

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

        #endregion

        #region JumpingOnClouds

        [TestMethod]
        public void Test_JumpingOnTheClouds()
        {
            foreach (var spec in new[]{
                ( clouds : new [] {0, 0, 0, 1, 0, 0}, expectedOutPut : 3 ),
                ( clouds : new [] {0, 0, 0, 0, 1, 0 }, expectedOutPut : 3 ),
                ( clouds : new [] {0, 0, 1, 0, 0, 1, 0}, expectedOutPut : 4 )
            })
            {
                int output = HackerRank.WarmupChallenges.JumpingOnClouds(spec.clouds);

                Assert.AreEqual(spec.expectedOutPut, output);
            }
        }
        #endregion

        #region RepeatedString
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
                long output = HackerRank.WarmupChallenges.CountRepeatedString(spec.InputStr, spec.NumOfChars);

                Assert.AreEqual(spec.ExpectedOutPut, spec.ExpectedOutPut);
            }
        }
        #endregion
    }
}
