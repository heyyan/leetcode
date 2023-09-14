using System;
using System.Collections.Generic;

namespace leetcode.HackerEarth
{
    // you are given  a 9*9 array arr.
    // it is split into nine 3*3 boxes
    // each digit in arr must appear only once in each row, each column and each box
    // -1 is considered a blank element. only consider elements 1 to 9 while validating
    // output is 1 if valid, 0 if not
    public class ValidSudoku
    {
        public void RunSolution()
        {
            int[,] input = {
                            { 1,  -1, -1, -1,  2, -1,  4, -1,  9 },
                            { 3,  -1,  5, -1, -1,  7, -1, -1, -1 },
                            { -1,  4, -1,  1, -1, -1,  5, -1,  7 },
                            { 5,   6, -1,  8, -1, -1, -1,  3, -1 },
                            { -1,  2, -1, -1,  9, -1, -1, -1, -1 },
                            { -1, -1, -1, -1, -1, -1, -1,  2, -1 },
                            { 8,  -1,  6, -1, -1, -1, -1, -1, 1 },
                            { -1, -1, -1,  9, -1, -1,  3, -1, -1 },
                            { 4,  -1, -1, -1,  2, -1, -1,  1, -1 },
            };
            var result = GetValidSudoku2(input);
        }

        private bool GetValidSudoku(int[,] arr)
        {
            int[,] row = new int[9, 9];
            int[,] col = new int[9, 9];
            int[,] box = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (arr[i, j] != -1)
                    {
                        int value = arr[i, j] - 1;
                        int boxno = (i / 3) * 3 + (j / 3);
                        if (row[i, value] == 1 || col[j, value] == 1 || box[boxno, value] == 1)
                        {
                            return false;
                        }
                        row[i, value] = 1;
                        col[j, value] = 1;
                        box[boxno, value] = 1;
                    }
                }
            }
            return true;
        }

        private bool GetValidSudoku2(int[,] arr)
        {
            HashSet<string> seen = new HashSet<string>();
            for (int i = 0;i < 9;i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    var val = arr[i, j];
                    if(val != -1)
                    {
                       if( !seen.Add(val + " found in row " + i) 
                            || !seen.Add(val + " found in col " + j) 
                            || !seen.Add(val + " found in box " + i/3 + "-" + j/3))
                        {
                            return false;
                        }

                    }
                }
            }
            return true;
        }
    }
}
