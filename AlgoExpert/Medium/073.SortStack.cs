using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Medium
{
    public class SortStack
    {
        // input stack [-5,2,-2,4,3,1]
        // output [-5,-2,1,2,3,4]
        public void RunSolution()
        {
            var stack = new Stack<int>();
            stack.Push(-5);
            stack.Push(2);
            stack.Push(-2);
            stack.Push(4);
            stack.Push(3);
            stack.Push(1);

            var result = GetSortStack(stack);
        }

        private Stack<int> GetSortStack(Stack<int> stack)
        {
            if (stack.Count == 0)
            {
                return stack;
            }
            var top = stack.Pop();
            GetSortStack(stack);
            insert(stack, top);
            return stack;
        }


        private void insert(Stack<int> stack, int lastTop)
        {
            if (stack.Count == 0 || stack.Peek() <= lastTop)
            {
                stack.Push(lastTop);
                return;
            }
            var top = stack.Pop();
            insert(stack, lastTop);
            stack.Push(top);

        }
    }
}
