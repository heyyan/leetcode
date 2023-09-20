using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.Blind_75_LeetCode
{
    public class LongestCommonSubsequence
    {
        // Given two strings text1 and text2, retunr the length of thir longest common subsequence.
        // A subsequence of a string is a new string generated from the original string with some characters (can be none)
        // delete without changing the relative order of the remaining chacters.(eg, "ace" is a subsequence of "abcde"
        // while "aec" is not). A Common subsequence of two string is a subsequence that is common of both strings
        // it there is no common subsequence return 0
        // input tex1= "abcde" text2 = "ace"
        // output 3

        public void RunSolution()
        {
            var result = GetLongestCommonSubsequence("abcde", "ace");
        }

        private object GetLongestCommonSubsequence(string text1, string text2)
        {
            int[,] dp = new int[text1.Length + 1, text2.Length + 1];

            for (int i = text1.Length-1; i >= 0; i--)
            {
                for (int j = text2.Length-1; j >= 0; j--)
                {
                    if (text1[i] == text2[j])
                    {
                        dp[i, j] = 1 + dp[i + 1, j + 1];
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i, j + 1], dp[i + 1, j]);
                    }

                }
            }
            return dp[0, 0];
        }

        public int LongestCommonSubsequence1(string text1, string text2)
        {
            var m = text1.Length;
            var n = text2.Length;
            var dp = new int[m + 1][];
            for (int index = 0; index < dp.Length; ++index)
            {
                dp[index] = new int[n + 1];
            }

            for (int index = 1; index <= m; ++index)
            {
                var letter1 = text1[index - 1];
                for (int search = 1; search <= n; ++search)
                {
                    var letter2 = text2[search - 1];
                    if (letter1 == letter2)
                    {
                        dp[index][search] = dp[index - 1][search - 1] + 1;
                    }
                    else
                    {
                        dp[index][search] = Math.Max(dp[index - 1][search], dp[index][search - 1]);
                    }
                }
            }

            return dp[m][n];
        }
    }
}
