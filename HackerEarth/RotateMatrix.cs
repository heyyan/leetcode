using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.HackerEarth
{
    public class RotateMatrix
    {
        //you are given an n*n matric you must rotate it to the right by 90 degrees
        // before roation
        //1   2   3
        //4   5   6
        //7   8   9
        //after rotation
        //7   4   1
        //8   5   2
        //9   6   3
        // all modification must take place in the same matrix

        public void RunSolution()
        {
            int[][] input = {  new int[] {1,2,3},
                               new int[] {4,5,6},
                               new int[] {7,8,9}
                            };
            var result = GetRotateMatrix(input);
        }

        private int[][] GetRotateMatrix(int[][] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n / 2; i++)
            {
                for (int j = i; j < n - i - 1; j++)
                {
                    int temp = arr[i][j];
                    arr[i][j] = arr[n - 1 - j][i];
                    arr[n - 1 - j][i] = arr[n - 1 - i][n - 1 - j];
                    arr[n - 1 - i][n - 1 - j] = arr[j][n - 1 - i];
                    arr[j][n - 1 - i] = temp;
                }
            }

            return arr;
        }
    }
}
