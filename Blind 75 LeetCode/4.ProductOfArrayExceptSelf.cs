using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.Blind_75_LeetCode
{
    public class ProductOfArrayExceptSelf
    {
        // Given an integer array nums, return an array answer such that answer[i] is equal to the product of all the 
        // elements of nums except num[i].
        // The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer
        // you must write an algorithm that runs in O(n) time and without using the division operation.
        //input [1,2,3,4]
        //output [24,12,8,6]

        //input [-1,1,0,-3,3]
        //output [0,0,9,0,0] 
        public void RunSolution()
        {
            var result = GetProductOfArrayExceptSelf(new int[] { -1, 1, 0, -3, 3 });
        }

        private int[] GetProductOfArrayExceptSelf(int[] nums)
        {
            int[] preFixProduct = new int[nums.Length];
            preFixProduct[0] = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                preFixProduct[i] = preFixProduct[i - 1] * nums[i - 1];
            }

            int suffixProduct = 1;
            for (int j = nums.Length - 1; j >= 0; j--)
            {
                preFixProduct[j] = preFixProduct[j] * suffixProduct;
                suffixProduct = suffixProduct * nums[j];
            }

            return preFixProduct;
        }
    }
}
