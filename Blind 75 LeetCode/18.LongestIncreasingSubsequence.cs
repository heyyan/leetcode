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
            var result = GetLongestIncreasingSubsequence(new int[] { 10, 9, 2, 5, 3, 7, 101, 18 });
        }

        private int GetLongestIncreasingSubsequence(int[] nums)
        {
            int[] lis = new int[nums.Length];
            Array.Fill(lis, 1);

            for (int i = nums.Length - 1; i >= 0; i--)
            {
                for (int j = i + 1; j < nums.Length - 1; j++)
                {
                    if (nums[i] < nums[j])
                    {
                        lis[i] = Math.Max(lis[i], 1 + lis[j]);
                    }
                }
            }
            return lis.Max();
        }

        public int LengthOfLIS(int[] nums)
        {
            var answers = new int[nums.Length];
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                answers[i] = 1;
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] < nums[j] && answers[i] < 1 + answers[j])
                    {
                        answers[i] = 1 + answers[j];
                    }
                }
            }
            return answers.Max();
        }

        public int LengthOfLIS2(int[] nums)
        {
            int[] LIS = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                LIS[i] = 1;
            }

            for (int i = nums.Length - 1; i >= 0; i--)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] < nums[j])
                    {
                        LIS[i] = Math.Max(LIS[i], 1 + LIS[j]);
                    }
                }
            }

            int maxLength = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                maxLength = Math.Max(maxLength, LIS[i]);
            }

            return maxLength;
        }
    }
}
