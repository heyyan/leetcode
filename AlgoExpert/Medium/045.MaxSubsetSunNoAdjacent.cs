using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Medium
{
    public class MaxSubsetSunNoAdjacent
    {
        // array of positve ints we want to get greatest sum of numbers 
        // that are not next to each other
        // input =[ 7, 10, 12, 7, 9, 14]
        // output =33
        public void RunSolution()
        {
            var rest = maxSubsetSunNoAdjacent2(new int[] { 7, 10, 12, 7, 9, 14 });
        }

        private object maxSubsetSunNoAdjacent(int[] array)
        {
            int[] maxSums = new int[array.Length];

            maxSums[0] = array[0];
            maxSums[1] = Math.Max(array[0], array[1]);
            for (int i = 2; i < array.Length; i++)
            {
                maxSums[i] = Math.Max(maxSums[i - 1], maxSums[i - 2] + array[i]);
            }
            return maxSums[array.Length - 1];
        }

        private object maxSubsetSunNoAdjacent2(int[] array)
        {
            int result = 0;
            int first = array[0];
            int second = Math.Max(array[0], array[1]);
            for (int i = 2; i < array.Length; i++)
            {
                result = Math.Max(second, first + array[i]);
                first = second;
                second = result;
            }
            return result;
        }
    }
}
