using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank
{
    public class SockMerchant
    {
        // Complete the sockMerchant function below.
        public static int sockMerchant(int totalNumber, int[] Socks)
        {
            var pairs = 0;
            var hash = new HashSet<int>();
            foreach (int sock in Socks)
            {
                if (!hash.Add(sock))
                {
                    pairs++;
                    hash.Remove(sock);
                }
            }
            return pairs;
        }
    }
}
