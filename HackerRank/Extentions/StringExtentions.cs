using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank.Extentions
{
    public static class StringExtentions
    {
        public static int CountAs(this string inputStr)
        {
            return inputStr.Count(x => x.ToString().Equals("a", StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Returns a 2D Array from Input string by provided line and letter seperator
        /// 
        /// e.g. A Given String with N as line seperator and ' ' as letter seperator
        /// 
        /// 1 1 1 0 0 0 N 0 1 0 0 0 0 N 1 1 1 0 0 0 N 0 0 2 4 4 0 N 0 0 0 2 0 0 N 0 0 1 2 4 0
        /// 
        /// would return a 2D Array like this (Press F12 to view in code directly)
        /// 
        /// 1 1 1 0 0 0
        /// 0 1 0 0 0 0
        /// 1 1 1 0 0 0
        /// 0 0 2 4 4 0
        /// 0 0 0 2 0 0
        /// 0 0 1 2 4 0
        /// </summary>
        /// <param name="inputStr"></param>
        /// <param name="lineSeperator"></param>
        /// <param name="letterSeperator"></param>
        /// <returns>a 2D Array</returns>
        public static int[][] Get2DArray(this string inputStr, char lineSeperator, char letterSeperator)
        {
           

            int[][] arr = new int[6][];
            for (int i = 0; i < 6; i++)
            {
                arr[i] = Array.ConvertAll(
                    inputStr.Split(lineSeperator, StringSplitOptions.RemoveEmptyEntries)[i]
                            .Split(letterSeperator, StringSplitOptions.RemoveEmptyEntries),
                    arrTemp => Convert.ToInt32(arrTemp));
            }

            return arr;
        }
    }
}
