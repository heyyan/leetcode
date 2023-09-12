using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.AlgoExpert.Easy
{
    public class TwoNumberSum
    {
        // Given an array of distinct integers and an integer representing the target sum,
        // we are asked to implement a function that is going to find out whether there's a pair of numbers in the array that adds up to the target sum.
        // If such pair exists, return the pair in any order; otherwise return an empty array. We cannot add a number to itself to get the target sum.

        public void RunSolution()
        {
            var result = GetTwoNumberSum3(new int[] { 1, 2, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 }, 10);
        }


        /// <summary>
        /// With two for loops, time O(n^2), space O(1)
        /// </summary>
        private int[] GetTwoNumberSum1(int[] arrayVal, int targetSum)
        {
            for (int i = 0; i < arrayVal.Length - 1; i++)
            {
                int firstNum = arrayVal[i];
                for (int j = i + 1; j < arrayVal.Length; j++)
                {
                    int secondNum = arrayVal[j];
                    if (firstNum + secondNum == targetSum)
                        return new int[] { firstNum, secondNum };
                }
            }
            return new int[] { };
        }

        // time O(n), space O(n)
        private int[] GetTwoNumberSum2(int[] arrayVal, int targetSum)
        {
            var numbs = new Dictionary<int, bool>();
            for (int i = 0; i < arrayVal.Length; i++)
            {
                int num = arrayVal[i];
                var potentialMatch = targetSum - num;
                if (numbs.ContainsKey(potentialMatch))
                {
                    return new int[] { potentialMatch, num };
                }
                else
                {
                    numbs.Add(num, true);
                }
            }
            return new int[] { };
        }


        private int[] GetTwoNumberSum3(int[] arrayVal, int targetSum)
        {
            Array.Sort(arrayVal);
            int left = 0;
            int right = arrayVal.Length - 1;
            while (left < right)
            {
                int sum = arrayVal[right] + arrayVal[left];
                if (sum == targetSum)
                {
                    return new int[] { arrayVal[left], arrayVal[right] };
                }
                else if (sum > targetSum)
                {
                    right--;
                }
                else
                {
                    left++;
                }

            }
            return Array.Empty<int>();
        }
    }
}
