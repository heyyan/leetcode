using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.HackerEarth
{
    public class ThatIsPrefection
    {
        public void RunSolution()
        {
            var r = GetThatIsPrefection(28);
        }

        private object GetThatIsPrefection(int n)
        {
            List<int> list = new List<int>();
            for (int i = 1; i < n; i++)
            {
                if (n % i == 0)
                {
                    list.Add(i);
                }
            }
            return list.Sum() == n;
        }

        public int func(int k)
        {
            k = k + 20;
            return k;
        }
        public Single func(float t)
        {
            t = t + 3.4F;
            return t;
        }

        //static long countSubarray(int A[], int N)
        //{ 
        //    int count = 0; 
        //    int last = -1; int K = 0; 
        //    for (int i = 0; i < N; i++) 
        //    { if (A[i] % 2 == 0) 
        //        { K = (i - last - 1); count += (K * (K + 1) / 2); last = i; } } 
        //    K = (N - last - 1); count += (K * (K + 1) / 2); return count; }
    }
}
