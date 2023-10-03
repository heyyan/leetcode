using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Easy
{
    public class PalindromeCheck
    {
        public void RunSolution()
        {
            var r = GetPalindromeCheck("abcdcba", 0);
        }

        private object GetPalindromeCheck(string str)
        {
            Stack<char> stack = new Stack<char>();
            int mid = (str.Length - 1) / 2;
            int strs = mid + 1;
            if (str.Length % 2 != 0)
            {
                mid -= 1;
            }
            for (int i = 0; i <= mid; i++)
            {
                stack.Push(str[i]);
            }
            for (int i = strs; i < str.Length; i++)
            {
                var c = stack.Pop();
                if (c != str[i])
                {
                    return false;
                }
            }

            return stack.Count == 0;
        }

        private bool reverseCheck(string str)
        {
            var newStr = "";
            foreach (var c in str)
            {
                newStr += c;
            }
            return str == newStr;
        }

        private bool Pointers(string str)
        {
            int start = 0;
            int end = str.Length - 1;
            while (start <= end)
            {
                if (str[start] != str[end])
                {
                    return false;
                }
                start++;
                end--;
            }
            return true;
        }
        private bool GetPalindromeCheck(string str, int i = 0)
        {
            int j = str.Length - 1 - i;
            bool result = false;
            if (i >= j)
            {
                return true;
            }
            else if (str[i] == str[j])
            {
                result = GetPalindromeCheck(str, i + 1);
            }
            return result;
        }


        private bool GetPalindromeCheck2(string str, int i = 0)
        {
            int j = str.Length - 1 - i;
            if (i >= j)
            {
                return true;
            }
            else if (str[i] != str[j])
            {
                return false;
            }
            return GetPalindromeCheck2(str, i + 1); ;
        }
    }
}
