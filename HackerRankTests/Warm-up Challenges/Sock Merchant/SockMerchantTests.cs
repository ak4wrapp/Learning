using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.Warm_up_Challenges.Sock_Merchant
{

    [TestFixture]
    public class SockMerchantTests
    {
        [Test]
        public void Test_count_socks_pairs()
        {
            var inpurArr = new int[] { 1, 2, 3, 4, 1, 2, 3, 5, 6 };
            var socksPairs = SockMerchant.sockMerchant(inpurArr.Length, inpurArr);

            Assert.That(socksPairs == 3, "Test 1 Failed: Invalid Count");

            inpurArr = new int[] { 1, 2, 1, 2, 1, 2, 1, 1, 2 };
            socksPairs = SockMerchant.sockMerchant(inpurArr.Length, inpurArr);
            Assert.That(socksPairs == 4, "Test 2 Failed: Invalid Count");
        }
    }
}
