using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Easy
{
    public class NthFibonacci
    {
        public void RunSolution()
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            dic.Add(1, 0);
            dic.Add(2, 1);
            //var r = GetNthFibonacci(10);
            //var r = GetNthFibonacciMem(10, dic);
            var r = GetNthFibonacciArry(10);
        }

        private int GetNthFibonacci(int n)
        {
            if (n == 1) return 0;
            if (n == 2) return 1;
            return GetNthFibonacci(n - 1) + GetNthFibonacci(n - 2);
        }

        private int GetNthFibonacciMem(int n, Dictionary<int,int> dic)
        {
            if (n == 1) return 0;
            if (n == 2) return 1;
            if(dic.ContainsKey(n)) return dic[n];
            int result  = GetNthFibonacciMem(n - 1, dic) + GetNthFibonacciMem(n - 2, dic);
            if(!dic.ContainsKey((int)n)) { dic.Add(n, result); }
            return result;
        }

        private int GetNthFibonacciArry(int n)
        {
            if (n == 1) return 0;
            if (n == 2) return 1;

            int[] arr = new int[] {0,1};
            int result = 0;
            for (int i = 2; i < n; i++)
            {
                result = arr[0] + arr[1];
                arr[0] = arr[1];
                arr[1] = result;
            }
            return result;
        }
    }
}
