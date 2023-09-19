using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.Blind_75_LeetCode
{
    public class CountingBits
    {
        // Given an integer n, return an array and of length n+1 such that for each i(0<=i<=n) is the number of 1's in the
        // binary representaion of i
        //input n
        //outpur [0,1,1]
        public void RunSolution()
        {
            var result = GETCountingBits(2);
        }

        private int[] GETCountingBits(int n)
        {
            int[] dp = new int[n + 1];
            int offset = 1;
            for (int i = 1; i < n + 1; i++)
            {
                if (offset * 2 == i)
                {
                    offset = i;
                }
                dp[i] = 1 + dp[i - offset];
            }
            return dp;
        }
    }
}
