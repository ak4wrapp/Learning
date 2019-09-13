using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank
{
    public class Arrays
    {
        #region HourglassSum
        public static int HourglassSum(int[][] arr)
        {
            if (arr == null || arr.Length != 6) throw new ArgumentException();

            int maxHrGlass = 0;
            int currentHrGlassSum = 0;
            for (int i = 1; i <= 4; i++) {
                for (int j = 1; j <= 4; j++) {

                    currentHrGlassSum = arr[i - 1][j - 1] + arr[i - 1][j] + arr[i - 1][j + 1] + arr[i][j] + arr[i + 1][j - 1] + arr[i + 1][j] + arr[i + 1][j + 1];

                    if ((i==1 && j==1) || currentHrGlassSum > maxHrGlass) maxHrGlass = currentHrGlassSum;
                }
            }

            return maxHrGlass;
        }
        #endregion
    }
}
