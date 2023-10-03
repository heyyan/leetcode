using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Easy
{
    public class BinarySearch
    {
        // input [0,1,21,33,45,45,61,71,72,73]
        // output true
        public void RunSolution()
        {
            var r = GetBinarySearch2(new int[] { 0, 1, 21, 33, 45, 45, 61, 71, 72, 73 }, 93);
        }

        private bool GetBinarySearch(int[] arr, int search)
        {
            bool reuslt = false;
            int mid = arr.Length / 2;
            if (arr.Length <= 0)
            {
                return false;
            }
            if (arr[mid] == search)
            {
                return true;
            }
            if (search < arr[mid])
            {
                reuslt = GetBinarySearch(arr.Take(new Range(0, mid - 1)).ToArray(), search);
            }
            else
            {
                reuslt = GetBinarySearch(arr.Take(new Range(mid + 1, arr.Length)).ToArray(), search);
            }
            return reuslt;
        }
        private bool GetBinarySearch2(int[] arr, int search)
        {
            int start = 0;
            int end = arr.Length - 1;

            while (start <= end)
            {
                int mid = (end + start) / 2;
                if (arr[mid] == search)
                {
                    return true;
                }

                if (search < arr[mid])
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
            }
            return false;
        }


        private bool BinarySearchHelper(int[] arr, int traget, int left, int right)
        {
            if (left > right)
            {
                return false;
            }

            int middle = (left + right) / 2;
            int potentailMatch = arr[middle];

            if (potentailMatch == traget)
            {
                return true;
            }
            if (traget < potentailMatch)
            {
                return BinarySearchHelper(arr, traget, left, middle - 1);
            }
            else
            {
                return BinarySearchHelper(arr, traget, middle - 1, right);
            }
        }
    }
}
