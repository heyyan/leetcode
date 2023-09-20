using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace leetcode.Blind_75_LeetCode
{
    public class JumpGame
    {
        // Given an array of non-negative integers nums, you are initally positioned at the first index of the array
        // Each element in the array repesent your maximum jumping length at that position
        // Determine if you are able to reach the last index
        // input nums= [2,3,1,1,4]
        // output true
        // explanation Jump1 steop from index 0 to 1, then 3 steps to last index
        // input nums= [3,2,1,0,4]
        // output false
        public void RunSolution()
        {
            var result = GetJumpGame(new int[] { 3, 2, 1, 0, 4 });
        }

        private bool GetJumpGame(int[] nums)
        {
            int goal = nums.Length - 1;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (i + nums[i] >= goal)
                {
                    goal = i;
                }
            }

            return goal == 0;
        }


        public bool canJump(int[] nums)
        {
            int reachable = 0;
            for (int i = 0; i < nums.Length && i <= reachable; i++)
            {
                reachable = Math.Max(reachable, i + nums[i]);
                if (reachable >= nums.Length - 1)
                    return true;
            }
            return false;
        }
    }
}
