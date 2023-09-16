using System.Collections.Generic;
using System.Linq;

namespace leetcode.HackerEarth
{
    public class GoldenLetters
    {
        //you are given a string key that contains a list of golden letters. you are also given another string str. find out how many
        // characters in str are golden letter
        // input  keys:wxYZ  str: lmnoWwwxyZ
        // input 4

        public void RunSolution()
        {
            var result = GetGoldenLetters("wxYZ", "lmnoWwwxyZ");
        }

        private int GetGoldenLetters(string keys, string str)
        {
            List<char> list = keys.ToList();
            int count = 0;
            foreach (char c in str)
            {
                if(list.Contains(c))
                {
                    count++;
                }
            }
            return count;
        }
    }
}
