using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRankTests
{
    [TestClass]
    public class JumpingOnTheClouds
    {
        [TestMethod]
        public void Test_JumpingOnTheClouds()
        {
            foreach (var spec in new[]{
                ( clouds : new [] {0, 0, 0, 1, 0, 0}, expectedOutPut : 3 ),
                ( clouds : new [] {0, 0, 0, 0, 1, 0 }, expectedOutPut : 3 ),
                ( clouds : new [] {0, 0, 1, 0, 0, 1, 0}, expectedOutPut : 4 )
            })
            {
                int output = HackerRank.JumpingOnTheClouds.JumpingOnClouds(spec.clouds);

                Assert.AreEqual(spec.expectedOutPut, output);
            }
        }
    }
}
