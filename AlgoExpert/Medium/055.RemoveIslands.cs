using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Medium
{
    public class RemoveIslands
    {
        public void RunSolution()
        {
            int[,] matrix = new int[,] {{ 1, 0, 0, 0, 0, 0},
                                        { 0, 1, 0, 1, 1, 1},
                                        { 0, 0, 1, 0, 1, 0},
                                        { 1, 1, 0, 0, 1, 0},
                                        { 1, 0, 1, 1, 0, 0},
                                        { 1, 0, 0, 0, 0, 1}
            };


            var rest = GetRemoveIslands4(matrix);
        }

        private object GetRemoveIslands(int[,] matrix)
        {
            bool[,] visted = new bool[matrix.GetLength(0), matrix.GetLength(1)];
            List<List<string>> result = new();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (!visted[i, j])
                    {
                        var map = new List<string>();
                        DFS(i, j, matrix, visted, map);
                        if (map.Count > 0)
                        {
                            result.Add(map);
                        }
                    }
                }
            }

            var island = GetIslands(result, "0", (matrix.GetLength(0) - 1).ToString());
            RemoveIsland(matrix, island);
            return matrix;
        }

        private void DFS(int i, int j, int[,] matrix, bool[,] visted, List<string> map)
        {
            Stack<(int, int)> stack = new Stack<(int, int)>();
            stack.Push((i, j));
            while (stack.Count > 0)
            {
                var item = stack.Pop();
                i = item.Item1;
                j = item.Item2;
                if (i < 0 || i > matrix.GetLength(0) - 1)
                {
                    continue;
                }
                if (j < 0 || j > matrix.GetLength(1) - 1)
                {
                    continue;
                }
                if (visted[i, j])
                {
                    continue;
                }
                visted[i, j] = true;
                if (matrix[i, j] == 0)
                {
                    continue;
                }

                map.Add(i + "," + j);
                stack.Push((i - 1, j));
                stack.Push((i, j - 1));
                stack.Push((i + 1, j));
                stack.Push((i, j + 1));
            }
        }

        private List<List<string>> GetIslands(List<List<string>> maps, string start, string end)
        {
            var result = new List<List<string>>();
            foreach (var map in maps)
            {
                bool addMap = true;
                for (var i = 0; i < map.Count; i++)
                {
                    var items = map[i].Split(',');
                    if (items[0] == start || items[0] == end)
                    {
                        addMap = false;
                        break;
                    }
                    if (items[1] == start || items[1] == end)
                    {
                        addMap = false;
                        break;
                    }
                }
                if (addMap)
                {
                    result.Add(map);
                }
            }
            return result;
        }

        private void RemoveIsland(int[,] matrix, List<List<string>> maps)
        {
            foreach (var map in maps)
            {
                for (var i = 0; i < map.Count; i++)
                {
                    var items = map[i].Split(',');
                    int x = int.Parse(items[0]);
                    int y = int.Parse(items[1]);
                    matrix[x, y] = 0;

                }
            }
        }


        private object GetRemoveIslands2(int[,] matrix)
        {
            bool[,] visted = new bool[matrix.GetLength(0), matrix.GetLength(1)];
            List<List<string>> result = new();

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (!visted[0, i])
                {
                    var map = new List<string>();
                    DFS(0, i, matrix, visted, map);
                }
            }

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (!visted[matrix.GetLength(0) - 1, i])
                {
                    var map = new List<string>();
                    DFS(matrix.GetLength(0) - 1, i, matrix, visted, map);
                }
            }


            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (!visted[i, 0])
                {
                    var map = new List<string>();
                    DFS(i, 0, matrix, visted, map);
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (!visted[i, matrix.GetLength(1) - 1])
                {
                    var map = new List<string>();
                    DFS(i, matrix.GetLength(1) - 1, matrix, visted, map);
                }
            }


            for (int i = 1; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < matrix.GetLength(1) - 1; j++)
                {
                    if (!visted[i, j] && matrix[i, j] == 1)
                    {
                        matrix[i, j] = 0;
                    }
                }
            }

            return matrix;
        }

        private object GetRemoveIslands3(int[,] matrix)
        {
            bool[,] onesConnectedToBorder = new bool[matrix.GetLength(0), matrix.GetLength(1)];
            List<List<string>> result = new();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    bool rowIsBorder = row == 0 || row == matrix.GetLength(0) - 1;
                    bool colIsBorder = col == 0 || col == matrix.GetLength(1) - 1;
                    bool isBorder = rowIsBorder || colIsBorder;

                    if (!isBorder)
                    {
                        continue;
                    }
                    if (matrix[row, col] != 1)
                    { continue; }

                    FindOnesConnectedToBorder(matrix, row, col, onesConnectedToBorder);

                }
            }

            for (int i = 1; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < matrix.GetLength(1) - 1; j++)
                {
                    if (onesConnectedToBorder[i, j])
                    {
                        continue;
                    }
                    matrix[i, j] = 0;
                }
            }

            return matrix;
        }

        private void FindOnesConnectedToBorder(int[,] matrix, int startRow, int startCol, bool[,] onesConnectedToBorder)
        {
            Stack<(int, int)> stack = new Stack<(int, int)>();
            stack.Push((startRow, startCol));

            while (stack.Count > 0)
            {
                var currentPostion = stack.Pop();
                int currentRow = currentPostion.Item1;
                int currentCol = currentPostion.Item2;

                if (onesConnectedToBorder[currentRow, currentCol])
                {
                    continue;
                }
                onesConnectedToBorder[currentRow, currentCol] = true;

                var neighbors = GetNeighbors(matrix, currentRow, currentCol);
                foreach (var neighbor in neighbors)
                {
                    int row = neighbor.Item1;
                    int col = neighbor.Item2;

                    if (matrix[row, col] != 1)
                    {
                        continue;
                    }
                    stack.Push(neighbor);
                }
            }
        }

        private List<(int, int)> GetNeighbors(int[,] matrix, int row, int col)
        {
            List<(int, int)> neighbors = new List<(int, int)>();
            int numRows = matrix.GetLength(0);
            int numCols = matrix.GetLength(1);

            if (row - 1 >= 0)
            {
                neighbors.Add((row - 1, col));
            }
            if (row + 1 < numRows)
            {
                neighbors.Add((row + 1, col));
            }
            if (col - 1 >= 0)
            {
                neighbors.Add((row, col - 1));
            }
            if (col + 1 < numCols)
            {
                neighbors.Add((row, col + 1));
            }

            return neighbors;
        }


        private object GetRemoveIslands4(int[,] matrix)
        {
            bool[,] onesConnectedToBorder = new bool[matrix.GetLength(0), matrix.GetLength(1)];
            List<List<string>> result = new();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    bool rowIsBorder = row == 0 || row == matrix.GetLength(0) - 1;
                    bool colIsBorder = col == 0 || col == matrix.GetLength(1) - 1;
                    bool isBorder = rowIsBorder || colIsBorder;

                    if (!isBorder)
                    {
                        continue;
                    }
                    if (matrix[row, col] != 1)
                    { continue; }

                    ChangeOnesConnectedToBordatToTwos(matrix, row, col);

                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 1)
                    {
                        matrix[i, j] = 0;
                    }
                    else if (matrix[i, j] == 2)
                    {
                        matrix[i, j] = 1;
                    }
                }
            }

            return matrix;
        }

        private void ChangeOnesConnectedToBordatToTwos(int[,] matrix, int startRow, int startCol)
        {
            Stack<(int, int)> stack = new Stack<(int, int)>();
            stack.Push((startRow, startCol));

            while (stack.Count > 0)
            {
                var currentPostion = stack.Pop();
                int currentRow = currentPostion.Item1;
                int currentCol = currentPostion.Item2;
                matrix[currentRow, currentCol] = 2;

                var neighbors = GetNeighbors(matrix, currentRow, currentCol);
                foreach (var neighbor in neighbors)
                {
                    int row = neighbor.Item1;
                    int col = neighbor.Item2;

                    if (matrix[row, col] != 1)
                    {
                        continue;
                    }
                    stack.Push(neighbor);
                }
            }
        }
    }
}
