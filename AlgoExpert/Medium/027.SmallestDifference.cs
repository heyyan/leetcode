using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Medium
{
    public class SmallestDifference
    {
        //input [12,3,1,2,-6,5,-8,6]
        // output 0
        public void RunSolution()
        {
            var r = GetSmallestDifference3(new int[] { -1, 5, 10, 20, 28, 3 }, new int[] { 26, 134, 135, 15, 17 });
        }

        private Tuple<int, int> GetSmallestDifference(int[] array1, int[] array2)
        {
            Tuple<int, int> tuple = Tuple.Create(0, 0);
            int smallest = int.MaxValue;
            for (int i = 0; i < array1.Length; i++)
            {
                for (int j = 0; j < array2.Length; j++)
                {
                    int res = Math.Abs(array1[i] - array2[j]);
                    if (res < smallest)
                    {
                        smallest = res;
                        tuple = Tuple.Create(array1[i], array2[j]);
                    }
                }
            }
            return tuple;
        }

        private Tuple<int, int> GetSmallestDifference2(int[] array1, int[] array2)
        {
            Array.Sort(array1);
            Array.Sort(array2);
            Tuple<int, int> tuple = Tuple.Create(0, 0);
            int smallest = int.MaxValue;
            int start1 = 0;
            int start2 = 0;
            while (start1 < array1.Length && start2 < array2.Length)
            {
                int res = Math.Abs(array1[start1] - array2[start2]);
                if (res < smallest)
                {
                    smallest = res;
                    tuple = Tuple.Create(array1[start1], array2[start2]);
                }

                if (array1[start1] < array2[start2])
                {
                    start1++;
                }
                else
                {
                    start2++;
                }
            }
            return tuple;
        }


        private Tuple<int, int> GetSmallestDifference3(int[] arrayOne, int[] arrayTwo)
        {
            Array.Sort(arrayOne);
            Array.Sort(arrayTwo);
            Tuple<int, int> smallestPair = Tuple.Create(0, 0);
            int smallest = int.MaxValue;
            int current = int.MaxValue;
            int idxOne = 0;
            int idxTwo = 0;
            while (idxOne < arrayOne.Length && idxTwo < arrayTwo.Length)
            {
                int firstNum = arrayOne[idxOne];
                int secondNum = arrayTwo[idxTwo];

                if (firstNum < secondNum)
                {
                    current = secondNum - firstNum;
                    idxOne++;
                }
                else if (secondNum < firstNum)
                {
                    current = firstNum - secondNum;
                    idxTwo++;
                }
                else
                {
                    return Tuple.Create(firstNum, secondNum);
                }

                if (smallest > current)
                {
                    smallest = current;
                    smallestPair = Tuple.Create(firstNum, secondNum);
                }
            }
            return smallestPair;
        }
    }
}
