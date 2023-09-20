using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static leetcode.Blind_75_LeetCode.HouseRobberIII;

namespace leetcode.Blind_75_LeetCode
{
    public class DecodeWays
    {
        // A message containing letters from A-Z can be encoded into number using the following mapping
        // 'A' -> 1
        // 'B' -> 2
        // ...
        // 'Z' -> 26
        // to decode an encoded message, all digits must be grouped then mapeped back into letters using the 
        // reverse of the mapping above (there may be mulitple ways). For example "1106 can be mapped inot
        // "AAJF" with the grouping (1 1 10 6)
        // "KJF" with the grouping (11 10 6)
        // Note that the grouping (1 11 06) is invalid because "06" cannot be mapped into 'F' since "6" is 
        // different from "06"
        // Given a string s containing only digits, return the number of ways to decode it
        // the answer is guaranteed to fit in a 32-bit integer
        // input s="12"
        // output 2
        // Explanation "12" could be decoded as "AB" (1 2) or "L" (12)
        public void RunSolution()
        {
            var result = GetDecodeWays("226");
        }

        private int GetDecodeWays(string s)
        {
            Dictionary<int, int> dp = new Dictionary<int, int>();
            dp.Add(26, 1);

            int Dfs(int i)
            {
                if (i == s.Length || i == s.Length - 1)
                {
                    return 1;
                }
                if (dp.ContainsKey(i))
                {
                    return dp[i];
                }
                if (s[i] == '0')
                {
                    return 0;
                }

                var res = Dfs(i + 1);
                if (i + 1 < s.Length)
                {
                    if (s[i] == '1' || (s[i] == '2' && "0123456".Contains(s[i + 1])))
                    {
                        int va = Dfs(i + 2);
                        res += va;
                    }
                }
                if (!dp.ContainsKey(i))
                {
                    dp.Add(i, res);
                }
                else
                {
                    dp[i] = res;
                }

                return res;
            }
            return Dfs(0);
        }

        public int numDecodings(String s)
        {
            if (s[0] == '0') return 0;
            int n = s.Length;

            int[] dp = new int[n + 1];
            dp[n] = 1;

            for (int i = n - 1; i >= 0; i--)
            {
                if (s[i] == '0')
                {
                    dp[i] = 0;
                }
                else
                {
                    dp[i] = dp[i + 1];
                    if (i < n - 1 && (s[i] == '1' || s[i] == '2' && s[i + 1] <= '6'))
                    {
                        dp[i] += dp[i + 2];
                    }
                }
            }

            return dp[0];
        }


        public int numDecodings2(String s)
        {
            if (s == null || s.Length == 0) return 0;

            int[] dp = new int[s.Length + 1];
            dp[0] = 1;
            dp[1] = s[0] == '0' ? 0 : 1;
            for (int i = 2; i < dp.Length; i++)
            {
                // one digit
                if (s[i - 1] != '0')
                {
                    dp[i] += dp[i - 1];
                }
                // two digit
                int start = i - 2;
                int end = i;
                int twoDigit = int.Parse(s.Substring(start, end - start));
                if (twoDigit >= 10 && twoDigit <= 26)
                {
                    dp[i] += dp[i - 2];
                }
            }

            return dp[s.Length];
        }
    }
}
