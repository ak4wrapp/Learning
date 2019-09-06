using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank
{
    public class JumpingOnTheClouds
    {
        public static int JumpingOnClouds(int[] clouds)
        {
            if (clouds == null || clouds.Length == 0) throw new ArgumentNullException();

            int totalJumps = 0;

            // We will be checking current and current + 1
            for (int i = 0; i < clouds.Length - 1; i++) {
                // if i+2 is 0, we directly jump to third
                // Also check only if there are atleast i+2 elements left
                if (i < clouds.Length - 2 && clouds[i + 2] == 0)
                {
                    // Make additional Jump
                    i ++;
                }
                totalJumps++;
            }
            return totalJumps;
        }
    }
}
