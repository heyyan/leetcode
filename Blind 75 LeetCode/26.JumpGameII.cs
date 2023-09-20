using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.Blind_75_LeetCode
{
    public class JumpGameII
    {
        // Given an array of non-negitive integers nums, you are initially positioned at the first index of the array
        // Each element in the array represent you maximum jump lenght at that position
        // you goal is to reach the last index in the minimum number of jumps
        // you can assume that you can always reach the last index
        // input nums= [2,3,1,1,4]
        //output 2
        public void RunSolution()
        {
            var result = GetJumpGameII(new int[] { 2, 3, 1, 1, 4 });
        }

        private int GetJumpGameII(int[] nums)
        {
            int res = 0;
            int l = 0, r = 0;
            while (r < nums.Length - 1)
            {
                int fartherest = 0;
                for (int i = l; i < r + 1; i++)
                {
                    fartherest = Math.Max(fartherest, i + nums[i]);
                }
                l = r + 1;
                r = fartherest;
                res++;
            }
            return res;
        }
    }
}
