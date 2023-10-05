using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace leetcode.AlgoExpert.Medium
{
    public class MergeOverLappingIntervals
    {
        //input [[1,2],[3,5],[4,7],[6,8],[9,10]]
        // output [[1,2],[3,8],[9,10]]
        public void RunSolution()
        {
            //var r = mergeOverLappingIntervals2(new int[,] { { 1, 2 }, { 3, 5 }, { 4, 7 }, { 6, 8 }, { 9, 10 } });
            var r = mergeOverLappingIntervals3(new List<List<int>> {
                new List<int> { 1, 2 },
                new List<int> { 3, 5 },
                new List<int> { 4, 7 },
                new List<int> { 6, 8 },
                new List<int> { 9, 10 } });
        }

        private object mergeOverLappingIntervals(int[,] arrays)
        {
            List<List<int>> list = new();

            int joint = -1;
            for (int i = 0; i < arrays.GetLength(0) - 1; i++)
            {
                int firstEnd = arrays[i, arrays.GetLength(1) - 1];
                int nextStart = arrays[i + 1, 0];
                if (firstEnd >= nextStart)
                {
                    if (joint == -1)
                    {
                        joint = i;
                    }
                }
                else
                {
                    if (joint != -1)
                    {
                        list.Add(new List<int> { arrays[joint, 0], arrays[i, arrays.GetLength(1) - 1] });
                        joint = -1;
                    }
                    else
                    {
                        list.Add(new List<int> { arrays[i, 0], arrays[i, arrays.GetLength(1) - 1] });
                    }

                }
            }
            return null;
        }

        private object mergeOverLappingIntervals2(int[,] arrays)
        {
            // sort the array 
            //Array.Sort(arrays, (a, b) => { return a[0] - b[0]; });
            //Array.Sort(arrays, (a, b) => { return a[0] - b[0]; });
            List<List<int>> intervals = new();

            for (int i = 0; i < arrays.GetLength(0); i++)
            {
                int nextStart = arrays[i, 0];
                if (intervals.Count <= 0)
                {
                    intervals.Add(new List<int> { arrays[i, 0], arrays[i, arrays.GetLength(1) - 1] });
                    continue;
                }

                int firstEnd = 0;
                if (intervals.Count > 0)
                {
                    var count = intervals[intervals.Count - 1].Count - 1;
                    firstEnd = intervals[intervals.Count - 1][count];
                }
                else
                {
                    firstEnd = arrays[i, arrays.GetLength(1) - 1];
                }


                if (firstEnd < nextStart)
                {
                    intervals.Add(new List<int> { arrays[i, 0], arrays[i, arrays.GetLength(1) - 1] });
                }
                else
                {
                    // update the value of the 
                    var count = intervals[intervals.Count - 1].Count - 1;
                    intervals[intervals.Count - 1][count] = Math.Max(intervals[intervals.Count - 1][count], arrays[i, arrays.GetLength(1) - 1]);
                }
            }
            return intervals;
        }

        private object mergeOverLappingIntervals3(List<List<int>> lists)
        {
            lists.Sort((x, y) => x[0].CompareTo(y[0]));
            List<List<int>> mergedIntervasl = new();
            List<int> currentInteval = new();
            currentInteval = lists[0];
            mergedIntervasl.Add(currentInteval);

            for (int i = 1; i < lists.Count; i++)
            {
                int currentIntervalEnd = currentInteval[currentInteval.Count - 1];
                int nextIntervalStart = lists[i][0];
                int nextIntervalEnd = lists[i][1];

                if(currentIntervalEnd >= nextIntervalStart)
                {
                    currentInteval[1] = Math.Max(currentIntervalEnd, nextIntervalEnd);
                }else
                {
                    currentInteval = lists[i];
                    mergedIntervasl.Add(currentInteval);
                }
            }

            return mergedIntervasl;
        }
    }
}
