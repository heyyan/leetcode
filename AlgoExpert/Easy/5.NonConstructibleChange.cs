using System;

namespace leetcode.AlgoExpert.Easy
{
    public class NonConstructibleChange
    {
        public void RunSolution()
        {
            var result = GetNonConstructibleChange(new int[] { 5, 7, 1, 1, 2, 3, 22 });
        }

        // O(logn) | O(1)
        private int GetNonConstructibleChange(int[] coins)
        {
            Array.Sort(coins);
            int currentChangeCreated = 0;
            foreach (int coin in coins)
            {
                if (coin > currentChangeCreated + 1)
                {
                    return currentChangeCreated + 1;
                }
                currentChangeCreated += coin;
            }
            return currentChangeCreated + 1;
        }
    }
}
