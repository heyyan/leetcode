using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Medium
{
    public class CycleInGraph
    {
        //input [[1,3],[2,3,4],[0],[],[2,5],[]]
        //output true
        public void RunSolution()
        {
            int[][] jaggedArray = {
                                        new int[] { 1,3 }, // 0
                                        new int[] { 2,3,4}, // 1
                                        new int[] { 0 }, // 2
                                        new int[] { }, // 3
                                        new int[] {2,5 }, // 4
                                        new int[] { },  //5
                                    };
            var rest = GetCycleInGraph2(jaggedArray);
        }

        private bool GetCycleInGraph(int[][] edges)
        {
            bool[] visited = new bool[edges.Length];
            int[] currentlyInStack = new int[edges.Length];

            for (int i = 0; i < edges.Length; i++)
            {
                if (visited[i])
                {
                    continue;
                }
                var containsCycle = isNodeInCycle(edges, edges[i], visited, currentlyInStack, i);
                if (containsCycle)
                {
                    return true;
                }
            }
            return false;
        }

        private bool isNodeInCycle(int[][] edges, int[] node, bool[] visited, int[] currentlyInStack, int i)
        {
            visited[i] = true;
            currentlyInStack[i] = 1;
            var neighbors = edges[i];

            for (int j = 0; j < neighbors.Length; j++)
            {
                if (!visited[neighbors[j]])
                {
                    var containCycle = isNodeInCycle(edges, edges[neighbors[j]], visited, currentlyInStack, neighbors[j]);
                    if (containCycle)
                    {
                        return true;
                    }
                    else if (currentlyInStack[neighbors[j]] == 1)
                    {
                        return true;
                    }
                }
                else if (currentlyInStack[neighbors[j]] == 1)
                {
                    return true;
                }
            }
            currentlyInStack[i] = 0;
            return false;
        }

        int WHITE = 0;
        int GRAY = 1;
        int BLACK = 2;
        private bool GetCycleInGraph2(int[][] edges)
        {
            int[] colors = new int[edges.Length];
            Array.Fill<int>(colors,WHITE);

            for (int i = 0; i < edges.Length; i++)
            {
                if (colors[i] != WHITE)
                {
                    continue;
                }
                var containsCycle = traverseAndColorNodes(edges, edges[i], colors, i);
                if (containsCycle)
                {
                    return true;
                }
            }
            return false;
        }

        private bool traverseAndColorNodes(int[][] edges, int[] nodes, int[] colors, int i)
        {
            colors[i] = GRAY;
            var neighbors = edges[i];

            for (int j = 0; j < neighbors.Length; j++)
            {
                var neighborColor = colors[neighbors[j]];

                if (neighborColor == GRAY)
                {
                    return true;
                }

                if (neighborColor != WHITE)
                {
                    continue;
                }

                var containCycle = traverseAndColorNodes(edges, edges[neighbors[j]], colors, neighbors[j]);
                if (containCycle)
                {
                    return true;
                }
                else if (colors[neighbors[j]] == GRAY)
                {
                    return true;
                }
            }
            colors[neighbors[i]] = BLACK;
            return false;
        }
    }


}
