using HackerRank.Extentions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRankTests
{
    [TestClass]
    public class ArraysTests
    {
        [TestMethod]
        public void Test_HourglassSum() {

         foreach (var spec in new[]{
                ( InputStr: "-1 -1 0 -9 -2 -2 N -2 -1 -6 -8 -2 -5 N -1 -1 -1 -2 -3 -4 N -1 -9 -2 -4 -4 -5 N -7 -3 -3 -2 -9 -9 N -1 -3 -1 -2 -4 -5", ExpectedOutPut: -6 ),
                ( InputStr: "1 1 1 0 0 0 N 0 1 0 0 0 0 N 1 1 1 0 0 0 N 0 0 2 4 4 0 N 0 0 0 2 0 0 N 0 0 1 2 4 0", ExpectedOutPut: 19),
                ( InputStr: "1 2 3 4 5 6 N 6 5 4 3 2 1 N 1 2 3 4 5 6 N 6 5 4 3 2 1 N 1 2 3 4 5 6 N 6 5 4 3 2 1", ExpectedOutPut: 32 )
            })
            {
                int maxHr = HackerRank.Arrays.HourglassSum(spec.InputStr.Get2DArray('N', ' '));

                Assert.AreEqual(maxHr, spec.ExpectedOutPut);
            }
        }

        [TestMethod]
        public void Test_RotateLeft()
        {

            foreach (var spec in new[]{
                ( InputArr: new int[] { 1, 2, 3}, placesToRotate: 1, ExpectedOutPut: new int[] { 2, 3, 1 } )
            })
            {
                int[] outPutArrat = HackerRank.Arrays.RotateLeft(spec.InputArr, spec.placesToRotate);

                Assert.AreEqual(outPutArrat, spec.ExpectedOutPut);
            }
        }
    }
}
