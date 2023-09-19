using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.Blind_75_LeetCode
{
    public class MaximumProductSubarray
    {
        // Given an integer array nums, find the contiguous subarray within an array (containging at least one number) which has the larger product
        //input [2,3,-2,4]
        //output 3
        public void RunSolution()
        {
            var result = GETMaximumProductSubarray(new int[] { -1,-2,-3,0,3,5,-1,-2 });
        }
         
        private int GETMaximumProductSubarray(int[] nums)
        {
            int result = nums.Max();
            int curMin = 1;
            int curMax = 1;

            foreach (int n in nums)
            {
                if (n == 0)
                {
                    curMin = curMax = 1;
                    continue;
                }
                int temp = curMax * n;
                curMax = Math.Max(Math.Max(n * curMax, n * curMin), n);
                curMin = Math.Min(Math.Min(temp, n * curMin), n);
                result = Math.Max(result,curMax);
            }
            return result;
        }
    }
}
