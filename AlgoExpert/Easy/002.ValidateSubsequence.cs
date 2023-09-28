using System.Collections.Generic;
using System.Linq;

namespace leetcode.AlgoExpert.Easy
{
    public class ValidateSubsequence
    {
        //We are given two arrays of integers array and sequence.
        //We are asked to implement a function that is going to check whether all the numbers in the sequence appear in the array
        //and they appear in the same order.
        //In other words, the function needs to find out if we can get the sequence array from the array, when we delete some or no
        //elements in the array without changing the order of the remaining elements.
        public void RunSolution()
        {
            var result = GetValidateSubsequence3(new int[] { 5, 1, 22, 25, 6, -1, 8, 10 }, new int[] { 1, 6, -1, 10 });
        }

        /// <summary>
        /// With two for loops, time O(n), space O(1)
        /// </summary>
        private bool GetValidateSubsequence(int[] sourceArray, int[] sequence)
        {
            int i = 0, j = 0;
            while (i < sequence.Length && j < sourceArray.Length)
            {
                var tVal = sequence[i];
                var sVal = sourceArray[j];
                if (tVal == sVal)
                {
                    i++;
                }
                j++;
            }

            return i == sequence.Length;
        }

        private bool GetValidateSubsequence2(int[] sourceArray, int[] sequence)
        {
            Dictionary<int, bool> result = new Dictionary<int, bool>();
            int b = 0;
            for (int i = 0; i < sequence.Length; i++)
            {
                result.Add(sequence[i], false);
                for (int j = b; j < sourceArray.Length; j++)
                {
                    b++;
                    if (sourceArray[j] == sequence[i])
                    {
                        result[sequence[i]] = true;
                        break;
                    }
                }
            }
            return result.Values.All(x => x);
        }

        private bool GetValidateSubsequence3(int[] sourceArray, int[] sequence)
        {
            int seqIdx = 0;
            foreach (var item in sourceArray)
            {
                if (seqIdx == sequence.Length)
                {
                    break;
                }
                if (sequence[seqIdx] == item)
                {
                    seqIdx++;
                }
            }
            return seqIdx == sequence.Length;
        }
    }
}
