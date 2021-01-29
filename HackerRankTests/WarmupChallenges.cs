using System;
using System.Collections.Generic;
using System.Text;
using HackerRank.Extentions;

namespace HackerRank
{
    public class WarmupChallenges
    {
        #region SockMerchant

        public static int SockMerchant(int totalNumber, int[] Socks)
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

        #endregion

        #region CountingValleys

        public static int CountingValleys(int totalSteps, string inputStr)
        {
            if (string.IsNullOrEmpty(inputStr)) throw new ArgumentNullException();
            if (inputStr.Length < totalSteps) throw new ArgumentException("Input string cannot be less than total Steps");

            // Total Valleys Transversed
            int totalValleys = 0;

            // Current Level
            int currentLevel = 0;

            foreach (char step in inputStr)
            {
                currentLevel += GetLevelNumber(step);

                // If current Level is 0 and Gary is walking up, means he is just coming up from Valley
                if (currentLevel == 0 && IsSteppingUp(step))
                    totalValleys++;
            }

            return totalValleys;
        }

        private static int GetLevelNumber(char step)
        {
            if (IsSteppingUp(step))
                return 1;
            return -1;
        }
        private static bool IsSteppingUp(char step)
        {
            return String.Equals(step.ToString(), "U", StringComparison.OrdinalIgnoreCase);
        }

        #endregion

        #region JumpingOnClouds

        public static int JumpingOnClouds(int[] clouds)
        {
            if (clouds == null || clouds.Length == 0) throw new ArgumentNullException();

            int totalJumps = 0;

            // We will be checking current and current + 1
            for (int i = 0; i < clouds.Length - 1; i++)
            {
                // if i+2 is 0, we directly jump to third
                // Also check only if there are atleast i+2 elements left
                if (i < clouds.Length - 2 && clouds[i + 2] == 0)
                {
                    // Make additional Jump
                    i++;
                }
                totalJumps++;
            }
            return totalJumps;
        }
        #endregion

        #region RepeatedString

        public static long CountRepeatedString(string inputStr, long numOfChars)
        {
            // If given string does not have 'a', then return 0
            if (inputStr.CountAs() == 0) return 0;

            long totalAs;
            if (numOfChars < inputStr.ToCharArray().Length)
            {
                inputStr = inputStr.Substring(0, Convert.ToInt32(numOfChars));

                totalAs = inputStr.CountAs();

                return totalAs;
            }

            // When numOfChars > inputStr.ToCharArray().Length
            // total number of A's in initial string
            totalAs = inputStr.CountAs();

            // Find the dividend of number of 
            var dividend = numOfChars / inputStr.ToCharArray().Length;
            totalAs *= dividend;

            var remainingChars = numOfChars - (dividend * inputStr.Length);
            var remainingAs = inputStr.Substring(0, Convert.ToInt32(remainingChars)).CountAs();

            totalAs += remainingAs;

            return totalAs;
        }

        #endregion
    }
}
