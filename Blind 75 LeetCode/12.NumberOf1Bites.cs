using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.Blind_75_LeetCode
{
    public class NumberOf1Bites
    {
        // write a function that take an unsigned integer and returns the number of 1 bits 
        // has (also known as Hamming weight)
        // input 0000000000000000000000000000001011
        //outpur 3
        // explanation the input bincay string has a total of three 1 bits
        public void RunSolution()
        {
            var result = ham(00000000000000000000000010000000);
        }

        private int GetHammingWeight(int n)
        {
            int res = 0;
            while (n > 0)
            {
                res += n % 2;
                n = n >> 1;
            }
            return res;

        }

        private int GetHammingWeight2(int n)
        {
            int res = 0;
            while (n > 0)
            {
                n = n & (n - 1);
                res += 1;
            }
            return res;

        }


        public int HammingWeight(uint n)
        {
            uint res = 0;
            while (n > 0)
            {
                res += n & 1;
                n = n >> 1;
            }
            return (int)res;
        }

        public int HammingWeight2(uint n) => System.Numerics.BitOperations.PopCount(n);


        public int GetOneBits(int num)
        {
            int ans = 0;
            while (num > 0)
            {
                if ((num & 1) != 0)
                {
                    ans++;
                }
                num >>= 1;
            }
            return ans;
        }

        public int ham(int n)
        {
            int count =0;
            for (int i = 0; i < 32; i++)
            {
                int mask = 1 << i;
                if((n&mask)!=0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
