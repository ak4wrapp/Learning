
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Playground
{
    [TestClass]
    public class MathUtilsTests
    {
        private double Average(int a, int b)
        {
            return (a + b) / 2;
        }

        [TestMethod]
        public void Average_Test()
        {
            Console.WriteLine(Average(2, 1));
            Console.WriteLine(Average(2, 0));
            Console.WriteLine(Average(-1, -1));
        }
    }
}
