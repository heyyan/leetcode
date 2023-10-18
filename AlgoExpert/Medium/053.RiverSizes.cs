using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Medium
{
    public class RiverSizes
    {
        //input [1 0 0 1 0
        //       1 0 1 0 0
        //       0 0 1 0 1
        //       1 0 1 0 1
        //       1 0 1 0 0
        //output [1,2,2,2,5]
        public void RunSolution()
        {
            int[,] matrix = new int[,] {{ 1, 0, 0, 4, 0},
                                        { 1, 0, 3, 0, 0},
                                        { 0, 0, 3, 0, 5},
                                        { 2, 0, 3, 0, 5},
                                        { 2, 0, 3, 3, 0}
            };


            var rest = riverSizes(matrix);
        }

        private int[] GetRiverSizes(int[,] matrix)
        {
            int[,] visited = new int[,] {{ 0, 0, 0, 0, 0},
                                         { 0, 0, 0, 0, 0},
                                         { 0, 0, 0, 0, 0},
                                         { 0, 0, 0, 0, 0},
                                         { 0, 0, 0, 0, 0}
            };
            List<int> result = new List<int>();
            Dictionary<string, int> map = new();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] != 0)
                    {
                        DFS(matrix, i, j, map, visited);
                        if (map.Count > 0)
                        {
                            result.Add(map.Count);
                        }
                        map = new();
                    }
                }
            }
            return result.ToArray();
        }

        private void DFS(int[,] matrix, int i, int j, Dictionary<string, int> result, int[,] visited)
        {
            if (i < 0 || j < 0 || i >= matrix.GetLength(0) || j >= matrix.GetLength(1))
            {
                return;
            }
            if (visited[i, j] == -1)
            {
                return;
            }
            if (matrix[i, j] == 0)
            {
                visited[i, j] = -1;
                return;
            }

            result.Add(i + "," + j, 1);
            visited[i, j] = -1;

            DFS(matrix, i + 1, j, result, visited);
            DFS(matrix, i - 1, j, result, visited);
            DFS(matrix, i, j + 1, result, visited);
            DFS(matrix, i, j - 1, result, visited);


        }


        private int[] riverSizes(int[,] matrix)
        {
            List<int> sizes = new List<int>();
            var visited = new bool[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (visited[i, j])
                    {
                        continue;
                    }
                    traverseNode(i, j, matrix, visited, sizes);
                }
            }
            return sizes.ToArray();
        }

        private void traverseNode(int i, int j, int[,] matrix, bool[,] visited, List<int> sizes)
        {
            var currentRiverSize = 0;
            Stack<Tuple<int, int>> nodesToExplore = new Stack<Tuple<int, int>>();
            nodesToExplore.Push(new Tuple<int, int>(i, j));
            while (nodesToExplore.Count > 0)
            {
                var currentNode = nodesToExplore.Pop();
                i = currentNode.Item1;
                j = currentNode.Item2;
                if (visited[i, j])
                {
                    continue;
                }
                visited[i, j] = true;
                if (matrix[i, j] == 0)
                {
                    continue;
                }
                currentRiverSize++;
                var unvisitedNeighbors = GetUnvisitedNeighbors(i, j, matrix, visited);
                foreach (var neighbor in unvisitedNeighbors)
                {
                    nodesToExplore.Push(new Tuple<int, int>(neighbor.Item1, neighbor.Item2));
                }
            }
            if (currentRiverSize > 0)
            {
                sizes.Add(currentRiverSize);
            }
        }

        private List<(int, int)> GetUnvisitedNeighbors(int i, int j, int[,] matrix, bool[,] visited)
        {
            List<(int, int)> unvisitedNeighbors = new();

            if (i > 0 && !visited[i - 1, j])
            {
                unvisitedNeighbors.Add((i - 1, j));
            }
            if (i < matrix.GetLength(0) - 1 && !visited[i + 1, j])
            {
                unvisitedNeighbors.Add((i + 1, j));
            }

            if (j > 0 && !visited[i, j - 1])
            {
                unvisitedNeighbors.Add((i, j - 1));
            }
            if (j < matrix.GetLength(0) - 1 && !visited[i, j + 1])
            {
                unvisitedNeighbors.Add((i, j + 1));
            }
            return unvisitedNeighbors;
        }
    }
}
