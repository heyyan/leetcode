using System;

namespace leetcode.Blind_75_LeetCode
{
    public class CoinChange
    {
        // you are given coins of differenct denominations and a total amount of money amount. write a function to compute
        // the fewest number of coin that you need to make up that amount. if that amount of money cannot be made up by
        // any combination of the coins, return -1
        // you may assume that you have an infinate of each kind of coin
        // input  coin=[1,2,5] amount= 11
        // output 3
        // explanation 11 = 5 + 5 +1

        // input coint[2]. amount = 3
        //output -1
        public void RunSolution()
        {
            var result = GetCoinChange2(new int[] { 1, 2, 5 }, 11);
        }

        private int GetCoinChange(int[] coins, int amount)
        {
            int[] dp = new int[amount + 1] ;
            for (int i = 1; i <= amount; i++)
            {
                dp[i] = amount + 1;
            }
            dp[0] = 0;

            for (int a = 1; a < amount; a++)
            {
                for (int c = 1; c < coins.Length - 1; c++)
                {
                    if (a - coins[c] >= 0)
                    {
                        dp[a] = Math.Min(dp[a], (1 + dp[a - coins[c]]));
                    }
                }
            }
            if (dp[amount] == amount + 1 && dp[1] != 1)
                return -1;
            return dp[amount];
        }

        public int GetCoinChange2(int[] coins, int amount)
        {

            int n = coins.Length;
            int[] dp = new int[amount + 1];
            dp[0] = 0;
            for (int i = 1; i <= amount; i++)
            {
                dp[i] = amount + 1;
            }
            for (int i = 1; i <= amount; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i >= coins[j])
                    {
                        dp[i] = Math.Min(dp[i - coins[j]] + 1, dp[i]);
                    }

                }
            }
            if (dp[amount] == amount + 1 && dp[1] != 1)
                return -1;
            return dp[amount];
        }
    }
}
