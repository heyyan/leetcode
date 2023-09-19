using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.Blind_75_LeetCode
{
    public class MissingNumber
    {
        // Given an array nums containg n distinct number in range [0,n], return the only number
        // in the range that is missing from the array
        // Could you implement a solution using only O(1) extra space complexity and O(n) runtime complexity
        //input [3,0,1]
        //outpur 2
        //input [0,1]
        //outpur 2

        public void RunSolution()
        {
            var result = MisNum(new int[] {3, 0, 1 });
        }

        private int GETMissingNumber(int[] nums)
        {
            int res = nums.Length;
            for (int i = 0; i < nums.Length; i++)
            {
                res += (i - nums[i]);
            }
            return res;
        }

        private int MisNum(int[] nums)
        {
            int xor = 0;
            for (int i = 0; i< nums.Length;i++)
            {
                xor = xor ^ nums[i];
            }
            for (int i = 0; i <= nums.Length; i++)
            {
                xor = xor ^ i;
            }
            return xor; 
        }
    }
}
