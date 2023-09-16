using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.HackerEarth
{
    public class ShuffleTheArray
    {
        // you are given an array arr consisting if 2n elements in the form [x1,x2,x3,...xn,y1,y2,y3,...yn]
        // return an array in form [x1,y1,x2,y2,x3,y3,xn,yn]
        //input 2,2,1,3,4,7
        //output 2,3,5,4,1,7

        public void RunSolution()
        {
            var result = GETShuffleTheArray(new int[] { 2, 2, 1, 3, 4, 7 });
        }

        private int[] GETShuffleTheArray(int[] arr)
        {
            int mid = arr.Length / 2;
            var newArr = new List<int>();
            for (int i = 0; i < mid; i++)
            {
                newArr.Add(arr[i]);
                newArr.Add(arr[i + mid]);
            }
            return newArr.ToArray();    
        }
    }
}
