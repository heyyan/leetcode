using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.Blind_75_LeetCode
{
    public class WordBreakProblem
    {
        // Given a string s and a dictionary of string wordDict return true if s canbe segmented intoa space-separated
        // sequence of one or more doctionary words
        // Node that the same word in the dictionay may be reused muptiple time in the segementation
        // input s = "leetcode", wordDict = ["leet","code"]
        public void RunSolution()
        {
            var result = GetWordBreakProblem("leetcode", new string[] { "leet", "code" });
        }

        private bool GetWordBreakProblem(string s, string[] wordDict)
        {
            bool[] dp = new bool[s.Length + 1];
            dp[s.Length] = true;

            for (int i = s.Length - 1; i >= 0; i--)
            {
                foreach (string word in wordDict)
                {

                    if (i + word.Length <= s.Length && s.Substring(i, word.Length) == word)
                    {
                        var st = s.Substring(i, word.Length);
                        dp[i] = dp[i + word.Length];
                    }
                    if (dp[i] == true)
                    {
                        break;
                    }
                }
            }
            return dp[0];
        }
    }
}
