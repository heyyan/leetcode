using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.Blind_75_LeetCode
{
    public class MaximumSubarray
    {
        // Given an  array nums, find the contiguous subarray (containing at least one number) which has the largest
        // sun and return its sum
        // input [-2,1,-3,4,-1,2,1,-5,4]
        // output 6
        public void RunSolution()
        {
            var result = GetMaximumSubarray2(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 });
        }

        private int GetMaximumSubarray(int[] nums)
        {
            int maxSub = nums[0];
            int curSum = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (curSum < 0)
                {
                    curSum = 0;
                }
                curSum += nums[i];
                maxSub = Math.Max(maxSub, curSum);
            }
            return maxSub;
        }

        private int GetMaximumSubarray2(int[] nums)
        {
            int curr = nums[0];
            int max = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                curr = Math.Max(nums[i], nums[i] + curr);
                max = Math.Max(max, curr);
            }
            return max;
        }
    }
}
