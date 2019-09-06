using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRankTests
{
    [TestClass]
    public class RepeatedStringTests
    {
        private class Spec
        {
            public string InputStr { get; set; }
            public long NumOfChars { get; set; }
            public long ExpectedOutPut { get; set; }
        }
        [TestMethod]
        public void Test_RepeatedStringCount()
        {
            foreach (var spec in new Spec[]{
                new Spec() { InputStr = "ababa", NumOfChars = 3, ExpectedOutPut = 2},
                new Spec() { InputStr = "epsxyyflvrrrxzvnoenvpegvuonodjoxfwdmcvwctmekpsnamchznsoxaklzjgrqruyzavshfbmuhdwwmpbkwcuomqhiyvuztwvq", NumOfChars=549382313570, ExpectedOutPut=16481469408},
                new Spec() { InputStr = "ceebbcb", NumOfChars = 817723, ExpectedOutPut = 0},
                new Spec() { InputStr = "aab", NumOfChars = 882787, ExpectedOutPut = 588525},
                new Spec() { InputStr = "aba", NumOfChars = 10, ExpectedOutPut = 7},
                new Spec() { InputStr = "a", NumOfChars = 1000000000000, ExpectedOutPut = 1000000000000}
            })
            {
                long output = HackerRank.RepeatedString.CountRepeatedString(spec.InputStr, spec.NumOfChars);

                Assert.AreEqual(spec.ExpectedOutPut, spec.ExpectedOutPut);
            }
        }
    }
}
