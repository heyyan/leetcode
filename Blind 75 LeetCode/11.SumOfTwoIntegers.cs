using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.Blind_75_LeetCode
{
    public class SumOfTwoIntegers
    {
        // Given two integers a and b return the sum of the two integers withour using the opeator + and -
        //input a = 1 b = 2
        //output = 3
        public void RunSolution()
        {
            var result = GetSumOfTwoIntegers(9, 11);
        }

        private int GetSumOfTwoIntegers(int a, int b)
        {
            while (b != 0)
            {
                int temp = (a & b) << 1;
                a = a ^ b;
                b = temp;
            }
            return a;
        }
    }
}
