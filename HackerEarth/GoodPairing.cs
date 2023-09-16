using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.HackerEarth
{
    public class GoodPairing
    {
        // you are given an array arr in which a good pair is defined as a pair of numbers in the array which satisfy the following
        // conditions
        // arr[i] == arr[j] (the two numbers must be equal)
        // i < j
        // input 1 2 3 1 1 3
        // output 4
        public void RunSolution()
        {
            int result = GetGoodPairs2(new int[] { 1, 2, 3, 1, 1, 3 });

        }
        private int GetGoodPairing(int[] arr)
        {
            Dictionary<int, string> map = new Dictionary<int, string>();
            List<string> pairList = new List<string>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (!map.ContainsKey(arr[i]))
                {
                    map.Add(arr[i], i.ToString());
                }
                else
                {
                    map[arr[i]] = map[arr[i]] + "," + i.ToString();
                    var pair = map[arr[i]].Trim().Split(',');
                    foreach (var item in pair)
                    {
                        if (!pairList.Contains(item + "," + i) && int.Parse(item) < i)
                            pairList.Add(item + "," + i);
                    }
                    //map[arr[i]] = map[arr[i]] + i.ToString() + ",";
                }

            }
            return pairList.Count;
        }

        private int GetGoodPairs2(int[] arr)
        {
            int result = 0;
            Dictionary<int, int> hm = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (!hm.ContainsKey(arr[i]))
                {
                    hm.Add(arr[i], 1);
                }
                else
                {
                    hm[arr[i]] = hm[arr[i]] + 1;
                }
            }

            foreach (var element in hm)
            {
                int freq = element.Value;
                result = result + (freq * (freq - 1) / 2);
            }
            return result;
        }
    }
}
