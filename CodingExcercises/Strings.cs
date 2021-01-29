using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingExcercises
{
    [TestFixture]
    public class Strings
    {
        public static string Reverse(string inputStr)
        {
            char[] charArray = inputStr.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        [Test]
        public void Test_ReverseString()
        {
            Assert.AreEqual("NAMA", Reverse("AMAN"));
        }
    }
}
