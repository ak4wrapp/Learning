using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.Warm_up_Challenges
{
    public class CountingValleys
    {
        private static int countingValleys(int totalNumber, int[] Socks)
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
