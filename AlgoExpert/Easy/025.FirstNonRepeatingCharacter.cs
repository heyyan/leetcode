using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Easy
{
    public class FirstNonRepeatingCharacter
    {
        //input "abcdcaf" 
        // output c
        public void RunSolution()
        {
            var r = GetFirstNonRepeatingCharacter("abcdcaf");
        }

        private int GetFirstNonRepeatingCharacter(string str)
        {
            SortedDictionary<char, int> dict = new();
            for(int i = 0; i < str.Length;i++)
            {
                if (dict.ContainsKey(str[i]))
                {
                    dict.Remove(str[i]);
                }
                else
                {
                    dict.Add(str[i],i);
                }
            }
            if(dict.Count > 0)
            {
                return dict.First().Value;
            }
            return -1;
        }
    }
}
