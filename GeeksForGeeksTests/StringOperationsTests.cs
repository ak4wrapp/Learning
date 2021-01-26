using GeeksForGeeks;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class TestsStringOperationsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestReverseAStringInSortedArrayFollowedBySumOfDigits()
        {
            Assert.AreEqual("ABCEW5", StringOperations.ReverseAStringInSortedArrayFollowedBySumOfDigits("AbC2BEW3"));
            Assert.AreEqual("A0", StringOperations.ReverseAStringInSortedArrayFollowedBySumOfDigits("A"));
        }
    }
}