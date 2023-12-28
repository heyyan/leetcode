using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Medium
{
    public class GroupingAnagrams
    {
        // input  [yo,act,flop,tac,cat,yo,olfp]
        // output xyzzyx
        public void RunSolution()
        {
            var result = groupAnagrams(new string[] { "yo", "act", "flop", "tac", "cat", "oy", "olfp" });
        }


        public List<List<string>> groupAnagrams(string[] words)
        {
            if (words.Length == 0)
            {
                return new List<List<string>>();
            }

            string[] sortedWords = words.Select(w => new string(w.OrderBy(c => c).ToArray())).ToArray();
            int[] indices = Enumerable.Range(0, words.Length).ToArray();
            Array.Sort(indices, (x, y) => String.Compare(sortedWords[x], sortedWords[y]));

            List<List<string>> result = new List<List<string>>();
            List<string> currentAnagramsGroup = new List<string>();
            string currentAnagram = sortedWords[indices[0]];

            foreach (int index in indices)
            {
                string word = words[index];
                string sortedWord = sortedWords[index];

                if (sortedWord == currentAnagram)
                {
                    currentAnagramsGroup.Add(word);
                    continue;
                }

                result.Add(currentAnagramsGroup);
                currentAnagramsGroup = new List<string> { word };
                currentAnagram = sortedWord;
            }

            result.Add(currentAnagramsGroup);

            return result;
        }

        private object GetGroupingAnagrams(string[] strings)
        {
            Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();
            foreach (string s in strings)
            {
                var key = string.Join("", s.OrderBy(x => x).ToArray());
                if (map.ContainsKey(key))
                {
                    map[key].Add(s);
                }
                else
                {
                    map[key] = new List<string>() { s };
                }
            }
            return map.Values.ToList().OrderBy(x=>x.Count()).ToList();
        }
    }
}
