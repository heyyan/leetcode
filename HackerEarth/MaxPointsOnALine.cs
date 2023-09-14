using System.Collections.Generic;

namespace leetcode.HackerEarth
{
    public class MaxPointsOnALine
    {
        // max points on a line
        // you are given an array arr in which each element conrresponds to a 2D coordinate, i.e arr[i] = [xi,yi]
        // what is the maximum number of points that lie on the same line?

        public void RunSolution()
        {
            int[][] input = {  new int[] {0,0},
                               new int[] {1,1},
                               new int[] {2,2},
                               new int[] {7,5},
                               new int[] {0,4}
                            };
            var result = GetMaxPointsOnALine(input);
        }

        private int GetMaxPointsOnALine(int[][] arr)
        {
            Dictionary<float, int> dict = new Dictionary<float, int>();
            int max = 0;
            for (int i = 0; i < arr.Length - max - 1; i++)
            {
                int i_max = 0;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    float slope = 0;
                    if (arr[j][0] - arr[i][0] <= 0)
                    {
                        slope = 10000001;
                    }
                    else
                    {
                        slope = (arr[j][1] - arr[i][1]) / (arr[j][0] - arr[i][0]);
                    }

                    if (dict.ContainsKey(slope))
                    {
                        dict[slope]++;
                    }
                    else
                    {
                        dict.Add(slope, 1);
                    }
                    if (i_max < dict[slope])
                    {
                        i_max = dict[slope];
                    }
                }
                dict.Clear();
                if (max < i_max)
                {
                    max = i_max;
                }
            }
            return max + 1;
        }
    }
}
