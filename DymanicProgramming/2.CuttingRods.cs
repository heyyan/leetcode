using System;
using System.Collections.Generic;

namespace leetcode
{
    public class CuttingRods
    {
        //Given a rod of lenght n and prices p[i] for i=1, ... , n, where p[i] is the price of a rod of lenght i.
        //Find the maximimum total revenue you can mak by cutting and selling the rod (Assume no cost for cuttinr the rod).

        List<int> prices = new List<int> { 1, 5, 8, 9, 10 };
        public void RunRevenueTest()
        {
            Console.WriteLine($"price for lenght 10 => { Revenue(5, prices)}");
            Console.WriteLine($"price for lenght 10 => { CutDynamic(5, prices)}");

        }
        public int Revenue(int n, List<int> prices)
        {
            if (n == 0) return 0;
            int maxVal = -1;
            for (int i = 0; i < n; i++)
            {
                int temp = prices[n - i - 1] + Revenue(i, prices);
                if (temp > maxVal)
                {
                    maxVal = temp;
                }
            }
            return maxVal;
        }

        public int CutDynamic(int n, List<int> prices)
        {
            int[] r = new int[n + 1];
            r[0] = 0;
            for (int i = 1; i <= n; i++)
            {
                int maxVal = -1;
                for (int j = 1; j <= i; j++)
                {
                    int temp = prices[j - 1] + r[i - j];
                    if (temp > maxVal)
                    {
                        maxVal = temp;
                    }
                }
                r[i] = maxVal;
            }

            return r[n];
        }
    }
}