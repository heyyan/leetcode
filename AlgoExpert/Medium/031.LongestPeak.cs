using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Medium
{
    public class LongestPeak
    {
        //input [1,2,3,3,4,0,10,6,5,-1,-3,2,3]
        // output 6
        public void RunSolution()
        {
            var r = longestPeak(new int[] { 1, 2, 3, 3, 4, 0, 10, 6, 5, -1, -3, 2, 3 });
            //var r = GetLongestPeak(new int[] { 11, 2, 3, 3, 4, 0, 10, 6, 5, -1, -3, 2, 3 });
        }

        private int GetLongestPeak(int[] array)
        {
            Dictionary<string, int> map = new Dictionary<string, int>();
            int start = 0;
            int peek = 1;
            int end = 2;

            while (end < array.Length)
            {
                if (array[start] < array[peek] && array[peek] > array[end])
                {
                    if (array[start] > array[peek])
                    {
                        start = peek;
                        peek = start + 1;
                        end = peek + 1;
                    }
                    while (array[peek] < array[peek + 1])
                    {
                        peek++;
                        end = peek + 1;
                    }
                    while (array[end] > array[end + 1])
                    {
                        end++;
                    }


                    map.Add($"{array[start]},{array[peek]},{array[end]},{peek}", end - start + 1);
                }
                start = peek;
                peek = start + 1;
                end = peek + 1;
            }

            return map.Max(x => x.Value);
        }

        private int GetLongestPeak2(int[] array)
        {
            List<int> peeks = new();
            int start = 0;
            int peek = 1;
            int end = 2;
            while (end < array.Length)
            {
                // find all the peeks
                if (array[start] < array[peek] && array[peek] > array[end])
                {
                    peeks.Add(peek);
                }
                start++;
                peek++;
                end++;
            }
            int max = 0;
            int maxPeek = 0;
            foreach (int p in peeks)
            {
                peek = p;
                start = peek - 1;
                end = peek + 1;
                while (start > 0)
                {
                    if (array[start - 1] < array[start])
                    {
                        start--;
                    }
                    else
                    {
                        break;
                    }

                }

                while (end < array.Length)
                {
                    if (array[end] > array[end + 1])
                    {
                        end++;
                    }
                    else
                    {
                        break;
                    }
                }
                int result = end - start;
                if (result > max)
                {
                    max = result + 1;
                    maxPeek = peek;
                }
            }

            return max;
        }

        private int GetLongestPeak3(int[] array)
        {
            int start = 0;
            int peek = 1;
            int end = 2;
            int max = 0;
            int maxPeek = 0;
            while (end < array.Length)
            {
                // find all the peeks
                if (array[start] < array[peek] && array[peek] > array[end])
                {
                    while (start > 0)
                    {
                        if (array[start - 1] < array[start])
                        {
                            start--;
                        }
                        else
                        {
                            break;
                        }

                    }

                    while (end < array.Length)
                    {
                        if (array[end] > array[end + 1])
                        {
                            end++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    int result = end - start;
                    if (result > max)
                    {
                        max = result + 1;
                        maxPeek = peek;
                    }
                }
                start++;
                peek++;
                end++;
            }
            return max;
        }

        private int longestPeak(int[] array)
        {
            int longestPeakLength = 0;
            int i = 1;
            while (i < array.Length - 1)
            {
                bool isPeak = array[i - 1] < array[i] && array[i] > array[i + 1];
                if (!isPeak)
                {
                    i++;
                    continue;
                }

                int leftIdx = i - 2;
                while (leftIdx >= 0 && array[leftIdx] < array[leftIdx + 1])
                {
                    leftIdx--;
                }
                int rightIdx = i + 2;
                while (rightIdx < array.Length && array[rightIdx] < array[rightIdx - 1])
                {
                    rightIdx++;
                }
                int currentPealLength = rightIdx - leftIdx - 1;
                longestPeakLength = Math.Max(longestPeakLength, currentPealLength);
                i = rightIdx;
            }
            return longestPeakLength;
        }
    }
}
