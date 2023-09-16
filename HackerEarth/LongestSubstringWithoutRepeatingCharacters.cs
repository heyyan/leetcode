using System.Collections.Generic;

namespace leetcode.HackerEarth
{
    public class LongestSubstringWithoutRepeatingCharacters
    {
        // you are given a string str. Find the length of the longest possible substring in str without ANY repeating character
        //input abcdcde
        //output 4
        public void RunSolution()
        {
            var result = NoDups("abcbcde");
        }

        private int GetLongestSubstringWithoutRepeatingCharacters(string str)
        {
            int lenght = 0;
            HashSet<char> chars = new HashSet<char>();
            foreach (char c in str)
            {
                if (chars.Contains(c))
                {
                    if (chars.Count > lenght)
                    {
                        lenght = chars.Count;
                    }
                    chars.Clear();
                    chars.Add(c);
                }
                else
                {
                    chars.Add(c);
                }
            }
            if (chars.Count > lenght)
            {
                lenght = chars.Count;
            }
            return lenght;
        }

        private int NoDups(string str)
        {
            Dictionary<char, int> hm = new Dictionary<char, int>();
            int start = 0;
            int end = 0;
            int len = 0;
            int max = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (hm.ContainsKey(str[i]) && hm[str[i]] >= start)
                {
                    start = hm[str[i]] + 1;
                }
                else
                {
                    hm.Add(str[i], i);

                }

                end = i;
                len = end - start;
                if (max < len)
                {
                    max = len;
                }
            }
            max += 1;
            return max;
        }
    }
}
