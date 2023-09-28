using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace leetcode.AlgoExpert.Easy
{
    public class ClassPhotos
    {
        /*
         * We are given two non-empty arrays of positive integers: the first is going to represent the heights of students 
         * wearing red shirts and the second is going to represent the heights of students wearing blue shirts. 
         * The two arrays will always have the same length. We are asked to write a function that is going to find out if 
         * we can take a photo of these students that satisfies the following constraints:

            All the students that are wearing red shirts must be in the same row;
            All of the students that are wearing blue shirts must be in the same row;
            The photo must have exactly two rows and the two rows must have the same number of students in them.
            Every student in the front row must be shorter than the student directly behind them in the back row.
            The function is going to arrange the students and return true if we can take a photo that follows these
        constraints; otherwise return false.
         * */
        public void RunSolution()
        {
            var r = GetClassPhotos2(new int[] { 5, 8, 1, 3, 4 }, new int[] { 6, 9, 2, 4, 5 });
        }

        private bool GetClassPhotos(int[] reds, int[] blue)
        {
            Array.Sort(reds, blue);
            if(reds.Max() <= blue.Max() )
            {
                for (int i = blue.Length-1; i > 0; i--)
                {
                    if (reds[i] > blue[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                for (int i = blue.Length-1; i > 0; i--)
                {
                    if (blue[i] > reds[i])
                    {
                        return false;
                    }
                }
                return true;
            }

            return true;
        }

        private bool GetClassPhotos2(int[] reds, int[] blue)
        {
            Array.Sort(reds, (a,b)=>b.CompareTo(a));
            Array.Sort(blue, (a,b)=>b.CompareTo(a));
            string shirtColorInFirstRow = "";
            if (reds[0] > blue[0])
            {
                shirtColorInFirstRow = "RED";
            }else
            {
                shirtColorInFirstRow = "BLUE";
            }

            for (int r = 0; r < reds.Length-1; r++)
            {
                int redShirtHeight = reds[r];
                int blueShirtHeight = blue[r];

                if(shirtColorInFirstRow == "RED")
                {
                    if(redShirtHeight >= blueShirtHeight)
                    {
                        return false;
                    }
                    
                }
                else
                {
                    if(blueShirtHeight >= redShirtHeight)
                    {
                        return false;
                    }
                }
            }
            return true;    
        }
    }
}
