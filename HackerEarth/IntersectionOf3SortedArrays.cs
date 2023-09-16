using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.HackerEarth
{
    public class IntersectionOf3SortedArrays
    {
        // you are given three sorted arr1, arr2, arr3. your task is to return a sorted array of elements that are common to all three arrays
        //input
        //5
        //5
        //5
        //12345
        //12458
        //12579

        public void RunSolution()
        {
            var result = GETIntersectionOf3SortedArrays2(5, new int[] { 1, 2, 3, 4, 5 }, 5, new int[] { 1, 3, 4, 5, 8 }, 5, new int[] { 1, 2, 5, 7, 9 });
        }

        private object GETIntersectionOf3SortedArrays(int n1, int[] arr1, int n2, int[] arr2, int n3, int[] arr3)
        {
            var result = new List<int>();
            for (int i = 0; i < n1; i++)
            {
                int first = arr1[i];
                bool found1 = false, found2 = false;
                for (int j = 0; j < n2; j++)
                {
                    if (arr2[j] == first)
                    {
                        found1 = true; break;
                    }
                    if (arr2[j] > first)
                    {
                        break;
                    }

                }
                if (found1)
                {
                    for (int k = 0; k < n3; k++)
                    {
                        if (arr3[k] == first)
                        {
                            found2 = true; break;
                        }
                        if (arr3[k] > first)
                        {
                            break;
                        }
                    }
                    if (found2)
                    {
                        result.Add(first);
                    }
                }


            }
            return result;
        }
        private object GETIntersectionOf3SortedArrays2(int n1, int[] arr1, int n2, int[] arr2, int n3, int[] arr3)
        {
            Dictionary<int, int> result = new Dictionary<int, int>();
            for (int i = 0; i < n1; i++)
            {
                result.Add(arr1[i], 1);
            }
            for (int j = 0; j < n2; j++)
            {
                if (result.ContainsKey(arr2[j]))
                {
                    result[arr2[j]]++;
                }
                else
                {
                    result.Add(arr2[j], 1);
                }
            }

            for (int k = 0; k < n3; k++)
            {
                if (result.ContainsKey(arr3[k]))
                {
                    result[arr3[k]]++;
                }
                else
                {
                    result.Add(arr3[k], 1);
                }
            }
            var r = result.Where(x => x.Value > 2).Select(x=>x.Key).ToList();
            return r;
        }


        public IList<int> ArraysIntersection(int[] arr1, int[] arr2, int[] arr3)
        {
            List<int> intersection = new List<int>();
            int length1 = arr1.Length, length2 = arr2.Length, length3 = arr3.Length;
            int index1 = 0, index2 = 0, index3 = 0;

            while (index1 < length1 && index2 < length2 && index3 < length3)
            {
                int num1 = arr1[index1], num2 = arr2[index2], num3 = arr3[index3];

                if (num1 == num2 && num1 == num3)
                {
                    intersection.Add(num1);
                    index1++;
                    index2++;
                    index3++;
                }
                else
                {
                    int increment1 = 0, increment2 = 0, increment3 = 0;

                    if (num1 < num2 || num1 < num3)
                        increment1 = 1;
                    if (num2 < num1 || num2 < num3)
                        increment2 = 1;
                    if (num3 < num1 || num3 < num2)
                        increment3 = 1;

                    index1 += increment1;
                    index2 += increment2;
                    index3 += increment3;
                }
            }

            return intersection;
        }
    }
}
