using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Easy
{
    public class TandemBicycle
    {
        public void RunSolution()
        {
            var r = GetTandemBicycleMin(new int[] { 5, 5, 3, 9, 2 }, new int[] { 3, 6, 7, 2, 1 });
        }

        private int GetTandemBicycle(int[] red, int[] blue)
        {
            Array.Sort(red);
            Array.Sort(blue, (a,b)=> b.CompareTo(a));
            int result = 0;
            for (int i = 0; i < red.Length; i++)
            {
                result += Math.Max(red[i], blue[i]);
            }
            return result;
        }


        private int GetTandemBicycleMin(int[] red, int[] blue)
        {
            Array.Sort(red);
            Array.Sort(blue);
            int result = 0;
            for (int i = 0; i < red.Length; i++)
            {
                result += Math.Max(red[i], blue[i]);
            }
            return result;
        }
    }
}
