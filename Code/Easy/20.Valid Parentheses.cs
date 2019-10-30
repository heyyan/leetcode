using System;
using System.Collections;

namespace leetcode
{
    public class ValidParentheses
    {
        public void RunIsValidTest()
        {
            
            Console.WriteLine($"){{ is false => { IsValid("){") }" );
            Console.WriteLine($"( is false => { IsValid("(") }" );
            Console.WriteLine($") is false => { IsValid(")") }" );
            Console.WriteLine($"() is true => { IsValid("()") }" );
            Console.WriteLine($"{{([])}} is true => { IsValid("{([])}") }" );
            Console.WriteLine($"()[]{{}} is true => { IsValid("()[]{}") }" );
            Console.WriteLine($"(] is false => { IsValid("(]") }" );
            Console.WriteLine($"([)] is false => { IsValid("([)]") }" );
        }
        public bool IsValid(string s)
        {
            if(s.Length % 2 != 0)
            return false;

            Stack stack = new Stack();
            foreach (char c in s)
            {
                switch (c)
                {
                    case '(':
                    case '{':
                    case '[':
                        stack.Push(c);
                        break;
                    case ')':
                    case '}':
                    case ']':
                        if(stack.Count == 0 )return false;
                        var current = (char)stack.Peek();
                        if ((current == '(' && c == ')') || (current == '{' && c == '}') || (current == '[' && c == ']'))
                        {
                            stack.Pop();
                        }
                        else
                        {
                            stack.Push(c);
                        }
                        break;
                }
            }

            return stack.Count == 0;
        }
    }
}