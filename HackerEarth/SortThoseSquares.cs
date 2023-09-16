using System;
using System.Collections.Generic;

namespace leetcode.HackerEarth
{
    public class SortThoseSquares
    {
        // you are given a sorted array arr. your task in to sort the square of each element of the arry
        // input -4, -1, 0,3 10
        //output 0 1 9 16 100

        public void RunSolution()
        {
            var result = GETSortThoseSquares(new int[] { -4, -1, 1, 3, 10 });
        }

        private int[] GETSortThoseSquares(int[] arr)
        {
            //var pos = new List<int>();
            //var neg = new List<int>();
            //var result = new List<int>();

            //foreach (var item in arr)
            //{
            //    if (item < 0)
            //    {
            //        neg.Add(item);
            //    }
            //    else if (item > 0)
            //    {
            //        pos.Add(item);
            //    }
            //}
            int[] result = new int[arr.Length];

            int start = 0;
            int end = arr.Length - 1;
            int pos = arr.Length - 1;
            while (start <= end)
            {
                int strSq = arr[start] * arr[start];
                int endSq = arr[end] * arr[end];

                if (strSq > endSq)
                {
                    result[pos] = strSq;
                    start++;
                }
                else
                {
                    result[pos] = endSq;
                    end--;
                }
                pos--;
            }

            return result;
        }
    }
}
