using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.HackerEarth
{
    internal class DestroyThosePairs
    {
        // you are given a string str of lower case letters. if thes string has any adjacents pairs of the same characters, that
        // pair must be removed. the new strign must agian be checked for adjacent paris. repeat these steps until no pair remains
        // input abcddce
        // output abe
        public void RunSolution()
        {
            // var result = GetVerifyTheAlienDictionary(new List<string> { "HACKER", "EARTHS", "CODEEXPLAINED" }, "HECABDFGIJKLMNOPQRSTUVWXYZ");
            //var result = GETDestroyThosePairs("abcddce");
            var result = GETDestroyThosePairsStack("abcddcee");

        }
        private object GETDestroyThosePairs(string str)
        {
            var list = str.ToList();
            int start = 0;
            int end = 1;
            while (end < list.Count)
            {
                if (list[start] == list[end])
                {
                    // remove character 
                    list.RemoveAt(start);
                    list.RemoveAt(start);
                    if (start != 0)
                    {
                        start--;
                        end--;
                    }
                }
                else
                {
                    start++;
                    end++;
                }
            }

            return list.ToString();
        }
        private object GETDestroyThosePairsStack(string str)
        {
            var stack = new Stack<char>();
            stack.Push(str[0]);
            for (int i = 1; i < str.Length; i++)
            {
                if(stack.Peek() == str[i])
                {
                    stack.Pop();
                }
                else
                {
                    stack.Push(str[i]);
                }
            }
            return stack.ToString();
        }

    }
}
