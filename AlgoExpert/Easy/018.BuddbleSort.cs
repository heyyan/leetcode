using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Easy
{
    public class BuddbleSort
    {
        // input [8,5,2,9,5,6,3]
        //output [2,3,5,5,6,8,9]
        public void RunSolution()
        {
            var r = GetBuddbleSort(new int[] { 8, 5, 2, 9, 5, 6, 3 });
        }

        private bool GetBuddbleSort(int[] array)
        {
            bool swap = false;
            int counter = 1;
            do
            {
                swap = false;
                for (int i = 0; i < array.Length - counter; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        var temp = array[i + 1];
                        array[i + 1] = array[i];
                        array[i] = temp;
                        swap = true;
                    }
                }
                counter++;
            }
            while (swap);

            return swap;
        }
    }
}
