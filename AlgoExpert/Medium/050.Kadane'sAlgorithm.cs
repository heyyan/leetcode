using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Medium
{
    public class KadanesAlgorithm
    {
        // input [3,5,-9,1,3,-2,3,4,7,2,-9,6,3,1,-5,4]
        // output 19 
        public void RunSolution()
        {
            var rest = GetKadanesAlgorithm2(new int[] { 3, 5, -9, 1, 3, -2, 3, 4, 7, 2, -9, 6, 3, 1, -5, 4 });
        }

        private int GetKadanesAlgorithm(int[] array)
        {
            var kadane =new int[array.Length];
            kadane[0] = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                var MaxEnding = Math.Max(array[i] + kadane[i-1], array[i]);
                kadane[i] = MaxEnding;
            }

            return kadane.Max();
        }

        private int GetKadanesAlgorithm2(int[] array)
        {
           var maxEndingHere = array[0];
            var maxSoFar = array[0];
            for(int i = 1;i < array.Length;i++)
            {
                maxEndingHere = Math.Max(array[i], maxEndingHere + array[i]);
                maxSoFar= Math.Max(maxSoFar, maxEndingHere);
            }
            return maxSoFar;
        }
    }
}
