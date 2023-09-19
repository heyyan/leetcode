using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.Blind_75_LeetCode
{
    public class LongestIncreasingSubsequence
    {
        // A subsequence is an sequence that can be derived from an array by deleting some or no elements without changing the order of
        // remainging  elements. for example 93,5,2,7] is a subsequence of the array [0,3,1,6,2,2,7]
        //input nums = [10,92,5,3,7,101,18]
        // outpurt = 4
        // explanation The longes increasing subsequence is [2,3,7,101], therefor the length is 4
        public void RunSolution()
        {
            var result = Change2(5, new int[] { 1, 2, 5 });
        }

        private object Change2(int v, int[] ints)
        {
            throw new NotImplementedException();
        }
    }
}
