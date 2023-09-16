using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.HackerEarth
{
    public class MissingNo
    {
        // you are given an integer n,along with an array of n-1 numbers in the range 1 to n with no duplicates. one
        // number is missing from the array . Find that number 
        public void RunSolution()
        {
            var result = GETMissingNo2(new int[] { 4, 1, 2 }, 4);
        }

        private object GETMissingNo(int[] arr)
        {
            Array.Sort(arr);
            int miss = -1;
            //// check the first number
            //if (arr[1] - arr[0] > 1)
            //{
            //    return arr[1] - 1;
            //}
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i + 1] - arr[i] > 1)
                {
                    miss = arr[i] + 1; ;
                }
            }
            return miss;
        }
        private object GETMissingNo2(int[] arr, int n)
        {
            int result = n * (n + 1) / 2;
            int sum = arr.Sum(x => x);
            return result - sum;
        }
    }
}
