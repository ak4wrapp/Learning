using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    [TestFixture]
    public class Problems
    {

        #region 78. Subsets
        // Return all possible Subsets from given Array of Numbers
        // https://leetcode.com/problems/subsets/description/
        /*  
         *  Given an integer array nums of unique elements, return all possible subsets (the power set).

            The solution set must not contain duplicate subsets. Return the solution in any order.

            Example 1:

            Input: nums = [1,2,3]
            Output: [[],[1],[2],[1,2],[3],[1,3],[2,3],[1,2,3]]

            Example 2:

            Input: nums = [0]
            Output: [[],[0]]
 
            Constraints:

            1 <= nums.length <= 10
            -10 <= nums[i] <= 10
            All the numbers of nums are unique.
         */

        public IList<IList<int>> Subsets(int[] nums)
        {
            List<IList<int>> res = new List<IList<int>>
            {
                // Always return an empty Array as first element
                new List<int>()
            };

            if (nums == null || nums.Length == 0) return res;

            for (int i = 0; i < nums.Length; i++)
            {
                int count = res.Count;

                for (int j = 0; j < count; j++)
                {
                    List<int> subList = new List<int>(res[j]);
                    subList.Add(nums[i]);
                    res.Add(subList);
                }

                #region explanation

                // Pick all elements from result array and append current element to create a new list
                /*
                 *  res[] = [[]];
                 *  iterating through all elements on nums input, 3 in case [1,2,3]
                 *  
                 *  ==iteration 1==
                 *  
                 *  res is = [[]]
                 *  i=0; nums[i] is 1; j loop will run(res.Count = 1) times 
                 *  
                 *  j=0
                 *      subList = new List<int>(res[j]) is new SubList with value {[]}, 
                 *      subList.Add(nums[i]) 
                 *      subList ignores empty array and becomes [1]
                 *      added [1] to res list
                 *      res is now [[][1]]
                 *  
                 *  ==iteration 2==
                 *  
                 *  res is = [[][1]]
                 *  i=1; nums[i] is 2; j loop will run(res.Count = 2) times
                 *  
                 *  j=0
                 *      subList = new List<int>(res[j]) is new SubList with value {[]}, 
                 *      subList.Add(nums[i] which is 2) 
                 *      subList ignores empty array and becomes [2]
                 *      added [2] to res list 
                 *      res is now [[][2]]
                 *  j=1
                 *      subList = new List<int>(res[j]) is new SubList with value {[1]}, 
                 *      subList.Add(nums[i] which is 2) 
                 *      subList becomes [1,2]
                 *      added [1,2] to res list 
                 *      res is now [[][1][2][1,2]]
                 *      
                 *  ==iteration 3==
                 *  
                 *  res is = [[][1][2][1,2]]
                 *  i=2; nums[i] is 3; j loop will run(res.Count = 4) times
                 *  
                 *  j=0 on res [[][1][2][1,2]]
                 *      subList = new List<int>(res[j]) is new SubList with value {[]}, 
                 *      subList.Add(nums[i] which is 3) 
                 *      subList ignores empty array and becomes [3]
                 *      added [3] to res list 
                 *      res is now [[][1][2][1,2][3]]
                 *  j=1 on res [[][1][2][1,2][3]]
                 *      subList = new List<int>(res[j]) is new SubList with value {[1]}, 
                 *      subList.Add(nums[i] which is 3) 
                 *      subList becomes [1,3]
                 *      added [1,3] to res list 
                 *      res is now [[][1][2][1,2][3][1,3]]
                 *  
                 *  j=2 on res [[][1][2][1,2][3][1,3]]
                 *      subList = new List<int>(res[j]) is new SubList with value {[2]}, 
                 *      subList.Add(nums[i] which is 3) 
                 *      subList becomes [2,3]
                 *      added [2,3] to res list 
                 *      res is now [[][1][2][1,2][3][1,3][2,3]]
                 *      
                 *  j=3 on res [[][1][2][1,2][3][1,3][2,3]]
                 *      subList = new List<int>(res[j]) is new SubList with value {[1,2]}, 
                 *      subList.Add(nums[i] which is 3) 
                 *      subList becomes [1,2,3]
                 *      added [1,2] to res list 
                 *      res is now [[][1][2][1,2][3][1,3][2,3],[1,2,3]]
                 */

                #endregion

            }
            return res;
        }

        [Test]
        public void Subsets()
        {
            foreach (var spec in new[] {
                (   Input: new int[] { 0 },
                    OutPut: new List<IList<int>> {
                                                    new List<int>(),
                                                    new List<int>() { 0 }
                                                 }
                ),
                (   Input: new int[] { 1, 2, 3 },
                    OutPut: new List<IList<int>> {
                                                    new List<int>(),
                                                    new List<int>() { 1 },
                                                    new List<int>() { 2 },
                                                    new List<int>() { 1, 2 },
                                                    new List<int>() { 3 },
                                                    new List<int>() { 1, 3 },
                                                    new List<int>() { 2, 3 },
                                                    new List<int>() { 1, 2, 3 }
                                                 }
                )
            })
            {
                Assert.AreEqual(spec.OutPut, Subsets(spec.Input));
            }
        }
        #endregion

        #region 953. Verifying an Alien Dictionary
        /*  
         *  https://leetcode.com/problems/verifying-an-alien-dictionary/
         *  
         *  In an alien language, surprisingly they also use english lowercase letters, but possibly in a different order. The order of the alphabet is some permutation of lowercase letters.

            Given a sequence of words written in the alien language, and the order of the alphabet, return true if and only if the given words are sorted lexicographicaly in this alien language.

            Example 1:

            Input: words = ["hello","leetcode"], order = "hlabcdefgijkmnopqrstuvwxyz"
            Output: true
            Explanation: As 'h' comes before 'l' in this language, then the sequence is sorted.

            Example 2:

            Input: words = ["word","world","row"], order = "worldabcefghijkmnpqstuvxyz"
            Output: false
            Explanation: As 'd' comes after 'l' in this language, then words[0] > words[1], hence the sequence is unsorted.

            Example 3:

            Input: words = ["apple","app"], order = "abcdefghijklmnopqrstuvwxyz"
            Output: false
            Explanation: The first three characters "app" match, and the second string is shorter (in size.) According to lexicographical rules "apple" > "app", because 'l' > '∅', where '∅' is defined as the blank character which is less than any other character (More info).
 

            Constraints:

            1 <= words.length <= 100
            1 <= words[i].length <= 20
            order.length == 26
            All characters in words[i] and order are English lowercase letters.
         */


        public bool IsAlienSorted(string[] words, string order)
        {
            int[] charIndex = new int[26];

            for (int i = 0; i < order.Length; i++)
            {
                charIndex[order[i] - 'a'] = i;
            }

            for (int i = 0; i < words.Length; i++)
            {
                for (int j = 1; j < words.Length; j++)
                {
                    int wordLengthToCompare = Math.Min(words[i].Length, words[j].Length);

                    for (int k = 0; k < wordLengthToCompare; k++)
                    {
                        char iChar = words[i][k];
                        char jChar = words[j][k];
                        if (charIndex[iChar - 'a'] < charIndex[jChar - 'a']) break;
                        else if (charIndex[iChar - 'a'] > charIndex[jChar - 'a']) return false;
                        else if (k == wordLengthToCompare - 1 && words[i].Length > words[j].Length)
                            return false;

                    }
                }

            }
            return true;
        }

        [TestCase(new string[] { "hello", "leetcode" }, "hlabcdefgijkmnopqrstuvwxyz", true)]
        [TestCase(new string[] { "word", "world", "row" }, "worldabcefghijkmnpqstuvxyz", false)]
        [TestCase(new string[] { "apple", "app" }, "abcdefghijklmnopqrstuvwxyz", false)]
        public void IsAlienSorted(string[] Words, string Order, bool ExpectedOutput)
        {
            Assert.AreEqual(ExpectedOutput, IsAlienSorted(Words, Order));
        }
        #endregion

        #region 36. Valid Sudoku
        /*  
         *  https://leetcode.com/problems/valid-sudoku/
         *  
         *  Determine if a 9 x 9 Sudoku board is valid. Only the filled cells need to be validated according to the following rules:

            Each row must contain the digits 1-9 without repetition.
            Each column must contain the digits 1-9 without repetition.
            Each of the nine 3 x 3 sub-boxes of the grid must contain the digits 1-9 without repetition.
            Note:

            A Sudoku board (partially filled) could be valid but is not necessarily solvable.
            Only the filled cells need to be validated according to the mentioned rules.
         */


        public bool IsValidSudoku(char[][] board)
        {

            #region Attempt 1
            //for (int i = 0; i < board.Length; i++)
            //{
            //    for (int j = 0; j < board[i].Length; j++)
            //    {
            //        // When we have 3rd, 6th and 9th column
            //        // we want to check block
            //        if ((i + 1) % 3 == 0 && (j + 1) % 3 == 0 && !isBlockClean(board, i, j)) return false;
            //    }
            //}

            #endregion

            #region Attempt2
            // We already had a block to check, but instead of creating a block of 3X3, we will create a block of diff size

            // Check each Row and Column
            for (int i = 0; i < 9; i++)
            {
                // Check if block Row i * Column 0 to 8 Clean
                if (!isBlockClean(board, i, i, 0, 8)) return false;

                // Check if block Column i * Row 0 to 8 Clean
                if (!isBlockClean(board, 0, 8, i, i)) return false;
            }

            // Check Blocks
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    // Check if block Row i * Column 0 to 8 Clean
                    if (!isBlockClean(board, i * 3, i * 3 + 2, j * 3, j * 3 + 2)) return false;
                }
            }
            #endregion

            return true;
        }

        private bool isBlockClean(char[][] board, int rowStartIndex, int rowEndIndex, int colStartIndex, int colEndIndex)
        {
            HashSet<char> numbers = new HashSet<char>();

            for (int i = rowStartIndex; i <= rowEndIndex; i++)
            {
                for (int j = colStartIndex; j <= colEndIndex; j++)
                {
                    if (board[i][j] == '.') continue;
                    if (!numbers.Add(board[i][j])) return false;
                }
            }
            return true;
        }

        private bool isBlockClean(char[][] board, int rowIndex, int colIndex)
        {
            HashSet<int> numbers = new HashSet<int>();

            for (int i = rowIndex - 2; i <= rowIndex; i++)
            {
                if (!isRowClean(board, i)) return false;
                for (int j = colIndex - 2; j <= colIndex; j++)
                {
                    if (!isColumnClean(board, j)) return false;

                    if (board[i][j] == '.') continue;

                    if (numbers.Contains(board[i][j] - '0'))
                    {
                        return false;
                    }
                    numbers.Add(board[i][j] - '0');
                }
            }
            return true;
        }

        private bool isColumnClean(char[][] board, int colIndex)
        {
            HashSet<int> numbers = new HashSet<int>();
            for (int i = 0; i < board.Length; i++)
            {
                if (board[i][colIndex] == '.') continue;
                if (numbers.Contains(board[i][colIndex] - '0')) return false;
                numbers.Add(board[i][colIndex] - '0');
            }
            return true;
        }

        private bool isRowClean(char[][] board, int rowIndex)
        {
            HashSet<int> numbers = new HashSet<int>();
            for (int i = 0; i < board[0].Length; i++)
            {
                if (board[rowIndex][i] == '.') continue;
                if (numbers.Contains(board[rowIndex][i] - '0')) return false;
                numbers.Add(board[rowIndex][i] - '0');
            }
            return true;
        }


        [Test]
        public void IsValidSudokuTest()
        {
            char[][] board = new char[9][]
            {
                new char[] { '5', '3', '.', '.', '7', '.', '.', '.', '.' },
                new char[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
                new char[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
                new char[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
                new char[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
                new char[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
                new char[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
                new char[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
                new char[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
            };

            bool result = IsValidSudoku(board);

            Assert.AreEqual(true, result);
        }
        #endregion

        #region 70. Climbing Stairs
        // https://leetcode.com/problems/climbing-stairs/

        #region Problem Statement
        /*
            You are climbing a staircase. It takes n steps to reach the top.

            Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?

            Example 1:

            Input: n = 2
            Output: 2
            Explanation: There are two ways to climb to the top.
            1. 1 step + 1 step
            2. 2 steps

            Example 2:

            Input: n = 3
            Output: 3
            Explanation: There are three ways to climb to the top.
            1. 1 step + 1 step + 1 step
            2. 1 step + 2 steps
            3. 2 steps + 1 step
 

            Constraints:

            1 <= n <= 45
        */
        #endregion

        public int ClimbStairs(int n)
        {
            if (n <= 2) return n;

            int[] stepsCount = new int[n];
            stepsCount[0] = 1;
            stepsCount[1] = 2;

            for (int i = 2; i < n; i++)
            {
                stepsCount[i] = stepsCount[i - 1] + stepsCount[i - 2];
            }

            return stepsCount[n - 1];
        }

        [TestCase(2, 2)]
        [TestCase(3, 3)]
        [TestCase(4, 5)]
        public void ClimbStairsTest(int Steps, int ExpectedOutput)
        {
            Assert.AreEqual(ExpectedOutput, ClimbStairs(Steps));
        }
        #endregion

        #region 200. Number of Islands
        // https://leetcode.com/problems/number-of-islands/

        #region Problem Statement
        /*
         *  Given an m x n 2d grid map of '1's (land) and '0's (water), return the number of islands.

            An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. You may assume all four edges of the grid are all surrounded by water.

            Example 1:

            Input: grid = [
              ["1","1","1","1","0"],
              ["1","1","0","1","0"],
              ["1","1","0","0","0"],
              ["0","0","0","0","0"]
            ]
            Output: 1

            Example 2:

            Input: grid = [
              ["1","1","0","0","0"],
              ["1","1","0","0","0"],
              ["0","0","1","0","0"],
              ["0","0","0","1","1"]
            ]
            Output: 3
         */
        #endregion


        public int NumIslands(char[][] grid)
        {
            if (grid?.Length == 0) return 0;

            int numIslands = 0;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == '1')
                    {

                        numIslands += 1;
                        MarkAllConnectedLandAsVisited(grid, i, j);
                    }
                }
            }

            return numIslands;
        }

        private void MarkAllConnectedLandAsVisited(char[][] grid, int rowIndex, int colIndex)
        {
            if (rowIndex < 0 || rowIndex >= grid.Length ||
                colIndex < 0 || colIndex >= grid[rowIndex].Length ||
                grid[rowIndex][colIndex] == '0')
            {
                return;
            }

            grid[rowIndex][colIndex] = '0';

            MarkAllConnectedLandAsVisited(grid, rowIndex + 1, colIndex);
            MarkAllConnectedLandAsVisited(grid, rowIndex - 1, colIndex);
            MarkAllConnectedLandAsVisited(grid, rowIndex, colIndex + 1);
            MarkAllConnectedLandAsVisited(grid, rowIndex, colIndex - 1);
        }

        [Test]
        public void NumIslands()
        {
            foreach (var spec in new[] {(
                                            inputGrid:  new char[3][] {
                                                            new char[] {'1','0','1','1','1'},
                                                            new char[] {'1','0','1','0','1'},
                                                            new char[] {'1','1','1','0','1'}
                                                            },
                                            expectedOutPut: 1
                                        ),
                                        (
                                            inputGrid: new char[4][] {
                                                            new char[] { '1', '1', '1', '1', '0' },
                                                            new char[] { '1', '1', '0', '1', '0' },
                                                            new char[] { '1', '1', '0', '0', '0' },
                                                            new char[] { '0', '0', '0', '0', '0' }
                                                       },
                                             expectedOutPut: 1
                                        ),
                                        (
                                            inputGrid: new char[4][] {
                                                            new char[] {'1','1','0','0','0'},
                                                            new char[] {'1','1','0','0','0'},
                                                            new char[] {'0','0','1','0','0'},
                                                            new char[] {'0','0','0','1','1'}
                                                       },
                                            expectedOutPut: 3
                                        ),
                                        (
                                            inputGrid: new char[3][] {
                                                            new char[] {'1','1','1'},
                                                            new char[] {'0','1','0'},
                                                            new char[] {'1','1','1'}
                                                       },
                                            expectedOutPut: 1
                                        ),
                                        (
                                            inputGrid: new char[3][] {
                                                            new char[] {'0','1','0'},
                                                            new char[] {'1','0','1'},
                                                            new char[] {'0','1','0'}
                                                       },
                                            expectedOutPut: 4
                                        )
                })
            {
                Assert.AreEqual(spec.expectedOutPut, NumIslands(spec.inputGrid));
            }
        }
        #endregion

        #region 322. Coin Change
        // https://leetcode.com/problems/coin-change/

        #region Problem Statement
        /*
         *  You are given coins of different denominations and a total amount of money amount. 
         *  Write a function to compute the fewest number of coins that you need to make up that amount.
         *  If that amount of money cannot be made up by any combination of the coins, return -1.

            You may assume that you have an infinite number of each kind of coin.

            Example 1:

            Input: coins = [1,2,5], amount = 11
            Output: 3
            Explanation: 11 = 5 + 5 + 1

            Example 2:

            Input: coins = [2], amount = 3
            Output: -1

            Example 3:

            Input: coins = [1], amount = 0
            Output: 0

            Example 4:

            Input: coins = [1], amount = 1
            Output: 1

            Example 5:

            Input: coins = [1], amount = 2
            Output: 2
 
            Constraints:

            1 <= coins.length <= 12
            1 <= coins[i] <= 231 - 1
            0 <= amount <= 104
         */
        #endregion


        public int CoinChange(int[] coins, int amount)
        {
            if (amount == 0) return 0;
            if (coins?.Length == 1 && coins[0] > amount) return -1;

            // create an array to hold the minimum number of coins to make each amount
            // Length is: amount + 1 so that you will have indices from 0 to amount in the array
            // Value for each item is put amount +1, so we will know if it was ever replaced or not
            int[] dp = Enumerable.Repeat(amount+1, amount+1).ToArray();

            // there are 0 ways to make amount 0 with positive coin values
            dp[0] = 0;

            // look at one coin at a time
            for (int coinIndex = 0; coinIndex < coins.Length; coinIndex++)
            {
                for (int amt = 0; amt <= amount; amt++)
                {
                    // make sure the difference between the current amount and the current coin is at least 0
                    // replace the minimum value
                    if ((amt - coins[coinIndex]) >= 0)
                    {
                        dp[amt] = Math.Min(dp[amt], dp[amt - coins[coinIndex]] + 1);
                    }
                }
            }

            // if the value remains more then the amount (as we initialize), it means that no coin combination can make that amount
            return dp[amount] > amount ? -1 : dp[amount];
        }

        [Test]
        public void CoinChangeTest()
        {
            foreach (var spec in new[] {
                        (coins:  new int[] { 1,2,5 },amount: 11, expectedOutPut: 3),
                        (coins:  new int[] { 2 }, amount: 3, expectedOutPut: -1),
                        (coins:  new int[] { 1 }, amount: 0, expectedOutPut: 0),
                        (coins:  new int[] { 1 }, amount: 1, expectedOutPut: 1),
                        (coins:  new int[] { 1 }, amount: 2, expectedOutPut: 2)
                })
            {
                Assert.AreEqual(spec.expectedOutPut, CoinChange(spec.coins, spec.amount), $"Coins: {string.Join(",", spec.coins) }, Amount: {spec.amount}");
            }
        }
        
        #endregion
    }
}
