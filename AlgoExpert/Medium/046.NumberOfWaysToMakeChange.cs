using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Medium
{
    public class NumberOfWaysToMakeChange
    {
        // array of positve ints we want to get greatest sum of numbers 
        // that are not next to each other
        // input =[ 1,5,10,25] $10
        // output =33
        public void RunSolution()
        {
            var rest = numberOfways(new int[] { 1, 5, 10, 25 }, 10);
        }

        private int[] numberOfWaysToMakeChange(int[] array, int target)
        {
            int[] ways = new int[target + 1];
            ways[0] = 1;
            for (int i = 0; i < array.Length; i++)
            {
                int coin = array[i];

                for (int j = 1; j < ways.Length; j++)
                {
                    if (coin <= j)
                    {
                        ways[j] = ways[j] + ways[j - coin];
                    }
                }
            }
            return ways;
        }

        private int numberOfways(int[] coins, int target)
        {
            int[] ways = new int[target + 1];
            ways[0] = 1;
            foreach (var denom in coins)
            {
                for (int amount = 1; amount < ways.Length; amount++)
                {
                    if (denom <= amount)
                    {
                        ways[amount] += ways[amount - denom];
                    }
                }
            }
            return ways[ways.Length - 1];
        }
    }
}
