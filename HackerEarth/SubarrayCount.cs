using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace leetcode.HackerEarth
{
    public class SubarrayCount
    {
        //        Given an Array A of N elements.

        //Find the count of sub-arrays, such that the product of elements in it is ODD.
        //        Example

        //If A = [9, 6, 15, 7, 1] . There are 7 subarrays with product of elements as Odd.

        //    Subarray[15, 7, 1] has product of elements as 15*7*1 = 105 which is Odd.
        //    Subarray[15, 7] has product of elements as 105 which is Odd.
        //        Subarray[7, 1] has product of elements as 7 which is Odd.
        //        Similarly, Subarray[9], [15], [7], [1] has product of elements as Odd.
        //        Function Description

        //Complete the countSubarray function provided in the editor.This function takes the following 2 parameters and returns the count of sub-arrays with ODD product of elements.

        //    N : Represents the number of elements
        //        A : Represents the elements in the array

        //Input :
        //1. First line contain an integer N, denoting number of elements.
        //2. Next line contain N space separated integers.

        //Constraints :
        //1 <= N <= 

        //1 <= |A[i]| <= 

        //Output :
        //Print number of sub-arrays with ODD product.

        public void RunSolution()
        {
            //var r = GetSubarrayCount(new int[] { 9, 6, 1, 5, 7, 1 });
            var r = countSubArrayWithOddProduct(new int[] { 9, 6, 1, 5, 7, 1 },6);
        }

        private int GetSubarrayCount(int[] ints)
        {
            int result = 0;
            for (int i = 0; i < ints.Length - 1; i++)
            {
                if (ints[i] % 2 != 0)
                {
                    result++;
                }
            }
            for (int i = 0; i < ints.Length - 1; i++)
            {
                int product = ints[i];
                for (int j = i + 1; j < ints.Length; j++)
                {
                    product = product * ints[j];
                    if (product % 2 != 0)
                    {
                        result++;
                    }
                }
            }
            return result;


        }

        public int countSubArrayWithOddProduct(int[] A, int N)
        {

            // Initialize the count variable
            int count = 0;

            // Initialize variable to store the
            // last index with even number
            int last = -1;

            // Initialize variable to store
            // count of continuous odd numbers
            int K = 0;

            // Loop through the array
            for (int i = 0; i < N; i++)
            {

                // Check if the number
                // is even or not
                if (A[i] % 2 == 0)
                {

                    // Calculate count of continuous
                    // odd numbers
                    K = (i - last - 1);

                    // Increase the count of sub-arrays
                    // with odd product
                    count += (K * (K + 1) / 2);

                    // Store the index of last
                    // even number
                    last = i;
                }
            }

            // N considered as index of
            // even number
            K = (N - last - 1);
            count += (K * (K + 1) / 2);

            return count;
        }
    }
}
