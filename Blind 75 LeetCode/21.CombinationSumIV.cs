using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.Blind_75_LeetCode
{
    public class CombinationSumIV
    {
        // Given an array of distinct integers nums and a targer integer targer, return the number of possible
        // combinations that added up to target
        // the answer is guranteed to fit in a 32 bit integer
        // input nums=[1,2,3] target = 4
        // output = 7
        // explanation
        // possible combinations way are
        // (1,1,1,1)
        // (1,1,2)
        // (1,2,1)
        // (1,3)
        // (2,1,1)
        // (2,2)
        // (3,1)
        // note that different sequences are conunted as different combinations

        public void RunSolution()
        {
            var result = GetCombinationSumIV(new int[] { 1, 2, 3 }, 4);
        }

        private int GetCombinationSumIV(int[] nums, int target)
        {
            Dictionary<int, int> dp = new Dictionary<int, int>();
            dp.Add(0, 1);

            for (int total = 1; total <= target; total++)
            {
                dp.Add(total, 0);
                foreach (int n in nums)
                {
                    int m = total - n;
                    if(dp.ContainsKey(m))
                    {
                        dp[total] += dp[m];
                    }
                }
            }

            return dp[target];
        }
    }
}
