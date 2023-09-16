using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.HackerEarth
{
    public class TwoSum
    {
        // it takes two to tango
        // you are given an array arr. along with an integer named target. Calculate the number of pairs in arr that can be added 
        // togather to from a target
        //input  
        // 6
        // 1 2 3 2 9 10
        // 4

        //output 2

        public void RunSolution()
        {
            int result = TwoSumSol(new int[] { 1, 2, 3, 2, -1, 5 }, 4);

        }

        private int GetTwoSum(int[] ints, int target)
        {
            int result = 0;
            List<int> list = new List<int>();
            foreach (int i in ints)
            {
                int res = target - i;
                if (list.Contains(res))
                {
                    result++;
                }
                else
                {
                    list.Add(i);
                }
            }
            return result;
        }

        private int TwoSumSol(int[] arr, int target)
        {
            int result = 0;
            Dictionary<int, int> hm = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                //if (arr[i] >= target)
                //{
                //    continue;
                //}
                if (hm.ContainsKey(arr[i]))
                {
                    result += hm[arr[i]];
                }
                if (hm.ContainsKey(target - arr[i]))
                {
                    hm[target - arr[i]] = hm[target - arr[i]] + 1;
                }
                else
                {
                    hm.Add(target - arr[i], 1);
                }
            }
            return result;
        }
    }
}
