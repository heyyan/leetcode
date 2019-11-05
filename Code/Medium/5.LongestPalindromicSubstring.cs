using System;

namespace leetcode
{
    public class LongestPalindromicSubstring
    {
        private int lo, maxLen;
        public void RunLongestPalindromeTest()
        {

            Console.WriteLine($"babad ans  bab or aba => { LongestPalindrome("babad")}");
            Console.WriteLine($"cbbd ans bb => { LongestPalindrome("cbbd")}");

        }
        public string LongestPalindrome(string s)
        {
           if (s.Length == 0) return "";
            if (s.Length == 1) return s;

            int min_start = 0, max_len = 1;

            for (int i = 0; i < s.Length; i++)
            {
                if (s.Length - 1 <= max_len / 2) break;
                int j = i, k = i;
                while (k < s.Length - 1 && s[k + 1] == s[k])
                {
                    ++k; // skip duplicate characters
                }
                i = k + 1;
                while (k < s.Length - 1 && j > 0 && s[k + 1] == s[j - 1])
                {
                    ++k; --j; // expand
                }
                int new_len = k - j + 1;
                if (new_len > max_len)
                {
                    min_start = j;
                    max_len = new_len;
                }

            }
            return s.Substring(min_start, max_len);
        }
       
    }
}
