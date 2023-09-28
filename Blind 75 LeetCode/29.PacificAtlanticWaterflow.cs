using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.Blind_75_LeetCode
{
    public class PacificAtlanticWaterflow
    {
        // There is an m x n rectangular island that borders both the Pacific Ocean and Atlantic Ocean.The Pacific Ocean
        // touches the island's left and top edges, and the Atlantic Ocean touches the island's right and bottom edges.
        // The island is partitioned into a grid of square cells.You are given an m x n integer matrix heights where heights[r][c]
        // represents the height above sea level of the cell at coordinate(r, c).
        // The island receives a lot of rain, and the rain water can flow to neighboring cells directly north, south, east, and
        // west if the neighboring cell's height is less than or equal to the current cell's height.Water can flow from any cell
        // adjacent to an ocean into the ocean.
        // Return a 2D list of grid coordinates result where result[i] = [ri, ci] denotes that rain water can flow from
        // cell (ri, ci) to both the Pacific and Atlantic oceans.
        // Input: heights = [[1,2,2,3,5],[3,2,3,4,4],[2,4,5,3,1],[6,7,1,4,5],[5,1,1,2,4]]
        // Output: [[0,4],[1,3],[1,4],[2,2],[3,0],[3,1],[4,0]]
        public void RunSolution()
        {
            var r = GetPacificAtlanticWaterflow(new List<List<int>>
            {
                new List<int>{1,2,2,3,5},
                new List<int>{3,2,3,4,4},
                new List<int>{2,3,5,3,1},
                new List<int>{6,7,1,4,5},
                new List<int>{5,1,1,2,4}
            });
        }

        private List<List<int>> GetPacificAtlanticWaterflow(List<List<int>> heights)
        {
            List<List<int>> res = new();
            int m = heights.Count;
            int n = heights[0].Count;
            bool[,] isPacific = new bool[m,n];
            bool[,] isAtlantic = new bool[m, n];

            for (int row = 0; row < m; row++)
            {
                DFSPacificAtlantic(row, 0, heights, isPacific, heights[row][0]);
                DFSPacificAtlantic(row, n - 1, heights, isAtlantic, heights[row][n - 1]);
            }

            for (int col = 0; col < n; col++)
            {
                DFSPacificAtlantic(0, col, heights, isPacific, heights[0][col]);
                DFSPacificAtlantic(m - 1, col, heights, isAtlantic, heights[m - 1][col]);
            }
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (isAtlantic[i, j] && isPacific[i, j])
                    {
                        res.Add(new List<int> { i, j });
                    }
                }
            }
            return res;

        }
        private void DFSPacificAtlantic(int row, int col, List<List<int>> heights, bool[,] visits, int prev)
        {
            int m = heights.Count, n = heights[0].Count;
            if (row < 0 || row >= m || col < 0 || col >= n || visits[row, col] || heights[row][col] < prev)
                return;
            visits[row, col] = true;
            DFSPacificAtlantic(row, col + 1, heights, visits, heights[row][col]);
            DFSPacificAtlantic(row, col - 1, heights, visits, heights[row][col]);
            DFSPacificAtlantic(row + 1, col, heights, visits, heights[row][col]);
            DFSPacificAtlantic(row - 1, col, heights, visits, heights[row][col]);
        }
    }
}
