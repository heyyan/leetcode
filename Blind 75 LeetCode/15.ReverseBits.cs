using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.Blind_75_LeetCode
{
    public class ReverseBits
    {
        // Reverse bit of a given 32 bit unsigned integer
        public void RunSolution()
        {
            //var result = GetReverseBits(10000101001010000011111010011100);
        }

        private object GetReverseBits(uint n)
        {
            int reverse = 0;
            for (int i = 0; i < 32; i++)
            {
                reverse = reverse << 1;
                reverse = (int)(reverse | (1 & n));
                n = n >> 1;
            }
            return reverse;
        }
    }
}
