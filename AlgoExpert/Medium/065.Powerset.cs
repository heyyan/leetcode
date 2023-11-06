using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace leetcode.AlgoExpert.Medium
{
    public class PowerSet
    {
        //input P([1,2,3])
        //output [[],[1],[2],[3],[1,2],[1,3],[2,3],[1,2,3]]
        public void RunSolution()
        {
            var values = GetPowerSetRecursive(new int[] { 1, 2, 3 });
        }

        private List<List<int>> GetPowerSetInterative(int[] arrays)
        {
            List<List<int>> result = new();
            result.Add(new List<int>());
            foreach (var array in arrays)
            {
                List<List<int>> newresult = new();
                for (int i = 0; i < result.Count; i++)
                {
                    var newList = new List<int>();
                    newList.AddRange(result[i]);
                    newList.Add(array);
                    newresult.Add(newList);
                }
                result.AddRange(newresult);
            }
            return result;
        }


        private List<List<int>> GetPowerSetInterative2(int[] arrays)
        {
            List<List<int>> result = new();
            result.Add(new List<int>());
            foreach (var array in arrays)
            {
                foreach (var i in Enumerable.Range(0, result.Count))
                {
                    var newList = new List<int>();
                    newList.AddRange(result[i]);
                    newList.Add(array);
                    result.Add(newList);
                }
            }
            return result;
        }

        private List<List<int>> GetPowerSetRecursive(int[] arrays, int? idx = null)
        {
            if (idx == null)
            {
                idx = arrays.Length - 1;
            }
            else if (idx < 0)
            {
                return new List<List<int>> { new List<int>() };
            }
            var ele = arrays[idx.Value];
            List<List<int>> subSets = GetPowerSetRecursive(arrays, idx - 1);

            int sunsetCount = subSets.Count;
            for (int i = 0;i<sunsetCount; i++)
            {
                List<int> currentSubSet = new List<int>(subSets[i]);
                currentSubSet.Add(ele);
                subSets.Add(currentSubSet);
            }

            return subSets;
        }
    }
}
