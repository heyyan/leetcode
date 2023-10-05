using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Medium
{
    public class ArrayOfProducts
    {
        //input [5,1,4,2]
        // output [8,40,10,20]
        public void RunSolution()
        {
            var r = arrayOfProducts3(new int[] { 5, 1, 4, 2 });
        }

        private int[] arrayOfProducts(int[] array)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < array.Length; i++)
            {
                int mult = 1;
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[i] != array[j])
                    {
                        mult = mult * array[j];
                    }
                }
                list.Add(mult);
            }
            return list.ToArray();
        }

        private int[] arrayOfProducts3(int[] array)
        {
            int[] list = new int[array.Length];

            int product = 1;
            for (int i = 0; i < array.Length; i++)
            {
                list[i]=product;
                product = product * array[i];
            }
            product = 1;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                list[i] *= product;
                product = product * array[i];
            }

            return list.ToArray();
        }

        private int[] arrayOfProducts2(int[] array)
        {
            List<int> list = new List<int>();
            int[] left = new int[array.Length];
            int[] right = new int[array.Length];

            int product = 1;
            for (int i = 0; i < array.Length; i++)
            {
                left[i] = product;
                product = product * array[i];
            }
            product = 1;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                right[i] = product;
                product = product * array[i];
            }

            for (int i = 0; i < array.Length; i++)
            {
                list.Add(left[i] * right[i]);
            }

            return list.ToArray();
        }
    }
}
