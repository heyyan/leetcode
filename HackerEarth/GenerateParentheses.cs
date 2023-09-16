using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.HackerEarth
{
    public class GenerateParentheses
    {
        //Generate Parentheses 
        // you are given an integer n. Generate all possible balanced parentheses containing n opening and closing parentheses and return a sorted array
        // a string of parentheses is considered well balanced if there are never more closing than opening parenthese at any point in the string
        // A sorted array of all possible parenthese containg n opening and closing parentheses
        // input 3
        //output
        // ((()))
        // (()())
        // (())()
        // ()(())
        // ()()()
        public void RunSolution()
        {
            var res = new List<string>();
            var result = GetGenerateParentheses(res, 3);
        }

        private List<string> GetGenerateParentheses(List<string> res, int n)
        {
            AllPossiablePar(res, n, 0, 0, "");
            return res;
        }

        private void AllPossiablePar(List<string> res, int n, int open, int close, string str)
        {
            if (open == close && close == n)
            {
                res.Add(str);
                return;
            }
            if (open < n)
            {
                AllPossiablePar(res, n, open + 1, close, str + "(");
            }
            if (close < open)
            {
                AllPossiablePar(res, n, open, close + 1, str + ")");
            }
        }
    }
}
