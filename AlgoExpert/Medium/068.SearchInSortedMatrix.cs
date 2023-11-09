using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Medium
{
    public class SearchInSortedMatrix
    {
        public void RunSolution()
        {
            var matrix = new int[,]
            {
                {1,    4,   7,  12,  15, 1000 },
                {2,    3,  19,  31,  32, 1001 },
                {3,    8,  24,  33,  35, 1002 },
                {40,  41,  42,  44,  45, 1003 },
                {99, 100, 103, 106, 128, 1004 }
            };
            var values = searchInSortedMatrix(matrix, 44);
        }

        private int[] searchInSortedMatrix(int[,] matrix, int findValue)
        {
            int row = 0;
            int col = matrix.GetLength(1) - 1;
            while (row < matrix.GetLength(1) && col >= 0 )
            {
                if (matrix[row, col] > findValue)
                {
                    col--;
                }
                else if (matrix[row, col] < findValue)
                {
                    row++;
                }
                else
                {
                    return new int[2] { row, col };
                }
            }

            return new int[] { -1, -1 };
        }

        private int[] GetSearchInSortedMatrix(int[,] matrix, int findValue)
        {
            for (var i = matrix.GetLength(0) - 1; i >= 0; i--)
            {
                if (matrix[i, 0] == findValue)
                {
                    return new int[2] { i, 0 };
                }
                if (matrix[i, matrix.GetLength(1) - 1] == findValue)
                {
                    return new int[2] { i, matrix.GetLength(1) - 1 };
                }
                else if (matrix[i, 0] < findValue && matrix[i, matrix.GetLength(1) - 1] > findValue)
                {
                    for (var j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] == findValue)
                        {
                            return new int[2] { i, j };
                        }
                    }
                }

            }

            return new int[] { -1, -1 };
        }

        private int[] GetSearchInSortedMatrixDFS(int[,] matrix, int findValue)
        {
            return DfsStack(matrix, 0, matrix.GetLength(1) - 1, findValue);
        }

        private int[] Dfs(int[,] matrix, int x, int y, int findValue)
        {
            if (x < 0)
            {
                return new int[] { -1, -1 };
            }
            if (y > matrix.GetLength(1))
            {
                return new int[] { -1, -1 };
            }
            if (matrix[x, y] == findValue)
            {
                return new int[2] { x, y };
            }

            if (matrix[x, y] > findValue)
            {
                return Dfs(matrix, x, y - 1, findValue);
            }
            else
            {
                return Dfs(matrix, x + 1, y, findValue);
            }
        }

        private int[] DfsStack(int[,] matrix, int x, int y, int findValue)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(matrix[x, y]);

            while (stack.Count > 0)
            {
                var item = stack.Pop();
                if (item == findValue)
                {
                    return new int[2] { x, y };
                }
                if (item > findValue)
                {
                    y--;
                    stack.Push(matrix[x, y]);
                }
                else
                {
                    x++;
                    stack.Push(matrix[x, y]);
                }
            }

            return new int[] { -1, -1 };
        }
    }
}
