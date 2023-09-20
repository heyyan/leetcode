using System;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace leetcode.Blind_75_LeetCode
{
    // you are a professional robber planning to rob houses along a street. Each house has a certain amount
    // of money stashed, All houses are arranged in circle. Than means the first house is the neighbor of the last one.
    // Meanwhile,adjacent houses
    // have security system connected and it will automatically contact the police if two adjacent house
    // were brokne into on the same night
    // Given a list of non-negitavie integers rpresenting the amount of money of each house, determain the 
    // miximum amount of money you can rob tonight without alerting the polise
    // input nums=[2,3,2]
    // output 3
    public class HouseRobberII
    {
        public void RunSolution()
        {
            var result = GetHouseRobberII(new int[] { 1, 2, 3, 1 });
        }

        private int GetHouseRobberII(int[] nums)
        {
           return Math.Max(nums[0], Math.Max(helper(nums.Skip(1).ToArray()), helper(nums.Take(nums.Length - 1).ToArray())));
        }

        private int helper(int[] nums)
        {
            int rob1 = 0, rob2 = 0;
            foreach (int n in nums)
            {
                int temp = Math.Max(n + rob1, rob2);
                rob1 = rob2;
                rob2 = temp;
            }
            return rob2;
        }
    }
}
