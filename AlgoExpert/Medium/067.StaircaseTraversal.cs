using System;
using System.Collections.Generic;

namespace leetcode.AlgoExpert.Medium
{
    public class StaircaseTraversal
    {
        // input
        // height 4
        // maxSteps 2
        // output 5 exp [[1,1,1,1] ,[1,1,2],[1,2,1],[2,1,1],[2,1,1],[2,2]]
        public void RunSolution()
        {
            var values = GetStaircaseTraversalSliding(4, 2);
        }

        private List<List<int>> GetStaircaseTraversal(int height, int steps)
        {
            int d = numberOfWaysToTop(height, steps);
            return null;
        }

        private int numberOfWaysToTop(int height, int maxSteps)
        {
            if (height <= 1)
            {
                return 1;
            }

            var numberOfWays = 0;
            var steps = Math.Min(height, maxSteps);
            for (int step = 1; step < steps + 1; step++)
            {
                numberOfWays += numberOfWaysToTop(height - step, maxSteps);
            }

            return numberOfWays;
        }

        private List<List<int>> GetStaircaseTraversalMemo(int height, int steps)
        {
            Dictionary<int, int> memoize = new Dictionary<int, int>();
            memoize.Add(0, 1);
            memoize.Add(1, 1);
            int d = numberOfWaysToTopMemo(height, steps, memoize);
            return null;
        }

        private int numberOfWaysToTopMemo(int height, int maxSteps, Dictionary<int, int> memoize)
        {
            if (memoize.ContainsKey(height))
            {
                return memoize[height];
            }
            var numberOfWays = 0;
            var steps = Math.Min(height, maxSteps);
            for (int step = 1; step < steps + 1; step++)
            {
                numberOfWays += numberOfWaysToTopMemo(height - step, maxSteps, memoize);
            }
            memoize.Add(height, numberOfWays);
            return numberOfWays;
        }

        private int GetStaircaseTraversal2(int height, int maxStep)
        {
            int[] waysToTop = new int[height + 1];
            waysToTop[0] = 1;
            waysToTop[1] = 1;
            for (int currentHeight = 2; currentHeight <= height; currentHeight++)
            {
                int step = 1;
                while (step <= maxStep && step <= currentHeight)
                {
                    waysToTop[currentHeight] = waysToTop[currentHeight] + waysToTop[currentHeight - step];
                    step++;
                }
            }
            return waysToTop[height];
        }


        private int GetStaircaseTraversalSliding(int height, int maxStep)
        {
            int currentNumberOfWays = 0;
            List<int> waysToTop = new List<int>();
            waysToTop.Add(1);

            for (int currentHeight = 1; currentHeight <= height; currentHeight++)
            {
                int startOfWindow = currentHeight - maxStep - 1;
                int endOfWindow = currentHeight - 1;

                if (startOfWindow >= 0)
                {
                    currentNumberOfWays -= waysToTop[startOfWindow];
                }
                currentNumberOfWays += waysToTop[endOfWindow];
                waysToTop.Add(currentNumberOfWays);
            }
            return waysToTop[height];
        }
    }
}
