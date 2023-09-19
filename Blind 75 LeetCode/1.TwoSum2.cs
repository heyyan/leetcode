using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.Blind_75_LeetCode
{
    public class TwoSum2
    {
        // given an array of integers that is already sorted in ascending order. find two numbers such that they add up to a specific target number
        // function twoSum should return indices of the two numer such that they add up to the target, where index1 must be less than index2
        // your returned answer (both index1 and index2 are not zero bases
        // you may assume that each input would be have exactly one solution and you may not use the  same element twice.
        // input numbers= [2,7,11,15] target = 9
        //output [1,2]

        public void RunSolution()
        {
          //  var result = GetTwoSum2(new int[] { 2, 7, 11, 15 }, 9);
            var result = GetTwoSum2(new int[] { 1, 3, 4, 5, 7, 11 }, 9);
        }

        private int[] GetTwoSum2(int[] numbers, int target)
        {
            int l = 0;
            int r = numbers.Length - 1;
            while (l < r)
            {
                int curSum = numbers[l] + numbers[r];
                if (curSum > target)
                {
                    r--;
                }
                else if (curSum < target)
                {
                    l++;
                }
                else
                {
                    return new int[] { l + 1, r + 1 };
                }
            }
            return Array.Empty<int>();
        }
    }
}
