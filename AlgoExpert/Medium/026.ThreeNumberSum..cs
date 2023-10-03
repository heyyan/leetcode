using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Medium
{
    public class ThreeNumberSum
    {
        //input [12,3,1,2,-6,5,-8,6]
        // output 0
        public void RunSolution()
        {
            var r = GetThreeNumberSum2(new int[] { 12, 3, 1, 2, -6, 5, -8, 6 }, 0);
        }

        private List<string> GetThreeNumberSum(int[] array, int targerSum)
        {
            List<string> trip = new List<string>();

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    for (int k = j + 1; k < array.Length; k++)
                    {
                        if (array[i] + array[j] + array[k] == targerSum)
                        {
                            trip.Add(array[i] + "," + array[j] + "," + array[k]);
                        }
                    }
                }
            }
            return trip;
        }
        private List<string> GetThreeNumberSum2(int[] array, int targetSum)
        {
            Array.Sort(array);
            var trip = new List<string>();
            for (int i = 0; i < array.Length - 2 ; i++)
            {
                var left = i + 1;
                var right = array.Length - 1;

                while (left < right)
                {
                    int sum = array[i] + array[left] + array[right];
                    if (sum == targetSum)
                    {
                        trip.Add(array[i] + "," + array[left] + "," + array[right]);
                        left++;
                        right--;
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
            }


            return trip;
        }
    }
}
