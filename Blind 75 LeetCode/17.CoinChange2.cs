using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.Blind_75_LeetCode
{
    public class CoinChange2
    {
        // you are given  an  integer array coins repesending coins of  differenct denominations and an integer amount
        // repesednting a total amount of money.
        // retrun the number of combinaions that make up that amount. if that amount of
        // money cannot be made up by any combination of coins, return 0
        // you may assume that you have an infinate of each kind of coin
        // the answer is guarnteddto fin inot signed 32bit integer
        // input  coin=[1,2,5] amount= 5
        // output 4
        // explanation there are four way to make up the amount
        // 5=5  5=2+2+1 5=2+1+1+1  5=1+1+1+1+1

        // input coint[2]. amount = 3
        //output -1
        public void RunSolution()
        {
            var result = Change2(5, new int[] { 1, 2, 5 });
        }

        private int GetCoinChange2(int[] ints, int v)
        {
            throw new NotImplementedException();
        }

        public int Change(int amount, int[] coins)
        {
            Dictionary<(int, int), int> cache = new Dictionary<(int, int), int>();

            int Dfs(int i, int a)
            {
                if (a == amount)
                {
                    return 1;
                }
                if (a > amount)
                {
                    return 0;
                }
                if (i == coins.Length)
                {
                    return 0;
                }
                if (cache.ContainsKey((i, a)))
                {
                    return cache[(i, a)];
                }
                cache[(i, a)] = Dfs(i, a + coins[i]) + Dfs(i + 1, a);
                return cache[(i, a)];
            }

            return Dfs(0, 0);
        }

        public int Change2(int amount, int[] coins)
        {
            int n = coins.Length;
            int[,] dp = new int[n, amount + 1];

            for (int i = 0; i < n; i++)
            {
                dp[i, 0] = 1;
            }

            for (int j = 1; j <= amount; j++)
            {
                if (j >= coins[0])
                {
                    dp[0, j] = dp[0, j - coins[0]];
                }
            }

            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j <= amount; j++)
                {
                    if (j >= coins[i])
                    {
                        dp[i, j] = dp[i - 1, j] + dp[i, j - coins[i]];
                    }
                    else
                    {
                        dp[i, j] = dp[i - 1, j];
                    }
                }
            }

            return dp[n - 1, amount];
        }
    }
}
