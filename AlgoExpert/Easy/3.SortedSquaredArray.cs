using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Easy
{
    public class SortedSquaredArray
    {
        public void RunSolution()
        {
            var result = GetSortedSquaredArray(new int[] { 1, 2, 3, 5, 6, 8, 9 });
            var result1 = GetSortedSquaredArray(new int[] { -2, -1, 1, 3 });
            var result2 = GetSortedSquaredArray2(new int[] { -7, -5, -4, 5, 7, 9 });
            var result3= GetSortedSquaredArray3(new int[] { -7, -5, -4,3, 5, 7, 9 });
        }

        private int[] GetSortedSquaredArray(int[] ints)
        {
            var newItem = new List<int>();
            foreach (var item in ints)
            {
                newItem.Add(item * item);
            }
            newItem.Sort();
            return newItem.ToArray();
        }

        private int[] GetSortedSquaredArray2(int[] input)
        {
            int[] results = new int[input.Length];
            int start = 0, end = input.Length - 1;
            int counter = input.Length - 1;

            while (start <= end)
            {
                int startValue = input[start];
                int endValue = input[end];
                if (Math.Abs(startValue) < Math.Abs(endValue))
                {
                    results[counter] = endValue * endValue;
                    counter--;
                    end--;
                }
                else if (Math.Abs(startValue) > Math.Abs(endValue))
                {
                    results[counter] = startValue * startValue;
                    counter--;
                    start++;
                }
                else
                {
                    if (start == end)
                    {
                        results[counter] = endValue * endValue;
                        end--;
                        start++;
                    }
                    else
                    {
                        results[counter] = endValue * endValue;
                        counter--;
                        end--;

                        results[counter] = startValue * startValue;
                        counter--;
                        start++;
                    }

                }

            }
            return results;
        }

        private int[] GetSortedSquaredArray3(int[] input)
        {
            int[] sortedSquare = new int[input.Length];
            int smallerValueIdx = 0;
            int largerValueIdx = input.Length - 1;

            for (int idx = input.Length - 1; idx >= 0; idx--)
            {
                int smallerValue = input[smallerValueIdx];
                int largerValue = input[largerValueIdx];

                if (Math.Abs(smallerValue) > Math.Abs(largerValue))
                {
                    sortedSquare[idx] = smallerValue * smallerValue;
                    smallerValueIdx++;
                }
                else
                {
                    sortedSquare[idx] = largerValue * largerValue;
                    largerValueIdx--;
                }
            }
            return sortedSquare;
        }
    }
}
