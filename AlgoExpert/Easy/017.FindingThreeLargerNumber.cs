using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Easy
{
    public class FindingThreeLargerNumber
    {
        // input [141,1,17,-7,-17,-27,18,541,8,7,7]
        //output [18,141,541]
        public void RunSolution()
        {
            var r = findThreeLargertNumbers(new int[] { 141, 1, 17, -7, -17, -27, 18, 541, 8, 7, 7 });
        }

        private int[] GetFindingThreeLargerNumber(int[] arr)
        {
            Array.Sort(arr);

            return arr.Take(new Range(arr.Length - 3, arr.Length)).ToArray();
        }

        private int[] GetFindingThreeLargerNumber2(int[] arr)
        {
            int[] larget = new int[3];
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 2; j >= 0; j--)
                {
                    // if the number is larger add it
                    if (arr[i] > larget[j])
                    {
                        for (int k = 0; k < j; k++)
                        {
                            larget[k] = larget[k + 1];
                        }
                        larget[j] = arr[i];
                        break;
                    }

                }
            }
            return larget;
        }


        private int[] findThreeLargertNumbers(int[] arr)
        {
            int[] threeLargest = new int[3];
            foreach (int num in arr)
            {
                UpdateLargest(threeLargest, num);
            }
            return threeLargest;
        }

        private void UpdateLargest(int[] threeLargest, int num)
        {
            if (num > threeLargest[2])
            {
                shiftAndUpdate(threeLargest, num, 2);
            }
            else if (num > threeLargest[1])
            {
                shiftAndUpdate(threeLargest, num, 1);
            }
            else if (num > threeLargest[0])
            {
                shiftAndUpdate(threeLargest, num, 0);
            }
        }

        private void shiftAndUpdate(int[] threeLargest, int num, int idx)
        {
            for (int i = 0; i <= idx; i++)
            {
                if (i == idx)
                {
                    threeLargest[i] = num; break;
                }
                else
                {
                    threeLargest[i] = threeLargest[i + 1];
                }
            }
        }
    }
}
