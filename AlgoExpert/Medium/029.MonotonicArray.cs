using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Medium
{
    public class MonotonicArray
    {
        //input [-1,-5,-10,-1100,-1101,-1102,-9001]
        // output true
        public void RunSolution()
        {
            //var r = isMonotonicArray2(new int[] { -1, -5, -10, -1100, -1101, -1102, -9001 });
            //var r = isMonotonicArray2(new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 });
            var r = isMonotonicArray2(new int[] { 1, 2, 3,2, 4, 5, 6, 7, 8, 9 });
        }

        private bool GetMonotonicArray(int[] array)
        {
            bool isIncreasing = false;
            if (array[0] < array[array.Length - 1])
            {
                isIncreasing = true;
            }

            for (int i = 1; i < array.Length; i++)
            {
                if (isIncreasing)
                {
                    if (array[i - 1] > array[i])
                    {
                        return false;
                    }
                }
                else
                {
                    if (array[i - 1] < array[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool isMonotonicArray(int[] array)
        {
            if (array.Length <= 2) { return true; }

            int direction = array[1] - array[0];
            for (int i = 2; i < array.Length; i++)
            {
                if (direction == 0)
                {
                    direction = array[i] - array[i - 1];
                    continue;
                }
                if (breakDirection(direction, array[i - 1], array[i]))
                {
                    return false;
                }
            }
            return true;
        }

        private bool breakDirection(int direction, int previouseInt, int curretInt)
        {
            int difference = curretInt - previouseInt;
            if (direction > 0)
                return difference < 0;
            return difference > 0;
        }

        private bool isMonotonicArray2(int[] array)
        {
            bool isNonDecreasing = true;
            bool isNonIncreasing = true;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < array[i - 1])
                {
                    isNonDecreasing = false;
                }
                if (array[i] > array[i - 1])
                {
                    isNonIncreasing = false;
                }
            }
            return isNonDecreasing ||isNonIncreasing;
        }
    }
}
