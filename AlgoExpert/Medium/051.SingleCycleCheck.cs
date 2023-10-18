using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Medium
{
    public class SingleCycleCheck
    {
        // input [2,3,1,-4,-4,2]
        // output true 
        public void RunSolution()
        {
            var rest = GetSingleCycleCheck2(new int[] { 2, 3, 1, -4, -4, 2 });
        }

        private bool GetSingleCycleCheck(int[] array)
        {
            int[] cycle = new int[array.Length];

            bool val = true;
            int i = 0;
            int count = array.Length;
            while (count > 0)
            {
                cycle[i]++;

                i = i + array[i];
                if (i >= array.Length || i < 0)
                {
                    i = (i + array.Length) % array.Length;
                }
                count--;
            }

            var s = cycle.Select(x => x == 1).ToArray();
            return val;
        }

        private bool GetSingleCycleCheck2(int[] array)
        {
            int numElementVisited = 0;
            int currentIdx = 0;
            while (numElementVisited < array.Length)
            {
                if (numElementVisited > 0 && currentIdx == 0)
                {
                    return false;
                }
                numElementVisited++;
                currentIdx = getNextIdx(currentIdx, array);
            }
            return currentIdx == 0;
        }

        private int getNextIdx(int currentIdx, int[] array)
        {
            int jump = array[currentIdx];
            int nextIdx = (currentIdx + jump) % array.Length;
            if (nextIdx < 0)
            {
                nextIdx = nextIdx + array.Length;
            }
            return nextIdx;
        }
    }
}
