using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Medium
{
    public class NumberOfWaysToTraverseGraph
    {
        // input "abc","yabd"
        // output 2 
        public void RunSolution()
        {
            var rest = numberOfWaysToTraverseGraphFact(4, 3);
        }

        private int numberOfWaysToTraverseGraph(int width, int height)
        {
            var maze = new int[width, height];
            for (int i = 1; i < width; i++)
            {
                maze[i, 0] = 1;
            }
            for (int i = 1; i < height; i++)
            {
                maze[0, i] = 1;
            }

            for (int i = 1; i < width; i++)
            {
                for (int j = 1; j < height; j++)
                {
                    maze[i, j] = maze[i - 1, j] + maze[i, j - 1];
                }
            }

            return maze[width - 1, height - 1];
        }


        private int numberOfWaysToTraverseGraphRec(int width, int height)
        {
            var maze = new int[width, height];
            for (int i = 1; i < width; i++)
            {
                maze[i, 0] = 1;
            }
            for (int i = 1; i < height; i++)
            {
                maze[0, i] = 1;
            }
            Ways(maze, width - 1, height - 1);

            return maze[width - 1, height - 1];
        }

        private int Ways(int[,] maze, int r, int c)
        {
            if (r <= 0)
            {
                return maze[r, c];
            }
            if (c <= 0)
            {
                return maze[r, c];
            }
            var currentVal = Ways(maze, r - 1, c) + Ways(maze, r, c - 1);
            maze[r, c] = currentVal;
            return currentVal;
        }


        private int NumWays(int width, int height)
        {
            if (width == 1 || height == 1)
            {
                return 1;
            }
            return NumWays(width - 1, height) + NumWays(width, height - 1);
        }

        public static int numberOfWaysToTraverseGraph2(int width, int height)
        {
            int[,] numberOfWays = new int[height + 1, width + 1];

            for (int widthIdx = 1; widthIdx <= width; widthIdx++)
            {
                for (int heightIdx = 1; heightIdx <= height; heightIdx++)
                {
                    if (widthIdx == 1 || heightIdx == 1)
                    {
                        numberOfWays[heightIdx, widthIdx] = 1;
                    }
                    else
                    {
                        int waysLeft = numberOfWays[heightIdx, widthIdx - 1];
                        int waysUp = numberOfWays[heightIdx - 1, widthIdx];
                        numberOfWays[heightIdx, widthIdx] = waysLeft + waysUp;
                    }
                }
            }

            return numberOfWays[height, width];
        }

        public int numberOfWaysToTraverseGraphFact(int width, int height)
        {
            int xDistanceToCorner = width - 1;
            int yDistanceToCorner = height - 1;

            int numerator = factorial(xDistanceToCorner + yDistanceToCorner);
            int denominator = factorial(xDistanceToCorner) * factorial(yDistanceToCorner);
            return numerator / denominator;


        }

        private int factorial(int num)
        {
            int fact = 1;
            for (int i = 2; i < num + 1; i++)
            {
                fact = fact * i;
            }
            return fact;
        }
    }
}
