using System;

namespace leetcode
{
    public class RegularExpressionMatching
    {
        // Given an input string (s) and a pattern (p), implement regular expression matching with support for '.' and '*'
        //'.' Match and single character
        //'*' Match zero or more of the preceding element
        public void RunIsMatchTest()
        {
            Console.WriteLine($"s = 'aa', p = 'a' should be false => { IsMatch("aa", "a")}");
            Console.WriteLine($"s = 'aa', p = 'a*' should be true => { IsMatch("aa", "a*")}");
            Console.WriteLine($"s = 'aab', p = 'c*a*b' should be true => { IsMatch("aab", "c*a*b")}");
            Console.WriteLine($"s = 'mississippi', p = 'mis*is*p*.' should be false => { IsMatch("mississippi", "mis*is*p*.")}");
        }
        public bool IsMatch(string s, string p)
        {
            foreach (char c in p)
            {
                

            }
            return false;
        }
    }
}