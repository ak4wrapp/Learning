using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRankTests
{
    [TestClass()]
    public class CountingValleysTests
    {
        [TestMethod]
        public void Test_countingValleys()
        {
            foreach (var spec in new[]{
                ( totalSteps : 8, steps : "DDUUUUDD", expectedOutPut : 1 ),
                ( totalSteps : 8, steps : "UDDDUDUU",expectedOutPut : 1 ),
                ( totalSteps : 8, steps : "UUDDDDUU",expectedOutPut : 1 ),
                ( totalSteps : 14, steps : "DDDDUUUUDDUUDU", expectedOutPut : 3 )
            }) {
                int output = HackerRank.CountingValleys.countingValleys(spec.totalSteps, spec.steps);

                Assert.AreEqual(spec.expectedOutPut, output);
            }
            
        }
    }
}
