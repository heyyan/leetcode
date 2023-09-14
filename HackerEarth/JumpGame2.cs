using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.HackerEarth
{
    public class JumpGame2
    {
        // you are given an array arr. you start form index 0, and the element at each index denotes,
        // the maximun distance you can jump from that index. For instance, in the following example:
        // 3 1 2 1 7
        // if you start form index 0, the element at arr[0][3] indicates that the maximum index you can 
        // jump to is 3
        // retun the minimim number of jumps requires to reach the end of the array.

        public void RunSolution()
        {
            //int[] input = { 1, 2, 5, 6, 7 };
            int[] input = { 4,1,1,1,0,9 };
            var result = NoOfJumps(input);
        }

        private int GetJumpGame2(int[] arr)
        {
            int index = 0;
            int nextIndex = 0;
            while (nextIndex < arr.Length)
            {
                var currentVal = arr[index];
                if (nextIndex + currentVal <= arr.Length)
                {
                    nextIndex = nextIndex + currentVal;
                }
            }

            return nextIndex;

        }

        private int NoOfJumps(int[] arr)
        {
            int jumps = 0;
            int target = arr.Length - 1;
            while (target != 0)
            {
                for (int i = 0; i < target; i++)
                {
                    if(i + arr[i] >= target)
                    {
                        target = i;
                        break;
                    }
                }
                jumps++;
            }
            return jumps;
        }
    }
}
