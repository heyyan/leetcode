using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Medium
{
    public class NextGraterElement
    {
        // input  [2,5,-3,-4,6,7,2]
        // output [5,6,6,6,7,-1,5]
        public void RunSolution()
        {
            var result = nextGraterElement2(new int[] { 2, 5, -3, -4, 6, 7, 2 });
        }

        private int[] nextGraterElement(int[] array)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < array.Length; i++)
            {
                result.Add(-1);
            }
            Stack<int> stack = new Stack<int>();

            for (int idx = 0; idx < array.Length * 2; idx++)
            {
                int ciruclarIdx = idx % array.Length;

                while (stack.Count > 0 && array[stack.Peek()] < array[ciruclarIdx])
                {
                    int top = stack.Pop();
                    result[top] = array[ciruclarIdx];
                }
                stack.Push(ciruclarIdx);
            }
            return result.ToArray();

        }

        private int[] nextGraterElement2(int[] array)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < array.Length; i++)
            {
                result.Add(-1);
            }
            Stack<int> stack = new Stack<int>();

            for (int idx = (array.Length * 2) - 1; idx >= 0; idx--)
            {
                int ciruclarIdx = idx % array.Length;

                while (stack.Count > 0)
                {
                    if (stack.Peek() <= array[ciruclarIdx])
                    {
                        stack.Pop();
                    }
                    else
                    {
                        result[ciruclarIdx] = stack.Peek();
                        break;
                    }
                }
                stack.Push(array[ciruclarIdx]);
            }
            return result.ToArray();

        }
        private int[] GetNextGraterElement(int[] array)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < array.Length; i++)
            {
                int currentVal = array[i];
                bool found = false;
                for (int j = i + 1; j < array.Length + i; j++)
                {
                    var x = j % array.Length;

                    if (currentVal < array[x])
                    {
                        result.Add(array[x]);
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    result.Add(-1);
                }
            }
            return result.ToArray();
        }

        private int[] GetNextGraterElement2(int[] array)
        {
            List<int> result = new List<int>();

            int start = 0;
            int end = 1;
            while (start != array.Length)
            {
                if (array[start] < array[end])
                {
                    result.Add(array[end]);
                    start++;
                    if (start == end)
                    {
                        end++;
                    }
                }
                else
                {
                    end++;
                }

                if (start == end)
                {
                    result.Add(-1);
                    start++;
                    end = start + 1;
                }

                end = end % array.Length;
            }
            return result.ToArray();
        }
    }
}
