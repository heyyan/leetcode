using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.Blind_75_LeetCode
{
    public class ContainsDuplicate
    {
        // given an integer array nums, return true if any value appears at least twice in the array, and return false if 
        // evey element is distinct

        public void RunSolution()
        {
            var result = GetContainsDuplicate(new int[] { 7, 1, 5, 3, 6, 4,1 });
        }

        private bool GetContainsDuplicate(int[] arr)
        {
            Dictionary<int,int> map = new Dictionary<int,int>();
            foreach (int i in arr)
            {
                if (map.ContainsKey(i))
                { return true; }
                else
                {
                    map.Add(i, 1);
                }
            }
            return false;  
        }
    }
}
