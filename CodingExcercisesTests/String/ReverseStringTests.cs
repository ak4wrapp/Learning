using System;
using System.Collections.Generic;
using System.Text;
using CodingExcercises.String;
using NUnit.Framework;

namespace CodingExcercisesTests.String
{

    [TestFixture]
    public class ReverseStringTests
    {
        [Test]
        public void Test_ReverseString()
        {
            Assert.AreEqual("NAMA", ReverseString.Reverse("AMAN"));
        }
    }
}
