using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.Blind_75_LeetCode
{
    public class TwoSum
    {
        // Given an array on integers nums and an integer Target, return indices of the two numbers such that they add up to the target
        // you can assume that each imput would have exactly one solution and you may not use the same element twice
        // input [2,7,11,15] target = 9
        // output [0,1]
        // input [3,2,4] target = 6
        // output [1,2]
        // input [3,3] target = 6
        // output [0,1]
        public void RunSolution()
        {
            var result = GetTwoSum(new int[] { 2,1,3,5,8 }, 9);
        }

        private int[] GetTwoSum(int[] arr, int targer)
        {
            List<int> vat = new List<int>();
            Dictionary<int, int> result = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                int diff = targer - arr[i];
                if (result.ContainsKey(diff))
                {
                    vat.Add(result[diff]);
                    vat.Add(i);
                }
                else
                {
                    result.Add(arr[i], i);
                }
            }
            return vat.ToArray();
        }
    }
}
