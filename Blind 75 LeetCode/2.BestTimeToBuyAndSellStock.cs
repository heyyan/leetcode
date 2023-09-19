using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.Blind_75_LeetCode
{
    public class BestTimeToBuyAndSellStock
    {
        // you are given an array price where price[i] is the price of a given stock on the ith day
        // you wnat to maximize your profit by choosing a single day to buy one stock and choosing a 
        // different day in the future to sell that stock
        // return the maximum profit you can achieve from this transaction. if you cannot achieve any profit return 0.

        // input [7,1,5,3,6,4]
        // output 5

        // input [7,6,4,3,1]
        // output 0
        public void RunSolution()
        {
            var result = GetBestTimeToBuyAndSellStock2(new int[] { 7, 1, 5, 3, 6, 4 });
        }

        private int GetBestTimeToBuyAndSellStock(int[] prices)
        {
            int minPrice = prices[0];
            int MaxPrice = 0;
            int returnPrice = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] < minPrice)
                {
                    minPrice = prices[i];
                    // rest max
                    continue;
                }
                if (MaxPrice < prices[i])
                {
                    MaxPrice = prices[i];
                }
                returnPrice = MaxPrice - minPrice;
            }

            return returnPrice;
        }

        private int GetBestTimeToBuyAndSellStock2(int[] prices)
        {
            if(prices.Length == 0) return 0;
            int profit = 0;
            int left = 0;
            for(int right =1; right < prices.Length; right++)
            {
                if (prices[right] > prices[left])
                {
                    profit = Math.Max(profit, prices[right] - prices[left]);
                }
                else
                {
                    left = right;
                }
            }
            return profit;
        }

    }
}
