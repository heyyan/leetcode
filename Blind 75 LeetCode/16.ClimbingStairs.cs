using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.Blind_75_LeetCode
{
    public class ClimbingStairs
    {
        // you are climbing a staircase. it takes n steps to reach the top
        // Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top
        // input 2
        // output 2
        // Explanation There are two way to climb to the top 
        // 1. 1 step + 1 step
        // 2. 2 Steps

        //input 3
        // output 3
        // Explanation There are two way to climb to the top 
        // 1. 1 step + 1 step + 1 step
        // 2. 1 step + 2 Steps
        // 2. 2 step + 1 Steps
        public void RunSolution()
        {
            var result = GetClimbingStairs(5);
        }

        private int GetClimbingStairs(int n)
        {
            int one = 1, two = 1;
            for (int i = 0; i < n - 1; i++)
            {
                var temp = one;
                one = one + two;
                two = temp;
            }
            return one;
        }
    }
}
