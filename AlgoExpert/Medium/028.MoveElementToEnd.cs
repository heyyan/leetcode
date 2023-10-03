using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Medium
{
    public class MoveElementToEnd
    {
        //input [12,3,1,2,-6,5,-8,6]
        // output 0
        public void RunSolution()
        {
            var r = GetMoveElementToEnd3(new int[] { 2, 1, 2, 2, 2, 3, 4, 2 }, 2);
        }

        private int[] GetMoveElementToEnd(int[] array, int target)
        {
            int start = 0;
            int end = 1;
            while (start < array.Length && end < array.Length)
            {
                // check if start equl to target then move it
                if (array[start] == target)
                {
                    // if end is on nontarget swap
                    if (array[end] != target)
                    {
                        // swap the
                        var temp = array[start];
                        array[start] = array[end];
                        array[end] = temp;
                        start++;
                        end++;
                    }
                    else
                    {
                        // check the next one
                        end++;
                    }
                }
                else
                {
                    // move start
                    start++;
                    if (start == end)
                    {
                        end++;
                    }
                }
            }
            return array;
        }

        private int[] GetMoveElementToEnd2(int[] array, int toMove)
        {
            int start = 0;
            int end = array.Length - 1;
            while (start < end)
            {
                // check if start equl to target then move it
                if (array[start] == toMove)
                {
                    // if end is on nontarget swap
                    if (array[end] != toMove)
                    {
                        // swap the
                        var temp = array[start];
                        array[start] = array[end];
                        array[end] = temp;
                        start++;
                        end--;
                    }
                    else
                    {
                        // check the next one
                        end--;
                    }
                }
                else
                {
                    // move start
                    start++;
                }
            }
            return array;
        }

        private int[] GetMoveElementToEnd3(int[] array, int toMove)
        {
            int i = 0;
            int j = array.Length - 1;
            while (i<j)
            {
                while(i<j && array[j] == toMove)
                {
                    j--;
                }
                if (array[i] == toMove)
                {
                    var temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
                i++;    
            }
            return array;
        }
    }
}
