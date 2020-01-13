using System;

namespace leetcode
{

    /*
        Given n non-negative integers a1, a2, ..., an , where each represents a point at coordinate (i, ai). 
        n vertical lines are drawn such that the two endpoints of line i is at (i, ai) and (i, 0). 
        Find two lines, which together with x-axis forms a container, such that the container contains the most water.
        Note: You may not slant the container and n is at least 2.
    */
    public class ContainerWithMostWater
    {

         public void MaxAreaTest()
        {

            Console.WriteLine($"Container With Most Water for [1,8,6,2,5,4,8,3,7] should be 49   => { MaxArea( new int[] { 1,8,6,2,5,4,8,3,7}) }");
           
        }
        public int MaxArea(int[] height)
        {
            int max = 0;
            for (int i = 0; i < height.Length; i++)
            {
                for (int j = 0; j < height.Length; j++)
                {
                    int newMax = Math.Min(height[i], height[j]) * (j - i);
                    max = Math.Max(max, newMax);
                }
            }
            return max;
        }
    }
}