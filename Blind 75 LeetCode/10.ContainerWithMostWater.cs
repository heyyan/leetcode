using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.Blind_75_LeetCode
{
    public class ContainerWithMostWater
    {
        // Given n non-negitive integers a1,a2,a3,....an, where each represents a point at coordinated (i, ai), n vertical lines are drawn such
        // that the the two endpoints of the line i is at (i,ai) and (i,0). Find two lines which togather with the x-axis forms a containers,
        // such that the containers contains the most water.
        // input height[1,8,6,2,5,4,8,3,7]
        //output 49
        public void RunSolution()
        {
            var result = GetContainerWithMostWater(new int[] { 1,8,6,2,5,4,8,3,7 });
        }

        private object GetContainerWithMostWater(int[] nums)
        {
            int max = 0;
            int start = 0;
            int end = nums.Length - 1;
            while (start <= end)
            {
                int area = Math.Min(nums[start], nums[end]) * (end - start);
                max = Math.Max(max, area);
                if (nums[start] < nums[end])
                {
                    start++;
                }
                else
                {
                    end--;
                }
            }
            return max;
        }
    }
}
