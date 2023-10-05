using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Medium
{
    public class FirstDuplicateValue
    {
        //input [2,1,5,2,3,3,4]
        // output [8,40,10,20]
        public void RunSolution()
        {
            var r = firstDuplicateValue2(new int[] { 2, 1, 5, 2, 3, 3, 4 });
        }

        private int firstDuplicateValue(int[] ints)
        {
            List<int> list = new List<int>();
            int result = -1;
            for (int i = 0; i < ints.Length; i++)
            {
                if (list.Contains(ints[i]))
                {
                    result = ints[i];
                    break;
                }
                else
                {
                    list.Add(ints[i]);
                }
            }
            return result;
        }

        private int firstDuplicateValue2(int[] array)
        {
            for (int i = 0; array[i] < array.Length; i++)
            {
                int absValue = Math.Abs(array[i]);
                if (array[absValue - 1] < 0)
                {
                    return absValue;
                }
                array[absValue - 1] *= -1;
            }
            return -1;
        }

    }
}
