using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace leetcode.AlgoExpert.Easy
{
    public class MiniumWaitingTime
    {
        //We are given an array of positive integers.Each integer in the input array represents the duration of a query that needs to be executed.
        //Only one query can be executed at a time, but the queries can be executed in any order. We are asked to write a function that is going
        //to return the minimum amount of total waiting time for all the queries.We are allowed to mutate the input array.

        //Suppose the input array is [1, 3, 2]. The first query can be executed immediately, therefore the waiting time of the first query is 0.
        //The second query have to wait until the first one finishes before it can execute, so the waiting time of the second query is going to
        //be 1 second, the duration of the first query. The third query has to wait for both the first query and the second query to finish
        //executing before it can start.Since the second query takes 3 seconds to execute, the waiting time of the third query is going to be
        //1 + 3 seconds.So if the queries are executed in that order, then the total awaiting time for all of the queries is going to be
        //(0) + (1) + (1 + 3) = 5.
        // input [3,2,1,2,6]
        // output 17
        public void RunSolution()
        {
            var r = GetMiniumWaitingTime2(new int[] { 3, 2, 1, 2, 6 });
        }
        private int GetMiniumWaitingTime(int[] nums)
        {
            Array.Sort(nums);
            List<int> result = new List<int>();
            result.Add(0);
            result.Add(nums[0]);
            for (int i = 2; i < nums.Length; i++)
            {
                result.Add(result[i - 1] + nums[i - 1]);
            }

            return result.Sum();
        }

        private int GetMiniumWaitingTime2(int[] nums)
        {
            Array.Sort(nums);
            int totalWaitingTime =0;
            for (int i = 0; i< nums.Length; i++)
            {
                totalWaitingTime += nums[i] * (nums.Length - (i + 1));
            }

            return totalWaitingTime;
        }
    }
}
