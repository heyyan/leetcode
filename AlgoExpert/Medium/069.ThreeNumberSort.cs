using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Medium
{
    public class ThreeNumberSort
    {
        // input [1,0,0,-1,-1,0,1,1]
        //  order [0,1,-1]
        // output [0,0,0,1,1,1,-1,-1]
        public void RunSolution()
        {
            var values = GetThreeNumberSort5(new int[] { 1, 0, 0, -1, -1, 0, 1, 1 }, new int[] { 0, 1, -1 });
        }


        private int[] GetThreeNumberSort5(int[] array, int[] order)
        {
            int firstValue = order[0];
            int secondVale = order[1];

            int firstIdx = 0;
            int secondIdx = 0;
            int thirdIdx = array.Length - 1;

            while (secondIdx <= thirdIdx)
            {
                int value = array[secondIdx];
                if (value == firstValue)
                {
                    swap(array, firstIdx, secondIdx);
                    firstIdx++;
                    secondIdx++;
                }else if (value == secondVale)
                {
                    secondIdx++;
                }
                else
                {
                    swap(array, thirdIdx, secondIdx);
                    thirdIdx--;
                }

            }
            return array;
        }
        private int[] GetThreeNumberSort4(int[] array, int[] order)
        {
            int firstValue = order[0];
            int thridVale = order[2];

            int firstIdx = 0;
            for (int idx = 0; idx < array.Length; idx++)
            {
                if (array[idx] == firstValue)
                {
                    swap(array, firstIdx, idx);
                    firstIdx++;
                }
            }

            int thridIdx = array.Length - 1;
            for (int idx = array.Length - 1; idx > 0; idx--)
            {
                if (array[idx] == thridVale)
                {
                    swap(array, idx, thridIdx);
                    thridIdx--;
                }
            }

            return array;
        }

        private int[] GetThreeNumberSort3(int[] array, int[] order)
        {
            int[] valueCounts = new int[3];
            for (int i = 0; i < array.Length; i++)
            {
                var orderIdx = Array.IndexOf(order, array[i]);
                valueCounts[orderIdx]++;
            }

            for (int i = 0; i < 3; i++)
            {
                int value = order[i];
                int count = valueCounts[i];
                int numElementsBefore = valueCounts.Take(i).Sum();
                for (int n = 0; n < count; n++)
                {
                    int currentIdx = numElementsBefore + n;
                    array[currentIdx] = value;
                }
            }

            return array;
        }

        private int[] GetThreeNumberSort2(int[] array, int[] order)
        {
            int j = 0;
            for (int i = 0; i < order.Length - 1; i++)
            {
                int itemToSwap = order[i];
                for (int x = j; x < array.Length - 1; x++, j++)
                {
                    if (array[x] != itemToSwap)
                    {
                        bool found = false;
                        int z = x + 1;
                        while (!found && z <= array.Length - 1)
                        {
                            if (array[z] == itemToSwap)
                            {
                                found = true;
                                break;
                            }
                            z++;
                        }
                        if (found)
                        {
                            swap(array, x, z);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            return array;
        }

        private void swap(int[] array, int x, int y)
        {
            var temp = array[x]; array[x] = array[y]; array[y] = temp;
        }
        private int[] GetThreeNumberSort(int[] array, int[] order)
        {
            Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
            for (int i = 0; i < order.Length; i++)
            {
                map.Add(order[i], new List<int>());
            }

            for (int i = 0; i < array.Length; i++)
            {
                map[array[i]].Add(array[i]);
            }

            var result = map.SelectMany(x => x.Value).ToList();
            return result.ToArray();
        }
    }
}
