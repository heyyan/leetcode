using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Easy
{
    public class SelectionSort
    {
        public void RunSolution()
        {
            var r = GetSelectionSort2(new int[] { 8, 5, 2, 9, 5, 6, 3 });
        }

        private bool GetSelectionSort(int[] array)
        {
            int m = 0;

            while (m < array.Length)
            {
                int shortest = array[m];
                int shortestIdx = m;
                for (int i = m; i < array.Length; i++)
                {
                    if (shortest > array[i])
                    {
                        shortest = array[i];
                        shortestIdx = i;
                    }

                    if (i == array.Length - 1)
                    {
                        var temp = array[m];
                        array[m] = array[shortestIdx];
                        array[shortestIdx] = temp;
                        m++;
                    }
                }
            }
            return true;
        }
        private bool GetSelectionSort2(int[] array)
        {
            int currentIdx = 0;
            while (currentIdx < array.Length - 1)
            {
                int smallestIdx = currentIdx;
                for (int i = currentIdx + 1; i < array.Length; i++)
                {
                    if (array[smallestIdx] > array[i])
                    {
                        smallestIdx = i;
                    }
                }

                var temp = array[smallestIdx];
                array[smallestIdx] = array[currentIdx];
                array[currentIdx] = temp;
                currentIdx++;
            }

            return false;
        }
    }
}
