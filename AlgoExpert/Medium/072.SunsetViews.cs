using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Medium
{
    public class SunsetViews
    {
        // input [3,5,4,4,3,1,3,2]
        // output [1, 3, 6, 7]
        public void RunSolution()
        {
            var result = sunsetViews2(new int[] { 3, 5, 4, 4, 3, 1, 3, 2 }, "WEST");
        }


        private int[] sunsetViews2(int[] buildings, string direction)
        {
            Stack<int> candidateBuildings = new Stack<int>();

            int startIdx = direction == "EAST" ? 0 : buildings.Length - 1;
            int step = direction == "EAST" ? 1 : -1;

            int idx = startIdx;

            while (idx >= 0 && idx < buildings.Length)
            {
                int buildingHeight = buildings[idx];
                
                while( candidateBuildings.Count > 0  && buildings[candidateBuildings.Peek()] <= buildingHeight)
                {
                    candidateBuildings.Pop();
                }
                candidateBuildings.Push(idx);

                idx += step;
            }
            var result = candidateBuildings.ToArray();

            Array.Sort(result);
            return result;
        }
        private int[] sunsetViews(int[] buildings, string direction)
        {
            List<int> buildingWuthSunSetView = new List<int>();
            int startIdx = direction == "WEST" ? 0 : buildings.Length - 1;
            int step = direction == "WEST" ? 1 : -1;

            int idx = startIdx;
            int runningMaxHeight = 0;

            while (idx >= 0 && idx < buildings.Length)
            {
                int buildingHeight = buildings[idx];
                if (buildingHeight > runningMaxHeight)
                {
                    buildingWuthSunSetView.Add(idx);
                }
                runningMaxHeight = Math.Max(runningMaxHeight, buildingHeight);
                idx += step;
            }

            if (direction == "EAST")
            {
                buildingWuthSunSetView.Reverse();
                return buildingWuthSunSetView.ToArray();
            }
            return buildingWuthSunSetView.ToArray();
        }

        private int[] GetSunsetViews(int[] array, string direction)
        {
            if (direction == "East")
            {
                List<int> results = new List<int>
                {
                    array.Length - 1
                };
                int currentMax = array[array.Length - 1];
                for (int i = array.Length - 1; i >= 0; i--)
                {
                    if (array[i] > currentMax)
                    {
                        currentMax = array[i];
                        results.Add(i);
                    }
                }
                results.Reverse();
                return results.ToArray();
            }
            else
            {
                List<int> results = new List<int>
                {
                   0
                };
                int currentMax = array[0];
                for (int i = 1; i < array.Length; i++)
                {
                    if (array[i] > currentMax)
                    {
                        currentMax = array[i];
                        results.Add(i);
                    }
                }
                //results.Sort();
                return results.ToArray();
            }
        }
    }
}
