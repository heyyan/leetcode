using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Medium
{
    public class BalancedBrackers
    {
        public void RunSolution()
        {
            var result = balancedBrackers("(([]()()){})");
            //var result = GetBalancedBrackers("(([]()()){})");
            //var result = GetBalancedBrackers("[(])");
        }

        private bool balancedBrackers(string brakets)
        {
            string openingBrackets = "([{";
            string closingBrackets = ")]}";
            var matchingBrackets = new Dictionary<char, char>();
            matchingBrackets.Add(')', '(');
            matchingBrackets.Add(']', '[');
            matchingBrackets.Add('}', '{');
            Stack<char> stack = new Stack<char>();
            foreach (char c in brakets)
            {
                if (openingBrackets.Contains(c))
                {
                    stack.Push(c);
                }
                else if (closingBrackets.Contains(c))
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }
                    if (stack.Peek() == matchingBrackets[c])
                    {
                        stack.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return stack.Count == 0;
        }
        private bool GetBalancedBrackers(string brakets)
        {
            var map = new Dictionary<string, string>();
            map.Add("(", ")");
            map.Add("[", "]");
            map.Add("{", "}");

            Stack<string> stack = new Stack<string>();
            stack.Push(brakets[0].ToString());
            for (int i = 1; i < brakets.Length; i++)
            {
                var stackTop = stack.Peek();
                var currentStr = brakets[i];
                if (map.ContainsKey(stackTop) && map[stackTop] == currentStr.ToString())
                {
                    stack.Pop();
                }
                else
                {
                    stack.Push($"{currentStr}");
                }
            }

            return stack.Count == 0;
        }
    }
}
