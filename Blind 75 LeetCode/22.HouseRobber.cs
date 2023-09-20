using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.Blind_75_LeetCode
{
    public class HouseRobber
    {
        // you are a professional robber planning to rob houses along a street. Each house has a certain amount
        // of money stashed, the only constraint stopping you from robbing each of them is that adjacent houses
        // have security system connected and it will automatically contact the police if two adjacent house
        // were brokne into on the same night
        // Given a list of non-negitavie integers rpresenting the amount of money of each house, determain the 
        // miximum amount of money you can rob tonight without alerting the polise
        // input nums=[1,2,3,1]
        // output 4
        public void RunSolution()
        {
            var result = GetHouseRobber(new int[] { 1, 2, 3, 1 });
        }

        private object GetHouseRobber(int[] nums)
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
