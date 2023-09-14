using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.HackerEarth
{
    //Sort it up or the Dutch national flag problem
    // you are given an array arr consiting on only zeroes ones and twos
    // sortthe same array in place and return it. Do not create a new array
    public class SortItUp
    {
        public void RunSolution()
        {
          //  var input = new int[] { 2, 0, 1, 0, 2 };
           // var input = new int[] { 1,1,1, 0, 1, 0, 2 };
            var input = new int[] { 2,2,2,0,0,0,1,1,1 };
            var result = GetSortItUp(input);
        }

        private int[] GetSortItUp(int[] arr)
        {
            int l_bound = 0;
            int r_bound = arr.Length - 1;
            int i = 0;
            while (i <= r_bound)
            {
                if (arr[i] == 2)
                {
                    arr[i] = arr[r_bound];
                    arr[r_bound] = 2;
                    r_bound--;
                }else if (arr[i] == 1)
                {
                    i++;
                }else
                {
                    arr[i] = arr[l_bound];
                    arr[l_bound] = 0;
                    l_bound++;
                    i++;
                }
            }
            return arr;
        }
    }
}
