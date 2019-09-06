using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank
{
    public class CountingValleys
    {
        // Complete the countingValleys function below.
        public static int countingValleys(int totalSteps, string inputStr)
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

        private static int GetLevelNumber(char step) {
            if (IsSteppingUp(step))
                return 1;
            return -1;
        }
        private static bool IsSteppingUp(char step) {
            return String.Equals(step.ToString(), "U", StringComparison.OrdinalIgnoreCase);
        }
    }
}
