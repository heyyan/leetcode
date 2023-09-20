using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.Blind_75_LeetCode
{
    public class UniquePaths
    {
        //A robot is locaated at the top-left corner of a MxN grid 
        // The robot can only move either down or right at any point in time. the robot is trying reach the bottom
        // right corner of the grid
        // how many unique paths are there
        // input m = 3, n = 7
        //outpur = 28

        public void RunSolution()
        {
            var result = UniquePaths2(3, 7);
        }

        private int GetUniquePaths(int m, int n)
        {
            int[,] dp = new int[m, n];
            for (int i = 0; i < n; i++)
            {
                dp[m - 1, i] = 1;
            }
            for (int i = 0; i < m; i++)
            {
                dp[i, n - 1] = 1;
            }
            for (int i = m - 2; i >= 0; i--)
            {
                for (int j = n - 2; j >= 0; j--)
                {
                    dp[i, j] = dp[i + 1, j] + dp[i, j + 1];
                }
            }

            return dp[0, 0];
        }

        public int UniquePaths2(int m, int n)
        {
            int[,] grid = new int[m, n];
            grid[0, 0] = 1;

            // Fill the first row with 1
            for (int i = 1; i < n; i++)
            {
                grid[0, i] = 1;
            }

            // Fill the first column with 1
            for (int i = 1; i < m; i++)
            {
                grid[i, 0] = 1;
            }

            // Calculate unique paths for each cell in the grid
            for (int row = 1; row < m; row++)
            {
                for (int col = 1; col < n; col++)
                {
                    int top = grid[row - 1, col];
                    int left = grid[row, col - 1];
                    grid[row, col] = top + left;
                }
            }

            return grid[m - 1, n - 1];
        }
    }
}
