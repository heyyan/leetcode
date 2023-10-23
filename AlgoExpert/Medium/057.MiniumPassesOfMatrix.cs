using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Medium
{
    public class MiniumPassesOfMatrix
    {
        public void RunSolution()
        {
            var matrix = new int[,] { { 0,-1,-3,2,0},
                                      { 1,-2,-5,-1,-3},
                                      {3,0,0,-4,-1 } };
            var r = miniumPassesOfMatrix2(matrix);
        }

        private int GetMiniumPassesOfMatrix(int[,] matrix)
        {
            int count = 0;
            int update = 1;
            while (update > 0)
            {
                var fliped = new bool[matrix.GetLength(0), matrix.GetLength(1)];
                update = 0;
                count++;
                for (var i = 0; i < matrix.GetLength(0); i++)
                {
                    for (var j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] > 0 && !fliped[i, j])
                        {
                            update += UpdateElement(matrix, fliped, i, j);
                        }

                    }
                }
            }
            return count - 1;
        }

        private int UpdateElement(int[,] matrix, bool[,] fliped, int i, int j)
        {
            int updated = 0;
            if (i - 1 >= 0)
            {
                if (matrix[i - 1, j] < 0)
                {
                    matrix[i - 1, j] *= -1;
                    updated = 1;
                    fliped[i - 1, j] = true;
                }
            }
            if (j - 1 >= 0)
            {
                if (matrix[i, j - 1] < 0)
                {
                    matrix[i, j - 1] *= -1;
                    updated = 1;
                    fliped[i, j - 1] = true;
                }
            }

            if (i + 1 < matrix.GetLength(0))
            {
                if (matrix[i + 1, j] < 0)
                {
                    matrix[i + 1, j] *= -1;
                    updated = 1;
                    fliped[i + 1, j] = true;
                }
            }

            if (j + 1 < matrix.GetLength(1))
            {
                if (matrix[i, j + 1] < 0)
                {
                    matrix[i, j + 1] *= -1;
                    updated = 1;
                    fliped[i, j + 1] = true;
                }
            }
            return updated;
        }

        private int miniumPassesOfMatrix(int[,] matrix)
        {
            int passes = ConvertNegative(matrix);

            if (!ContainsNegitive(matrix)) return passes - 1;
            return -1;
        }

        private bool ContainsNegitive(int[,] matrix)
        {
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        return true;
                    }

                }
            }
            return false;
        }

        private int ConvertNegative(int[,] matrix)
        {
            Queue<(int, int)> nextPassQueue = GetAllPositivePositions(matrix);
            int passes = 0;
            while (nextPassQueue.Count > 0)
            {
                Queue<(int, int)> currentQueue = new Queue<(int, int)>(nextPassQueue);
                nextPassQueue.Clear();
                while (currentQueue.Count > 0)
                {
                    var item = currentQueue.Dequeue();
                    int currentRow = item.Item1;
                    int currentColumn = item.Item2;

                    var adjacentPositions = GetAdjacentPositions(currentRow, currentColumn, matrix);
                    foreach (var position in adjacentPositions)
                    {
                        int row = position.Item1;
                        int col = position.Item2;
                        if (matrix[row, col] < 0)
                        {
                            matrix[row, col] *= -1;
                            nextPassQueue.Enqueue((row, col));
                        }
                    }

                }
                passes++;
            }
            return passes;
        }

        private List<(int, int)> GetAdjacentPositions(int row, int col, int[,] matrix)
        {
            List<(int, int)> adjacentPostions = new();
            if (row > 0)
            {
                adjacentPostions.Add((row - 1, col));
            }
            if (row < matrix.GetLength(0) - 1)
            {
                adjacentPostions.Add((row + 1, col));
            }
            if (col > 0)
            {
                adjacentPostions.Add((row, col - 1));
            }

            if (col < matrix.GetLength(1) - 1)
            {
                adjacentPostions.Add((row, col + 1));
            }
            return adjacentPostions;
        }

        private Queue<(int, int)> GetAllPositivePositions(int[,] matrix)
        {
            Queue<(int, int)> positivePositions = new Queue<(int, int)>();
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        positivePositions.Enqueue((i, j));
                    }

                }
            }
            return positivePositions;
        }

        private int GetMiniumPassesOfMatrix2(int[,] matrix)
        {
            int counter = 0;
            Queue<(int, int)> queue = new Queue<(int, int)>();
            Queue<(int, int)> queue2 = new Queue<(int, int)>();

            var fliped = new bool[matrix.GetLength(0), matrix.GetLength(1)];
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        queue.Enqueue((i, j));
                    }

                }
            }

            var current = 0;
            while (queue.Count > 0 || queue2.Count > 0)
            {
                var item = queue.Dequeue();
                AddToQue(matrix, queue2, item.Item1 - 1, item.Item2);
                AddToQue(matrix, queue2, item.Item1 + 1, item.Item2);
                AddToQue(matrix, queue2, item.Item1, item.Item2 - 1);
                AddToQue(matrix, queue2, item.Item1, item.Item2 + 1);

                if (queue.Count == 0)
                {
                    queue = new Queue<(int, int)>(queue2);
                    queue2.Clear();
                }
                counter++;
            }

            return counter;
        }

        private void AddToQue(int[,] matrix, Queue<(int, int)> queue, int i, int j)
        {
            if (i >= 0 && i < matrix.GetLength(0) && j >= 0 && j < matrix.GetLength(1))
            {
                if (matrix[i, j] < 0)
                {
                    matrix[i, j] *= -1;
                    queue.Enqueue((i, j));
                }
            }
        }

        //private void DFS(int[,] matrix, bool[,] fliped, int i, int j)
        //{
        //    if (i > 0 || i > matrix.GetLength(0) - 1)
        //    {
        //        return;
        //    }
        //    if (j > 0 || j > matrix.GetLength(1) - 1)
        //    {
        //        return;
        //    }

        //}

        private int miniumPassesOfMatrix2(int[,] matrix)
        {
            int passes = ConvertNegative2(matrix);

            if (!ContainsNegitive2(matrix)) return passes - 1;
            return -1;
        }

        private bool ContainsNegitive2(int[,] matrix)
        {
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        return true;
                    }

                }
            }
            return false;
        }

        private int ConvertNegative2(int[,] matrix)
        {
            Queue<(int, int)> queue = GetAllPositivePositions2(matrix);
            int passes = 0;
            while (queue.Count > 0)
            {
                int currentSize = queue.Count;
                while (currentSize > 0)
                {
                    var item = queue.Dequeue();
                    int currentRow = item.Item1;
                    int currentColumn = item.Item2;

                    var adjacentPositions = GetAdjacentPositions2(currentRow, currentColumn, matrix);
                    foreach (var position in adjacentPositions)
                    {
                        int row = position.Item1;
                        int col = position.Item2;
                        if (matrix[row, col] < 0)
                        {
                            matrix[row, col] *= -1;
                            queue.Enqueue((row, col));
                        }
                        
                    }
                    currentSize--;
                }
                passes++;
            }
            return passes;
        }

        private List<(int, int)> GetAdjacentPositions2(int row, int col, int[,] matrix)
        {
            List<(int, int)> adjacentPostions = new();
            if (row > 0)
            {
                adjacentPostions.Add((row - 1, col));
            }
            if (row < matrix.GetLength(0) - 1)
            {
                adjacentPostions.Add((row + 1, col));
            }
            if (col > 0)
            {
                adjacentPostions.Add((row, col - 1));
            }

            if (col < matrix.GetLength(1) - 1)
            {
                adjacentPostions.Add((row, col + 1));
            }
            return adjacentPostions;
        }

        private Queue<(int, int)> GetAllPositivePositions2(int[,] matrix)
        {
            Queue<(int, int)> positivePositions = new Queue<(int, int)>();
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        positivePositions.Enqueue((i, j));
                    }

                }
            }
            return positivePositions;
        }
    }
}
