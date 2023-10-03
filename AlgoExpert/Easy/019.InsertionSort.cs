using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Easy
{
    public class InsertionSort
    {
        // input [8,5,2,9,5,6,3]
        //output [2,3,5,5,6,8,9]
        public void RunSolution()
        {
            var r = GetInsertionSort2(new int[] { 8, 5, 2, 9, 5, 6, 3 });
        }

        private bool GetInsertionSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    var temp = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = temp;

                    for (int j = i; j > 0; j--)
                    {
                        if (array[j - 1] > array[j])
                        {
                            temp = array[j - 1];
                            array[j - 1] = array[j];
                            array[j] = temp;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            return true;
        }

        private bool GetInsertionSort2(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int j = i;
                while (j > 0 && array[j] < array[j - 1])
                {
                    var temp = array[j];
                    array[j] = array[j - 1];
                    array[j - 1] = temp;
                    j--;
                }
            }
            return true;
        }
    }
}
