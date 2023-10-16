using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Medium
{
    public class MinNumberOfCoinForChange
    {
        // input $6 = [ 1,2,4] 
        // output 2 >> 2 + 4 =6
        public void RunSolution()
        {
            var rest = minNumberOfCoinForChange(6, new int[] { 1, 2, 4 });
        }

        private int minNumberOfCoinForChange(int n, int[] coins)
        {
            int[] ways = new int[n + 1];
            Array.Fill(ways, int.MaxValue);
            ways[0] = 0;
            foreach (int coin in coins)
            {
                for (int i = 1; i < ways.Length; i++)
                {
                    if (coin <= i)
                    {
                        ways[i] = Math.Min(ways[i], 1 + ways[i - coin]);
                    }
                }
            }
            if (ways[n + 1] != int.MaxValue)
            {
                return ways[ways.Length - 1];
            }
            return -1;
        }
    }
}
